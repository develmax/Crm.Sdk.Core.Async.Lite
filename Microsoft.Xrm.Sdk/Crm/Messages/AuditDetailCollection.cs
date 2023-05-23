using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class AuditDetailCollection
{
    public DataCollection<AuditDetail> AuditDetails { get; set; }
    public AuditDetail this[int index]
    {
        get
        {
            return AuditDetails[index];
        }
        set
        {
            AuditDetails[index] = value;
        }
    }
    public int Count { get; set; }
    public bool MoreRecords { get; set; }
    public string PagingCookie { get; set; }
    public int TotalRecordCount { get; set; }
    public AuditDetailCollection()
    {
        AuditDetails = new DataCollection<AuditDetail>();
    }
    static internal AuditDetailCollection LoadFromXml(XElement item)
    {
        AuditDetailCollection auditDetailCollection = new AuditDetailCollection()
        {
            MoreRecords = Util.LoadFromXml<bool>(item.Element(Util.ns.g + "MoreRecords")),
            PagingCookie = item.Element(Util.ns.g + "PagingCookie").Value,
            TotalRecordCount = Util.LoadFromXml<int>(item.Element(Util.ns.g + "TotalRecordCount"))
        };

        foreach (var auditDetail in item.Element(Util.ns.g + "AuditDetails").Elements(Util.ns.g + "AuditDetail"))
        {
            auditDetailCollection.AuditDetails.Add(AuditDetail.LoadFromXml(auditDetail));
        }
        if (auditDetailCollection.AuditDetails.Count > 0)
            auditDetailCollection.Count = auditDetailCollection.AuditDetails.Count;
        return auditDetailCollection;
    }
}