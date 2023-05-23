using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class AttributeAuditDetail : AuditDetail
{
    public Dictionary<int, string> DeletedAttributes { get; set; }
    public DataCollection<string> InvalidNewValueAttributes { get; set; }
    public Entity NewValue { get; set; }
    public Entity OldValue { get; set; }
    public AttributeAuditDetail()
    {
        DeletedAttributes = new Dictionary<int, string>();
        InvalidNewValueAttributes = new DataCollection<string>();
    }
    static internal new AttributeAuditDetail LoadFromXml(XElement item)
    {
        AttributeAuditDetail attributeAuditDetail = new AttributeAuditDetail();
        AuditDetail.LoadFromXml(item, attributeAuditDetail);
        foreach (XElement value in item.Elements(Util.ns.g + "InvalidNewValueAttributes").Elements(Util.ns.f + "string"))
        {
            attributeAuditDetail.InvalidNewValueAttributes.Add(value.Value);
        }
        foreach (var value in item.Elements(Util.ns.g + "DeletedAttributes"))
        {
            if (value.Elements().Count() == 0)
                continue;
            attributeAuditDetail.DeletedAttributes.Add(
                Util.LoadFromXml<int>(value.Element(Util.ns.b + "key")),
                value.Element(Util.ns.b + "value").Value);
        }
        attributeAuditDetail.NewValue = Entity.LoadFromXml(item.Element(Util.ns.g + "NewValue"));
        attributeAuditDetail.OldValue = Entity.LoadFromXml(item.Element(Util.ns.g + "OldValue"));
        return attributeAuditDetail;
    }
}