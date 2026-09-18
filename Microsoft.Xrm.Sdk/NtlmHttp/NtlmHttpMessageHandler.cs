using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Xrm.Sdk.NtlmHttp
{
    /// <summary>Uses the transport's connection-bound NTLM/Negotiate implementation.</summary>
    public class NtlmHttpMessageHandler : DelegatingHandler
    {
        private readonly HttpClientHandler _transport;
        private readonly object _gate = new object();
        private NetworkCredential _credential;
        private Uri _authority;
        private bool _started;

        public NtlmHttpMessageHandler(HttpMessageHandler innerHandler) : base(innerHandler)
        {
            _transport = innerHandler as HttpClientHandler
                ?? throw new ArgumentException("NTLM requires an HttpClientHandler transport.", nameof(innerHandler));
            _transport.AllowAutoRedirect = false;
        }

        public NetworkCredential NetworkCredential
        {
            get { lock (_gate) return _credential; }
            set
            {
                lock (_gate)
                {
                    if (_started) throw new InvalidOperationException("Configure credentials before the first request.");
                    _credential = value;
                }
            }
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (request == null) throw new ArgumentNullException(nameof(request));
            var authority = new Uri(request.RequestUri.GetLeftPart(UriPartial.Authority) + "/");
            lock (_gate)
            {
                if (!_started)
                {
                    // Preserve the original NTLM/Negotiate-only policy. A bare
                    // NetworkCredential would also accept a server's Basic challenge.
                    if (_credential != null)
                    {
                        _transport.Credentials = new CredentialCache
                        {
                            { authority, "NTLM", _credential },
                            { authority, "Negotiate", _credential }
                        };
                    }
                    _authority = authority;
                    _started = true;
                }
                else if (_authority != authority)
                {
                    throw new InvalidOperationException("Use a separate handler for a different CRM authority.");
                }
            }
            // No application-level retry: the transport owns the handshake/socket.
            return base.SendAsync(request, cancellationToken);
        }
    }
}