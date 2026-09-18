using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;


using Microsoft.Xrm.Sdk.Client;
using System.Runtime.Serialization;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.NtlmHttp;

internal static class Program
{
    private static void Main()
    {
        var entity = new Entity("account") { Id = Guid.NewGuid() };
        entity["name"] = "compatibility-smoke";
        using var stream = new MemoryStream();
        var serializer = new DataContractSerializer(typeof(Entity));
        serializer.WriteObject(stream, entity);
        stream.Position = 0;
        var copy = (Entity)serializer.ReadObject(stream);
        if (copy.Id != entity.Id) throw new InvalidOperationException("Entity serialization failed.");
        using var handler = new NtlmHttpMessageHandler(new HttpClientHandler { UseProxy = false })
        { NetworkCredential = new NetworkCredential("test", "test", "TEST") };
        VerifyWcf().GetAwaiter().GetResult();
        Console.WriteLine("Package loaded; serialization, pooled SOAP calls and cancellation scope passed.");
    }
    private static async Task VerifyWcf()
    {
        var listener = new TcpListener(IPAddress.Loopback, 0);
        listener.Start();
        try
        {
            var url = new Uri("http://127.0.0.1:" + ((IPEndPoint)listener.LocalEndpoint).Port + "/");
            var id = Guid.NewGuid();
            var server = Task.Run(async () =>
            {
                using var socket = await listener.AcceptTcpClientAsync();
                using var network = socket.GetStream();
                for (var call = 0; call < 2; call++)
                {
                    var header = new StringBuilder();
                    var buffer = new byte[1];
                    while (!header.ToString().EndsWith("\r\n\r\n", StringComparison.Ordinal))
                    {
                        if (await network.ReadAsync(buffer, 0, 1) == 0) throw new IOException("Connection was not reused.");
                        header.Append((char)buffer[0]);
                    }
                    var length = int.Parse(header.ToString().Split(new[] { "\r\n" }, StringSplitOptions.None)
                        .Single(line => line.StartsWith("Content-Length:", StringComparison.OrdinalIgnoreCase)).Split(':')[1]);
                    var body = new byte[length];
                    for (var offset = 0; offset < length;)
                    {
                        var read = await network.ReadAsync(body, offset, length - offset);
                        if (read == 0) throw new IOException("Incomplete request.");
                        offset += read;
                    }
                    var text = Encoding.UTF8.GetString(body);
                    if (text.Contains("cancellationToken") || !text.Contains(id.ToString())) throw new InvalidOperationException("Unexpected SOAP contract.");
                    var soap = "<s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\"><s:Body><CreateResponse xmlns=\"http://schemas.microsoft.com/xrm/2011/Contracts/Services\"><CreateResult>" + id + "</CreateResult></CreateResponse></s:Body></s:Envelope>";
                    var response = Encoding.UTF8.GetBytes("HTTP/1.1 200 OK\r\nContent-Type: text/xml; charset=utf-8\r\nContent-Length: " + Encoding.UTF8.GetByteCount(soap) + "\r\n\r\n" + soap);
                    await network.WriteAsync(response, 0, response.Length);
                }
            });
            using var proxy = new OrganizationServiceProxy(url.AbsoluteUri) { Timeout = TimeSpan.FromSeconds(5) };
            using var cancellation = new CancellationTokenSource();
            if (await proxy.CreateAsync(new Entity("account") { Id = id }, cancellation.Token) != id) throw new InvalidOperationException("Create failed.");
            cancellation.Cancel();
            if (await proxy.CreateAsync(new Entity("account") { Id = id }, CancellationToken.None) != id) throw new InvalidOperationException("Second create failed.");
            await server;
        }
        finally { listener.Stop(); }
    }}