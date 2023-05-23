using System.Xml.Linq;
using Microsoft.Crm.Sdk.OData.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class ShareAuditDetail : AuditDetail
{
    public AccessRights NewPrivileges { get; set; }
    public AccessRights OldPrivileges { get; set; }
    public EntityReference Principal { get; set; }
    static internal new ShareAuditDetail LoadFromXml(XElement item)
    {
        ShareAuditDetail shareAuditDetail = new ShareAuditDetail();
        AuditDetail.LoadFromXml(item, shareAuditDetail);
        shareAuditDetail.NewPrivileges =
            Util.GetAccessRightsFromString(item.Element(Util.ns.g + "NewPrivileges").Value);
        shareAuditDetail.OldPrivileges =
            Util.GetAccessRightsFromString(item.Element(Util.ns.g + "OldPrivileges").Value);
        shareAuditDetail.Principal = EntityReference.LoadFromXml(item.Element(Util.ns.g + "Principal"));
        return shareAuditDetail;
    }
}