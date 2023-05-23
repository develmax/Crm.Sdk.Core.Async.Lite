using System.Xml.Linq;

namespace Microsoft.Xrm.Sdk.Metadata;

public sealed class StateAttributeMetadata : EnumAttributeMetadata
{
    public StateAttributeMetadata()
        : base(AttributeTypeCode.State, null) { }
    internal new string ToValueXml()
    {
        return base.ToValueXml();
    }
    static internal new StateAttributeMetadata LoadFromXml(XElement item)
    {
        StateAttributeMetadata stateAttributeMetadata = new StateAttributeMetadata();
        EnumAttributeMetadata.LoadFromXml(item, stateAttributeMetadata);
        return stateAttributeMetadata;
    }
}