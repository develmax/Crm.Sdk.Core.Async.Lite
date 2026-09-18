using System;
using Microsoft.Xrm.Sdk.NtlmHttp;
using System.Net;
using System.Net.Http;

namespace Microsoft.Xrm.Sdk.Client
{
    public abstract class OrganizationServiceProxyBase : IDisposable
    {
        #region class members

        private OrganizationServiceProxyBase()
        {
            Timeout = new TimeSpan(0, 0, 2, 0);
        }

        protected OrganizationServiceProxyBase(string serviceUrl) : this()
        {
            ServiceUrl = serviceUrl;
        }

        protected OrganizationServiceProxyBase(string serviceUrl, NetworkCredential credential) : this()
        {
            ServiceUrl = serviceUrl;
            Credential = credential;
        }

        public string ServiceUrl { get; set; }
        public string AccessToken { get; set; } // can be private, but not sure if user want to access it.
        public TimeSpan Timeout { get; set; }
        public NetworkCredential Credential { get; set; }
        public bool UseProxy { get; set; }

        #endregion class members
        
        #region helpercode

        protected HttpClient CreateHttpClient() { return GetPooledHttpClient(); }
        private readonly object _transportLock = new object();
        private HttpMessageHandler _transport;
        private bool _disposed;
        private NetworkCredential _transportCredential;
        private bool _transportUseProxy;

        // The handler, rather than the short-lived HttpClient wrapper, owns the
        // authenticated connection pool. Dispose the proxy when its owner stops.
        private HttpClient GetPooledHttpClient()
        {
            lock (_transportLock)
            {
                if (_disposed) throw new ObjectDisposedException(GetType().Name);
                if (_transport == null)
                {
                    _transportCredential = Credential;
                    _transportUseProxy = UseProxy;
                    var handler = new HttpClientHandler
                    {
                        AutomaticDecompression = DecompressionMethods.GZip,
                        UseProxy = UseProxy,
                        AllowAutoRedirect = false
                    };
                    _transport = Credential == null ? (HttpMessageHandler)handler
                        : new NtlmHttpMessageHandler(handler) { NetworkCredential = Credential };
                }
                else if (!ReferenceEquals(Credential, _transportCredential) || UseProxy != _transportUseProxy)
                {
                    throw new InvalidOperationException("Configure credentials and proxy before the first request. Create a new proxy to change them.");
                }
                return new HttpClient(_transport, disposeHandler: false) { Timeout = Timeout };
            }
        }

        public void Dispose()
        {
            lock (_transportLock)
            {
                if (_disposed) return;
                _disposed = true;
                _transport?.Dispose();
            }
        }
        
        #endregion helpercode
    }
}