using System;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class UserAccessAuditDetail : AuditDetail
{
    public DateTime AccessTime { get; set; }
    public int Interval { get; set; }
    static internal new UserAccessAuditDetail LoadFromXml(XElement item)
    {
        UserAccessAuditDetail userAccessAuditDetail = new UserAccessAuditDetail();
        AuditDetail.LoadFromXml(item, userAccessAuditDetail);
        userAccessAuditDetail.AccessTime = Util.LoadFromXml<DateTime>(item.Element(Util.ns.h + "AccessTime"));
        userAccessAuditDetail.Interval = Util.LoadFromXml<int>(item.Element(Util.ns.h + "Interval"));
        return userAccessAuditDetail;
    }
}