using System.Collections.Generic;
using System.Net.Http;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class RetrieveMissingComponentsResponse : OrganizationResponse
{
    public MissingComponent[] MissingComponents { get; set; }
    internal override void StoreResult(HttpResponseMessage httpResponse)
    {
        // Convert to XDocument
        XDocument xdoc = XDocument.Parse(httpResponse.Content.ReadAsStringAsync().Result, LoadOptions.None);
        // Obtain Values from result.
        foreach (var result in xdoc.Descendants(Util.ns.a + "Results").Elements(Util.ns.a + "KeyValuePairOfstringanyType"))
        {
            if (result.Element(Util.ns.b + "key").Value == "MissingComponents")
            {
                List<MissingComponent> list = new List<MissingComponent>();
                foreach (var item in result.Element(Util.ns.b + "value").Elements(Util.ns.g + "MissingComponent"))
                {
                    list.Add(MissingComponent.LoadFromXml(item));
                }
                this.MissingComponents = list.ToArray();
            }
        }
    }
}