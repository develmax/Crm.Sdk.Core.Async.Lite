using System.Net.Http;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Metadata.Query;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Messages;

public sealed class RetrieveMetadataChangesResponse : OrganizationResponse
{
    public DeletedMetadataCollection DeletedMetadata { get; set; }
    public EntityMetadataCollection EntityMetadata { get; set; }
    public string ServerVersionStamp { get; set; }
    internal override void StoreResult(HttpResponseMessage httpResponse)
    {
        XDocument xdoc = XDocument.Parse(httpResponse.Content.ReadAsStringAsync().Result, LoadOptions.None);
        foreach (var result in xdoc.Descendants(Util.ns.a + "Results").Elements(Util.ns.a + "KeyValuePairOfstringanyType"))
        {
            if (result.Element(Util.ns.b + "key").Value == "DeletedMetadata")
                this.DeletedMetadata = DeletedMetadataCollection.LoadFromXml(result.Element(Util.ns.b + "value"));
            if (result.Element(Util.ns.b + "key").Value == "EntityMetadata")
                this.EntityMetadata = EntityMetadataCollection.LoadFromXml(result.Element(Util.ns.b + "value"));
            if (result.Element(Util.ns.b + "key").Value == "ServerVersionStamp")
                this.ServerVersionStamp = result.Element(Util.ns.b + "value").Value;
        }
    }
}