using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.NtlmHttp;
using Xunit;
#if FULL_SDK
using System.ServiceModel;
using System.ServiceModel.Description;
#endif

public class TransportTests
{
#if NET7_0_OR_GREATER
    [Fact]
    public async Task NtlmHandshakeAndRepeatedCallsStayOnOneConnection()
    {
        var authenticated = new ConcurrentDictionary<int, bool>();
        var contexts = new ConcurrentDictionary<int, System.Net.Security.NegotiateAuthentication>();
        using var server = new LoopbackServer(request =>
        {
            if (authenticated.ContainsKey(request.Connection)) return Task.FromResult(new Reply(200, "ok"));
            if (!request.Headers.Contains("Authorization: NTLM ", StringComparison.OrdinalIgnoreCase))
                return Task.FromResult(new Reply(401, "challenge", "WWW-Authenticate: NTLM\r\n"));
            var header = request.Headers.Split("\r\n").Single(x => x.StartsWith("Authorization:", StringComparison.OrdinalIgnoreCase));
            var token = Convert.FromBase64String(header.Substring(header.LastIndexOf(' ') + 1));
            var messageType = BitConverter.ToInt32(token, 8);
            if (messageType == 1)
            {
                var context = contexts.GetOrAdd(request.Connection, _ => new System.Net.Security.NegotiateAuthentication(
                    new System.Net.Security.NegotiateAuthenticationServerOptions { Package = "NTLM", Credential = CredentialCache.DefaultNetworkCredentials }));
                var challenge = context.GetOutgoingBlob(token, out var status);
                Assert.Equal(System.Net.Security.NegotiateAuthenticationStatusCode.ContinueNeeded, status);
                return Task.FromResult(new Reply(401, "challenge", "WWW-Authenticate: NTLM " + Convert.ToBase64String(challenge) + "\r\n"));
            }
            Assert.Equal(3, messageType);
            authenticated[request.Connection] = true;
            return Task.FromResult(new Reply(200, "ok"));
        });
        using var handler = new NtlmHttpMessageHandler(new HttpClientHandler { UseProxy = false })
        { NetworkCredential = new NetworkCredential("test-user", "test-password", "TEST") };
        for (var i = 0; i < 3; i++)
        {
            using var client = new HttpClient(handler, false) { Timeout = TimeSpan.FromSeconds(10) };
            using var response = await client.PostAsync(server.Url, new StringContent("payload"));
            Assert.True(response.StatusCode == HttpStatusCode.OK, "NTLM status=" + response.StatusCode + "; requests=" + server.Requests.Count + "; auth=" + string.Join(",", server.Requests.Select(r => r.Headers.Contains("Authorization:", StringComparison.OrdinalIgnoreCase))));
        }
        Assert.Single(server.Requests.Select(r => r.Connection).Distinct());
        Assert.Equal(5, server.Requests.Count);
        Assert.All(server.Requests, r => Assert.Equal("payload", r.Body));
        foreach (var context in contexts.Values) context.Dispose();
    }

#endif

    [Fact]
    public async Task UnauthorizedResponseIsReturnedWithoutManualRetry()
    {
        using var server = new LoopbackServer(_ => Task.FromResult(new Reply(401, "denied")));
        using var client = new HttpClient(new NtlmHttpMessageHandler(new HttpClientHandler { UseProxy = false }));
        using var response = await client.GetAsync(server.Url);
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        Assert.Single(server.Requests);
    }

    [Fact]
    public async Task BasicChallengeNeverReceivesCrmCredentials()
    {
        using var server = new LoopbackServer(_ => Task.FromResult(new Reply(401, "denied", "WWW-Authenticate: Basic realm=\"test\"\r\n")));
        using var client = new HttpClient(new NtlmHttpMessageHandler(new HttpClientHandler { UseProxy = false })
        { NetworkCredential = new NetworkCredential("test-user", "test-password", "TEST") });
        using var response = await client.GetAsync(server.Url);
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        Assert.Single(server.Requests);
        Assert.DoesNotContain("Authorization:", server.Requests.Single().Headers);
    }
    [Fact]
    public async Task RedirectDoesNotReplayWrite()
    {
        using var target = new LoopbackServer(_ => Task.FromResult(new Reply(200, "ok")));
        using var server = new LoopbackServer(_ => Task.FromResult(new Reply(307, "", "Location: " + target.Url + "\r\n")));
        using var client = new HttpClient(new NtlmHttpMessageHandler(new HttpClientHandler { UseProxy = false }));
        using var response = await client.PostAsync(server.Url, new StringContent("write"));
        Assert.Equal(HttpStatusCode.TemporaryRedirect, response.StatusCode);
        Assert.Empty(target.Requests);
    }

