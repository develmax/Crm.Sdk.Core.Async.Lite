using System.Collections.Generic;
using System.Net.Http;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class BackgroundSendEmailResponse : OrganizationResponse
{
    public EntityCollection EntityCollection { get; set; }
    public bool[] HasAttachments { get; set; }

    internal override void StoreResult(HttpResponseMessage httpResponse)
    {
        XDocument xdoc = XDocument.Parse(httpResponse.Content.ReadAsStringAsync().Result, LoadOptions.None);
        foreach (var result in xdoc.Descendants(Util.ns.a + "Results").Elements(Util.ns.a + "KeyValuePairOfstringanyType"))
        {
            if (result.Element(Util.ns.b + "key").Value == "EntityCollection")
                EntityCollection = EntityCollection.LoadFromXml(result.Element(Util.ns.b + "value"));
            else if (result.Element(Util.ns.b + "key").Value == "HasAttachments")
            {
                List<bool> list = new List<bool>();
                foreach (XElement item in result.Element(Util.ns.b + "value").Elements(Util.ns.f + "boolean"))
                {
                    list.Add(Util.LoadFromXml<bool>(item));
                }
                this.HasAttachments = list.ToArray();
            }
        }
    }
}