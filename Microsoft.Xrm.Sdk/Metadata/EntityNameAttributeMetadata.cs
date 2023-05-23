using System.Xml.Linq;

namespace Microsoft.Xrm.Sdk.Metadata;

public sealed class EntityNameAttributeMetadata : EnumAttributeMetadata
{
    public EntityNameAttributeMetadata() : this(null) { }
    public EntityNameAttributeMetadata(string schemaName)
        : base(AttributeTypeCode.EntityName, schemaName) { }
    internal new string ToValueXml()
    {
        return base.ToValueXml();
    }
    static internal new EntityNameAttributeMetadata LoadFromXml(XElement item)
    {
        EntityNameAttributeMetadata entityNameAttributeMetadata = new EntityNameAttributeMetadata();
        EnumAttributeMetadata.LoadFromXml(item, entityNameAttributeMetadata);
        return entityNameAttributeMetadata;
    }
}