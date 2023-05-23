using System.Net.Http;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveLocLabelsResponse : OrganizationResponse
{
    public Label Label { get; set; }
    internal override void StoreResult(HttpResponseMessage httpResponse)
    {
        XDocument xdoc = XDocument.Parse(httpResponse.Content.ReadAsStringAsync().Result, LoadOptions.None);
        foreach (var result in xdoc.Descendants(Util.ns.a + "Results").Elements(Util.ns.a + "KeyValuePairOfstringanyType"))
        {
            if (result.Element(Util.ns.b + "key").Value == "Label")
                this.Label = Label.LoadFromXml(result.Element(Util.ns.b + "value"));
        }
    }
}