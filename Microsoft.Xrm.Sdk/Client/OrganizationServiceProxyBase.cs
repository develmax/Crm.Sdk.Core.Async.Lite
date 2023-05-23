using Microsoft.Xrm.Sdk.NtlmHttp;
using System.Net;
using System.Net.Http;

namespace Microsoft.Xrm.Sdk.Client
{
    public abstract class OrganizationServiceProxyBase
    {
        #region class members

        protected OrganizationServiceProxyBase(string serviceUrl)
        {
            ServiceUrl = serviceUrl;
        }

        protected OrganizationServiceProxyBase(string serviceUrl, NetworkCredential credential)
        {
            ServiceUrl = serviceUrl;
            Credential = credential;
        }

        public string ServiceUrl { get; set; }
        public string AccessToken { get; set; } // can be private, but not sure if user want to access it.
        public int Timeout { get; set; }
        public NetworkCredential Credential { get; set; }
        public bool UseProxy { get; set; }

        #endregion class members
        
        #region helpercode

        protected HttpClient CreateHttpClient()
        {
            HttpMessageHandler httpMessageHandler = Credential != null
                ? new NtlmHttpMessageHandler(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip, UseProxy = UseProxy }) { NetworkCredential = Credential }
                : new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip, UseProxy = UseProxy };

            return new HttpClient(httpMessageHandler);
        }
        
        #endregion helpercode
    }
}