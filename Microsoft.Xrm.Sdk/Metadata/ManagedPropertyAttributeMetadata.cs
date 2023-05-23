using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata;

public sealed class ManagedPropertyAttributeMetadata : AttributeMetadata
{
    public string ManagedPropertyLogicalName { get; set; }
    public string ParentAttributeName { get; set; }
    public int? ParentComponentType { get; set; }
    public AttributeTypeCode ValueAttributeTypeCode { get; set; }
    public ManagedPropertyAttributeMetadata() : this(null) { }
    public ManagedPropertyAttributeMetadata(string schemaName)
        : base(AttributeTypeCode.ManagedProperty, schemaName) { }
    internal new string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(base.ToValueXml());
        sb.Append(Util.ObjectToXml(ManagedPropertyLogicalName, "h:ManagedPropertyLogicalName", true));
        sb.Append(Util.ObjectToXml(ParentAttributeName, "h:ParentAttributeName", true));
        sb.Append(Util.ObjectToXml(ParentComponentType, "h:ParentComponentType", true));
        sb.Append(Util.ObjectToXml(ValueAttributeTypeCode, "h:ValueAttributeTypeCode", true));
        return sb.ToString();
    }
    static internal new ManagedPropertyAttributeMetadata LoadFromXml(XElement item)
    {
        ManagedPropertyAttributeMetadata managedPropertyAttributeMetadata = new ManagedPropertyAttributeMetadata();
        AttributeMetadata.LoadFromXml(item, managedPropertyAttributeMetadata);
        managedPropertyAttributeMetadata.ManagedPropertyLogicalName = Util.LoadFromXml<string>(item.Element(Util.ns.h + "ManagedPropertyLogicalName"));
        managedPropertyAttributeMetadata.ParentAttributeName = Util.LoadFromXml<string>(item.Element(Util.ns.h + "ParentAttributeName"));
        managedPropertyAttributeMetadata.ParentComponentType = Util.LoadFromXml<int?>(item.Element(Util.ns.h + "ParentComponentType"));
        managedPropertyAttributeMetadata.ValueAttributeTypeCode =
            Util.LoadFromXml<AttributeTypeCode>(item.Element(Util.ns.h + "ValueAttributeTypeCode"));
        return managedPropertyAttributeMetadata;
    }
}