using System.Net.Http;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Messages;

public sealed class RetrieveManagedPropertyResponse : OrganizationResponse
{
    public ManagedPropertyMetadata ManagedPropertyMetadata { get; set; }
    internal override void StoreResult(HttpResponseMessage httpResponse)
    {
        XDocument xdoc = XDocument.Parse(httpResponse.Content.ReadAsStringAsync().Result, LoadOptions.None);
        foreach (var result in xdoc.Descendants(Util.ns.a + "Results").Elements(Util.ns.a + "KeyValuePairOfstringanyType"))
        {
            if (result.Element(Util.ns.b + "key").Value == "ManagedPropertyMetadata")
                this.ManagedPropertyMetadata = ManagedPropertyMetadata.LoadFromXml(result.Element(Util.ns.b + "value"));
        }
    }
}