using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata;

public sealed class OneToManyRelationshipMetadata : RelationshipMetadataBase
{
    public AssociatedMenuConfiguration AssociatedMenuConfiguration { get; set; }
    public CascadeConfiguration CascadeConfiguration { get; set; }
    public string ReferencedAttribute { get; set; }
    public string ReferencedEntity { get; set; }
    public string ReferencingAttribute { get; set; }
    public string ReferencingEntity { get; set; }
    public OneToManyRelationshipMetadata() : base(RelationshipType.OneToManyRelationship) { }
    internal new string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(base.ToValueXml());
        sb.Append(Util.ObjectToXml(AssociatedMenuConfiguration, "h:AssociatedMenuConfiguration", true));
        sb.Append(Util.ObjectToXml(CascadeConfiguration, "h:CascadeConfiguration", true));
        sb.Append(Util.ObjectToXml(ReferencedAttribute, "h:ReferencedAttribute", true));
        sb.Append(Util.ObjectToXml(ReferencedEntity, "h:ReferencedEntity", true));
        sb.Append(Util.ObjectToXml(ReferencingAttribute, "h:ReferencingAttribute", true));
        sb.Append(Util.ObjectToXml(ReferencingEntity, "h:ReferencingEntity", true));
        return sb.ToString();
    }
    static internal new OneToManyRelationshipMetadata LoadFromXml(XElement item)
    {
        OneToManyRelationshipMetadata oneToManyRelationshipMetadata = new OneToManyRelationshipMetadata()
        {
            AssociatedMenuConfiguration = AssociatedMenuConfiguration.LoadFromXml(item.Element(Util.ns.h + "AssociatedMenuConfiguration")),
            CascadeConfiguration = CascadeConfiguration.LoadFromXml(item.Element(Util.ns.h + "CascadeConfiguration")),
            ReferencedAttribute = Util.LoadFromXml<string>(item.Element(Util.ns.h + "ReferencedAttribute")),
            ReferencedEntity = Util.LoadFromXml<string>(item.Element(Util.ns.h + "ReferencedEntity")),
            ReferencingAttribute = Util.LoadFromXml<string>(item.Element(Util.ns.h + "ReferencingAttribute")),
            ReferencingEntity = Util.LoadFromXml<string>(item.Element(Util.ns.h + "ReferencingEntity")),
        };
        RelationshipMetadataBase.LoadFromXml(item, oneToManyRelationshipMetadata);
        return oneToManyRelationshipMetadata;
    }
}