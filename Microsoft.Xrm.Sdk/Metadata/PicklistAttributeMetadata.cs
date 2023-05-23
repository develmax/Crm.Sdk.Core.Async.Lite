using System.Xml.Linq;

namespace Microsoft.Xrm.Sdk.Metadata;

public sealed class PicklistAttributeMetadata : EnumAttributeMetadata
{
    public PicklistAttributeMetadata() : this(null) { }
    public PicklistAttributeMetadata(string schemaName)
        : base(AttributeTypeCode.Picklist, schemaName) { }
    internal new string ToValueXml()
    {
        return base.ToValueXml();
    }
    static internal new PicklistAttributeMetadata LoadFromXml(XElement item)
    {
        PicklistAttributeMetadata picklistAttributeMetadata = new PicklistAttributeMetadata();
        EnumAttributeMetadata.LoadFromXml(item, picklistAttributeMetadata);
        return picklistAttributeMetadata;
    }
}