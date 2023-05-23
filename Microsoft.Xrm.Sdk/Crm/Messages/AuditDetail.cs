using System.Linq;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.OData.Messages;

public class AuditDetail
{
    public Entity AuditRecord { get; set; }
    static internal AuditDetail LoadFromXml(XElement item)
    {
        AuditDetail auditDetail = new AuditDetail();
        string type = (item.Attribute(Util.ns.i + "type") == null) ? "AuditDetail" :
            item.Attribute(Util.ns.i + "type").Value.Substring(2);
        switch (type)
        {
            case "AttributeAuditDetail":
                auditDetail = AttributeAuditDetail.LoadFromXml(item);
                break;
            case "RelationshipAuditDetail":
                auditDetail = RelationshipAuditDetail.LoadFromXml(item);
                break;
            case "RolePrivilegeAuditDetail":
                auditDetail = RolePrivilegeAuditDetail.LoadFromXml(item);
                break;
            case "ShareAuditDetail":
                auditDetail = ShareAuditDetail.LoadFromXml(item);
                break;
            case "UserAccessAuditDetail":
                auditDetail = UserAccessAuditDetail.LoadFromXml(item);
                break;
            default:
                AuditDetail.LoadFromXml(item, auditDetail);
                break;
        }
        return auditDetail;
    }
    static internal void LoadFromXml(XElement item, AuditDetail audit)
    {
        if (item.Elements().Count() == 0)
            return;
        audit.AuditRecord = Entity.LoadFromXml(item.Element(Util.ns.g + "AuditRecord"));
    }
}