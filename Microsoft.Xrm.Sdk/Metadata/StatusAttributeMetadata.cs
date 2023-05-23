using System.Xml.Linq;

namespace Microsoft.Xrm.Sdk.Metadata;

public sealed class StatusAttributeMetadata : EnumAttributeMetadata
{
    public StatusAttributeMetadata()
        : base(AttributeTypeCode.Status, null) { }
    internal new string ToValueXml()
    {
        return base.ToValueXml();
    }
    static internal new StatusAttributeMetadata LoadFromXml(XElement item)
    {
        StatusAttributeMetadata statusAttributeMetadata = new StatusAttributeMetadata();
        EnumAttributeMetadata.LoadFromXml(item, statusAttributeMetadata);
        return statusAttributeMetadata;
    }
}