    [Fact]
    public async Task PreCanceledRequestNeverReachesServer()
    {
        using var server = new LoopbackServer(_ => Task.FromResult(new Reply(200, "ok")));
        using var client = new HttpClient(new NtlmHttpMessageHandler(new HttpClientHandler { UseProxy = false }));
        using var cancellation = new CancellationTokenSource();
        cancellation.Cancel();
        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => client.GetAsync(server.Url, cancellation.Token));
        Assert.Empty(server.Requests);
    }

    [Fact]
    public async Task TimeoutDoesNotReplayWrite()
    {
        using var server = new LoopbackServer(async _ => { await Task.Delay(500); return new Reply(200, "ok"); });
        using var client = new HttpClient(new NtlmHttpMessageHandler(new HttpClientHandler { UseProxy = false }))
        { Timeout = TimeSpan.FromMilliseconds(150) };
        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => client.PostAsync(server.Url, new StringContent("write")));
        Assert.Single(server.Requests);
    }


#if FULL_SDK
    private static OrganizationServiceProxy CreateProxy(LoopbackServer server)
    {
        var config = ServiceConfigurationFactory.CreateConfiguration<IOrganizationServiceContract>(new Uri(server.Url));
        foreach (var endpoint in config.ServiceEndpoints.Values)
        {
            var binding = (BasicHttpBinding)endpoint.Binding;
            binding.Security.Mode = BasicHttpSecurityMode.None;
            binding.UseDefaultWebProxy = false;
        }
        return new OrganizationServiceProxy(config, new ClientCredentials()) { Timeout = TimeSpan.FromSeconds(5) };
    }

    [Fact]
    public async Task WcfSoapContainsEntityIdButNoCancellationTokenAndReusesConnection()
    {
        var id = Guid.NewGuid();
        using var server = new LoopbackServer(_ => Task.FromResult(new Reply(200, Soap(id))));
        using var proxy = CreateProxy(server);
        using var firstCancellation = new CancellationTokenSource();
        Assert.Equal(id, await proxy.CreateAsync(new Entity("account", id), firstCancellation.Token));
        firstCancellation.Cancel(); // A completed call must not abort a subsequent pooled channel.
        Assert.Equal(id, await proxy.CreateAsync(new Entity("account", id), CancellationToken.None));
        Assert.Equal(2, server.Requests.Count);
        Assert.Single(server.Requests.Select(r => r.Connection).Distinct());
        Assert.All(server.Requests, r => { Assert.Contains(id.ToString(), r.Body); Assert.DoesNotContain("cancellationToken", r.Body); });
    }

    [Fact]
    public async Task WcfTimeoutSendsCreateOnlyOnce()
    {
        using var server = new LoopbackServer(async _ => { await Task.Delay(1000); return new Reply(200, Soap(Guid.NewGuid())); });
        using var proxy = CreateProxy(server);
        proxy.Timeout = TimeSpan.FromMilliseconds(200);
        await Assert.ThrowsAsync<TimeoutException>(() => proxy.CreateAsync(new Entity("account"), CancellationToken.None));
        Assert.Single(server.Requests);
    }

    [Fact]
    public async Task WcfPreCancellationDoesNotSendCreate()
    {
        using var server = new LoopbackServer(_ => Task.FromResult(new Reply(200, Soap(Guid.NewGuid()))));
        using var proxy = CreateProxy(server);
        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => proxy.CreateAsync(new Entity("account"), new CancellationToken(true)));
        Assert.Empty(server.Requests);
    }
