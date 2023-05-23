using System.Collections.Generic;
using System.Net.Http;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Messages;

public sealed class GetValidReferencedEntitiesResponse : OrganizationResponse
{
    public string[] EntityNames { get; set; }
    internal override void StoreResult(HttpResponseMessage httpResponse)
    {
        // Convert to XDocument
        XDocument xdoc = XDocument.Parse(httpResponse.Content.ReadAsStringAsync().Result, LoadOptions.None);
        // Obtain Values from result.
        foreach (var result in xdoc.Descendants(Util.ns.a + "Results").Elements(Util.ns.a + "KeyValuePairOfstringanyType"))
        {
            if (result.Element(Util.ns.b + "key").Value == "EntityNames")
            {
                List<string> list = new List<string>();
                foreach (XElement item in result.Element(Util.ns.b + "value").Elements(Util.ns.f + "string"))
                {
                    list.Add(item.Value);
                }
                //this.TimeInfos = EntityCollection.LoadFromXml(result.Element(Util.ns.b + "value"));
                this.EntityNames = list.ToArray();
            }
        }
    }
}