using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;

namespace Microsoft.Xrm.Sdk;

public class OrganizationResponse
{
    public string ResponseName { get; set; }
    public Collection<KeyValuePair<string, object>> Results { get; set; }
    public string Item { get; set; }
    // Each message response has override method which restore
    // result to its members.
    internal virtual void StoreResult(HttpResponseMessage httpResponse) { }
}