#else
    [Fact]
    public async Task LiteProxyKeepsConnectionBetweenCreatesAndDisposesTransport()
    {
        var id = Guid.NewGuid();
        using var server = new LoopbackServer(_ => Task.FromResult(new Reply(200, Soap(id))));
        var proxy = new OrganizationServiceProxy(server.Url);
        Assert.Equal(id, await proxy.CreateAsync(new Entity("account"), CancellationToken.None));
        Assert.Equal(id, await proxy.CreateAsync(new Entity("account"), CancellationToken.None));
        Assert.Single(server.Requests.Select(r => r.Connection).Distinct());
        proxy.Dispose();
        await Assert.ThrowsAsync<ObjectDisposedException>(() => proxy.CreateAsync(new Entity("account"), CancellationToken.None));
    }
#endif
    private static string Soap(Guid id) => "<s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\"><s:Body><CreateResponse xmlns=\"http://schemas.microsoft.com/xrm/2011/Contracts/Services\"><CreateResult>" + id + "</CreateResult></CreateResponse></s:Body></s:Envelope>";
}

internal record Request(int Connection, string Headers, string Body);
internal record Reply(int Status, string Body, string Headers = "");
internal sealed class LoopbackServer : IDisposable
{
    private readonly TcpListener _listener = new(IPAddress.Loopback, 0);
    private readonly CancellationTokenSource _stop = new();
    private readonly Func<Request, Task<Reply>> _respond;
    private readonly ConcurrentBag<TcpClient> _clients = new();
    public ConcurrentQueue<Request> Requests { get; } = new();
    public string Url { get; }
    public LoopbackServer(Func<Request, Task<Reply>> respond)
    {
        _respond = respond;
        _listener.Start();
        Url = "http://127.0.0.1:" + ((IPEndPoint)_listener.LocalEndpoint).Port + "/";
        _ = Accept();
    }
    private async Task Accept()
    {
        var number = 0;
        try
        {
            while (!_stop.IsCancellationRequested)
            {
                var client = await _listener.AcceptTcpClientAsync();
                _clients.Add(client);
                _ = Serve(client, ++number);
            }
        }
        catch (Exception) when (_stop.IsCancellationRequested) { }
    }
    private async Task Serve(TcpClient client, int number)
    {
        try
        {
            var stream = client.GetStream();
            while (!_stop.IsCancellationRequested)
            {
                var header = new StringBuilder();
                var one = new byte[1];
                while (!header.ToString().EndsWith("\r\n\r\n", StringComparison.Ordinal))
                {
                    if (await stream.ReadAsync(one, 0, 1, _stop.Token) == 0) return;
                    header.Append((char)one[0]);
                }
                var headers = header.ToString();
                var lengthLine = headers.Split("\r\n").FirstOrDefault(x => x.StartsWith("Content-Length:", StringComparison.OrdinalIgnoreCase));
                var length = lengthLine == null ? 0 : int.Parse(lengthLine.Split(':')[1]);
                var body = new byte[length];
                for (var offset = 0; offset < length;)
                {
                    var read = await stream.ReadAsync(body, offset, length - offset, _stop.Token);
                    if (read == 0) return;
                    offset += read;
                }
                var request = new Request(number, headers, Encoding.UTF8.GetString(body));
                Requests.Enqueue(request);
                var reply = await _respond(request);
                var content = Encoding.UTF8.GetBytes(reply.Body);
                var response = Encoding.ASCII.GetBytes("HTTP/1.1 " + reply.Status + " Response\r\nContent-Type: text/xml; charset=utf-8\r\nContent-Length: " + content.Length + "\r\n" + reply.Headers + "\r\n");
                await stream.WriteAsync(response, 0, response.Length, _stop.Token);
                await stream.WriteAsync(content, 0, content.Length, _stop.Token);
            }
        }
        catch (Exception) when (_stop.IsCancellationRequested) { }
        catch (IOException) { }
    }
    public void Dispose()
    {
        _stop.Cancel();
        _listener.Stop();
        foreach (var client in _clients) client.Dispose();
    }
}