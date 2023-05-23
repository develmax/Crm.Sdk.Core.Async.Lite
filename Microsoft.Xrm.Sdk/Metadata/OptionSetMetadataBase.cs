using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata;

public class OptionSetMetadataBase : MetadataBase
{
    public Label Description { get; set; }
    public Label DisplayName { get; set; }
    public string IntroducedVersion { get; set; }
    public BooleanManagedProperty IsCustomizable { get; set; }
    public bool? IsCustomOptionSet { get; set; }
    public bool? IsGlobal { get; set; }
    public bool? IsManaged { get; set; }
    public string Name { get; set; }
    public OptionSetType? OptionSetType { get; set; }
    internal new string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(base.ToValueXml());
        sb.Append(Util.ObjectToXml(Description, "h:Description", true));
        sb.Append(Util.ObjectToXml(DisplayName, "h:DisplayName", true));
        sb.Append(Util.ObjectToXml(IsCustomizable, "h:IsCustomizable", true));
        sb.Append(Util.ObjectToXml(IsCustomOptionSet, "h:IsCustomOptionSet", true));
        sb.Append(Util.ObjectToXml(IsGlobal, "h:IsGlobal", true));
        sb.Append(Util.ObjectToXml(IsManaged, "h:IsManaged", true));
        sb.Append(Util.ObjectToXml(Name, "h:Name", true));
        sb.Append(Util.ObjectToXml(IntroducedVersion, "h:IntroducedVersion", true));
        sb.Append(Util.ObjectToXml(OptionSetType, "h:OptionSetType", true));
        return sb.ToString();
    }
    static internal OptionSetMetadataBase LoadFromXml(XElement item)
    {
        OptionSetMetadataBase optionSetMetadataBase = new OptionSetMetadataBase();
        string type = (item.Attribute(Util.ns.i + "type") == null) ? "OptionSetMetadataBase" :
            item.Attribute(Util.ns.i + "type").Value.Substring(2);
        switch (type)
        {
            case "OptionSetMetadata":
                optionSetMetadataBase = OptionSetMetadata.LoadFromXml(item);
                break;
            case "BooleanOptionSetMetadata":
                optionSetMetadataBase = BooleanOptionSetMetadata.LoadFromXml(item);
                break;
            default:
                OptionSetMetadataBase.LoadFromXml(item, optionSetMetadataBase);
                break;
        }
        return optionSetMetadataBase;
    }
    static internal void LoadFromXml(XElement item, OptionSetMetadataBase meta)
    {
        if (item.Elements().Count() == 0)
            return;
        MetadataBase.LoadFromXml(item, meta);
        meta.Description = Label.LoadFromXml(item.Element(Util.ns.h + "Description"));
        meta.DisplayName = Label.LoadFromXml(item.Element(Util.ns.h + "DisplayName"));
        meta.IntroducedVersion = Util.LoadFromXml<string>(item.Element(Util.ns.h + "IntroducedVersion"));
        meta.IsCustomizable = BooleanManagedProperty.LoadFromXml(item.Element(Util.ns.h + "IsCustomizable"));
        meta.IsCustomOptionSet = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "IsCustomOptionSet"));
        meta.IsGlobal = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "IsGlobal"));
        meta.IsManaged = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "IsManaged"));
    }
}