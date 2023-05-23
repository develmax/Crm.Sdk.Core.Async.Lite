using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata;

public class OptionMetadata : MetadataBase
{
    public Label Description { get; set; }
    public bool? IsManaged { get; set; }
    public Label Label { get; set; }
    public int? Value { get; set; }
    public OptionMetadata() { }
    public OptionMetadata(Label label, int? value)
    {
        this.Label = label;
        this.Value = value;
    }
    public OptionMetadata(int value)
    {
        this.Value = value;
    }
    internal new string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(base.ToValueXml());
        sb.Append(Util.ObjectToXml(Description, "h:Description", true));
        sb.Append(Util.ObjectToXml(IsManaged, "h:IsManaged", true));
        sb.Append(Util.ObjectToXml(Label, "h:Label", true));
        sb.Append(Util.ObjectToXml(Value, "h:Value", true));
        return sb.ToString();
    }
    static internal OptionMetadata LoadFromXml(XElement item)
    {
        OptionMetadata optionMetadata = new OptionMetadata();
        OptionMetadata.LoadFromXml(item, optionMetadata);
        return optionMetadata;
    }
    static internal void LoadFromXml(XElement item, OptionMetadata meta)
    {
        if (item.Elements().Count() == 0)
            return;
        MetadataBase.LoadFromXml(item, meta);
        meta.Description = Label.LoadFromXml(item.Element(Util.ns.h + "Description"));
        meta.IsManaged = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "IsManaged"));
        meta.Label = Label.LoadFromXml(item.Element(Util.ns.h + "Label"));
        meta.Value = Util.LoadFromXml<int?>(item.Element(Util.ns.h + "Value"));
    }
}