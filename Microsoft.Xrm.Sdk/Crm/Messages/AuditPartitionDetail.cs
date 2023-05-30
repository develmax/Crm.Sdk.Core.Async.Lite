using System;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class AuditPartitionDetail
{
    public DateTime? EndDate { get; set; }
    public int PartitionNumber { get; set; }
    public long Size { get; set; }
    public DateTime? StartDate { get; set; }
    static internal AuditPartitionDetail LoadFromXml(XElement item)
    {
        AuditPartitionDetail auditPartitionDetail = new AuditPartitionDetail()
        {
            EndDate = Util.LoadFromXml<DateTime?>(item.Element(Util.ns.g + "EndDate")),
            PartitionNumber = Util.LoadFromXml<int>(item.Element(Util.ns.g + "PartitionNumber")),
            Size = Util.LoadFromXml<long>(item.Element(Util.ns.g + "Size")),
            StartDate = Util.LoadFromXml<DateTime?>(item.Element(Util.ns.g + "StartDate"))
        };
        return auditPartitionDetail;
    }
}