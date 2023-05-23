using System.Collections.Generic;
using System.Net.Http;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Messages;

public sealed class RetrieveAllEntitiesResponse : OrganizationResponse
{
    public EntityMetadata[] EntityMetadata { get; set; }
    public string Timestamp { get; set; }
    internal override void StoreResult(HttpResponseMessage httpResponse)
    {
        XDocument xdoc = XDocument.Parse(httpResponse.Content.ReadAsStringAsync().Result, LoadOptions.None);
        foreach (var result in xdoc.Descendants(Util.ns.a + "Results").Elements(Util.ns.a + "KeyValuePairOfstringanyType"))
        {
            if (result.Element(Util.ns.b + "key").Value == "EntityMetadata")
            {
                List<EntityMetadata> list = new List<EntityMetadata>();
                foreach (var item in result.Element(Util.ns.b + "value").Elements(Util.ns.h + "EntityMetadata"))
                {
                    list.Add(Microsoft.Xrm.Sdk.Metadata.EntityMetadata.LoadFromXml(item));
                }
                EntityMetadata = list.ToArray();
            }
            if (result.Element(Util.ns.b + "key").Value == "Timestamp")
                this.Timestamp = result.Element(Util.ns.b + "value").Value;
        }
    }
}