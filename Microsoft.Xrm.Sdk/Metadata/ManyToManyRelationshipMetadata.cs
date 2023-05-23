using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata;

public sealed class ManyToManyRelationshipMetadata : RelationshipMetadataBase
{
    public AssociatedMenuConfiguration Entity1AssociatedMenuConfiguration { get; set; }
    public string Entity1IntersectAttribute { get; set; }
    public string Entity1LogicalName { get; set; }
    public AssociatedMenuConfiguration Entity2AssociatedMenuConfiguration { get; set; }
    public string Entity2IntersectAttribute { get; set; }
    public string Entity2LogicalName { get; set; }
    public string IntersectEntityName { get; set; }
    internal new string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(base.ToValueXml());
        sb.Append(Util.ObjectToXml(Entity1AssociatedMenuConfiguration, "h:Entity1AssociatedMenuConfiguration", true));
        sb.Append(Util.ObjectToXml(Entity1IntersectAttribute, "h:Entity1IntersectAttribute", true));
        sb.Append(Util.ObjectToXml(Entity1LogicalName, "h:Entity1LogicalName", true));
        sb.Append(Util.ObjectToXml(Entity2AssociatedMenuConfiguration, "h:Entity2AssociatedMenuConfiguration", true));
        sb.Append(Util.ObjectToXml(Entity2IntersectAttribute, "h:Entity2IntersectAttribute", true));
        sb.Append(Util.ObjectToXml(Entity2LogicalName, "h:Entity2LogicalName", true));
        sb.Append(Util.ObjectToXml(IntersectEntityName, "h:IntersectEntityName", true));
        return sb.ToString();
    }
    static internal new ManyToManyRelationshipMetadata LoadFromXml(XElement item)
    {
        ManyToManyRelationshipMetadata manyToManyRelationshipMetadata = new ManyToManyRelationshipMetadata()
        {
            Entity1AssociatedMenuConfiguration = AssociatedMenuConfiguration.LoadFromXml(item.Element(Util.ns.h + "Entity1AssociatedMenuConfiguration")),
            Entity1IntersectAttribute = Util.LoadFromXml<string>(item.Element(Util.ns.h + "Entity1IntersectAttribute")),
            Entity1LogicalName = Util.LoadFromXml<string>(item.Element(Util.ns.h + "Entity1LogicalName")),
            Entity2AssociatedMenuConfiguration = AssociatedMenuConfiguration.LoadFromXml(item.Element(Util.ns.h + "Entity2AssociatedMenuConfiguration")),
            Entity2IntersectAttribute = Util.LoadFromXml<string>(item.Element(Util.ns.h + "Entity2IntersectAttribute")),
            Entity2LogicalName = Util.LoadFromXml<string>(item.Element(Util.ns.h + "Entity2LogicalName")),
            IntersectEntityName = Util.LoadFromXml<string>(item.Element(Util.ns.h + "IntersectEntityName")),
        };
        RelationshipMetadataBase.LoadFromXml(item, manyToManyRelationshipMetadata);
        return manyToManyRelationshipMetadata;
    }
}