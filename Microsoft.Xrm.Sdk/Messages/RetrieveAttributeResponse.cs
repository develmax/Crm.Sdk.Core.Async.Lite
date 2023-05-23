using System.Net.Http;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Messages;

public sealed class RetrieveAttributeResponse : OrganizationResponse
{
    public AttributeMetadata AttributeMetadata { get; set; }
    internal override void StoreResult(HttpResponseMessage httpResponse)
    {
        XDocument xdoc = XDocument.Parse(httpResponse.Content.ReadAsStringAsync().Result, LoadOptions.None);
        foreach (var result in xdoc.Descendants(Util.ns.a + "Results").Elements(Util.ns.a + "KeyValuePairOfstringanyType"))
        {
            if (result.Element(Util.ns.b + "key").Value == "AttributeMetadata")
                this.AttributeMetadata = AttributeMetadata.LoadFromXml(result.Element(Util.ns.b + "value"));
        }
    }
}