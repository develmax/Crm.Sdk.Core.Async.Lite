using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata;

public class RelationshipMetadataBase : MetadataBase
{
    public string IntroducedVersion { get; set; }
    public BooleanManagedProperty IsCustomizable { get; set; }
    public bool? IsCustomRelationship { get; set; }
    public bool? IsManaged { get; set; }
    public bool? IsValidForAdvancedFind { get; set; }
    public RelationshipType RelationshipType { get; set; }
    public string SchemaName { get; set; }
    public SecurityTypes? SecurityTypes { get; set; }
    public RelationshipMetadataBase() { }
    protected RelationshipMetadataBase(RelationshipType type)
    {
        this.RelationshipType = type;
    }
    internal new string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(base.ToValueXml());
        sb.Append(Util.ObjectToXml(IsCustomizable, "h:IsCustomizable", true));
        sb.Append(Util.ObjectToXml(IsCustomRelationship, "h:IsCustomRelationship", true));
        sb.Append(Util.ObjectToXml(IsManaged, "h:IsManaged", true));
        sb.Append(Util.ObjectToXml(IsValidForAdvancedFind, "h:IsValidForAdvancedFind", true));
        sb.Append(Util.ObjectToXml(SchemaName, "h:SchemaName", true));
        sb.Append(Util.ObjectToXml(SecurityTypes, "h:SecurityTypes", true));
        sb.Append(Util.ObjectToXml(IntroducedVersion, "h:IntroducedVersion", true));
        sb.Append(Util.ObjectToXml(RelationshipType, "h:RelationshipType", true));
        return sb.ToString();
    }
    static internal RelationshipMetadataBase LoadFromXml(XElement item)
    {
        RelationshipMetadataBase relationshipMetadataBase = new RelationshipMetadataBase();
        string type = (item.Attribute(Util.ns.i + "type") == null) ? "RelationshipMetadataBase" :
            item.Attribute(Util.ns.i + "type").Value.Substring(2);
        switch (type)
        {
            case "OneToManyRelationshipMetadata":
                relationshipMetadataBase = OneToManyRelationshipMetadata.LoadFromXml(item);
                break;
            case "ManyToManyRelationshipMetadata":
                relationshipMetadataBase = ManyToManyRelationshipMetadata.LoadFromXml(item);
                break;
            default:
                RelationshipMetadataBase.LoadFromXml(item, relationshipMetadataBase);
                break;
        }
        return relationshipMetadataBase;
    }
    static internal void LoadFromXml(XElement item, RelationshipMetadataBase meta)
    {
        if (item.Elements().Count() == 0)
            return;
        MetadataBase.LoadFromXml(item, meta);
        meta.IntroducedVersion = Util.LoadFromXml<string>(item.Element(Util.ns.h + "IntroducedVersion"));
        meta.IsCustomizable = BooleanManagedProperty.LoadFromXml(item.Element(Util.ns.h + "IsCustomizable"));
        meta.IsCustomRelationship = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "IsCustomRelationship"));
        meta.IsManaged = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "IsManaged"));
        meta.IsValidForAdvancedFind = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "IsValidForAdvancedFind"));
        meta.SchemaName = Util.LoadFromXml<string>(item.Element(Util.ns.h + "SchemaName"));
        meta.SecurityTypes = Util.LoadFromXml<SecurityTypes?>(item.Element(Util.ns.h + "SecurityTypes"));
    }
}