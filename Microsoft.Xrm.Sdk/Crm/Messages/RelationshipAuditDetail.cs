using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class RelationshipAuditDetail : AuditDetail
{
    public string RelationshipName { get; set; }
    public DataCollection<EntityReference> TargetRecords { get; set; }
    public RelationshipAuditDetail()
    {
        TargetRecords = new DataCollection<EntityReference>();
    }
    static internal new RelationshipAuditDetail LoadFromXml(XElement item)
    {
        RelationshipAuditDetail relationshipAuditDetail = new RelationshipAuditDetail();
        AuditDetail.LoadFromXml(item, relationshipAuditDetail);
        foreach (var value in item.Elements(Util.ns.g + "TargetRecords"))
        {
            relationshipAuditDetail.TargetRecords.Add(EntityReference.LoadFromXml(value));
        }
        relationshipAuditDetail.RelationshipName = item.Element(Util.ns.g + "RelationshipName").Value;
        return relationshipAuditDetail;
    }
}