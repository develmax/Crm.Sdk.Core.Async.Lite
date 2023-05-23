using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk;

public sealed class LocalizedLabel : MetadataBase
{
    public bool? IsManaged { get; set; }
    public string Label { get; set; }
    public int LanguageCode { get; set; }
    public LocalizedLabel() { }
    public LocalizedLabel(string label, int languageCode)
    {
        this.Label = label;
        this.LanguageCode = languageCode;
    }
    internal new string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(base.ToValueXml());
        sb.Append(Util.ObjectToXml(IsManaged, "a:IsManaged", true));
        sb.Append(Util.ObjectToXml(Label, "a:Label", true));
        sb.Append(Util.ObjectToXml(LanguageCode, "a:LanguageCode", true));
        return sb.ToString();
    }
    static internal LocalizedLabel LoadFromXml(XElement item)
    {
        if (item.Elements().Count() == 0)
            return new LocalizedLabel();
        LocalizedLabel localizedLabel = new LocalizedLabel()
        {
            IsManaged = Util.LoadFromXml<bool?>(item.Element(Util.ns.a + "IsManaged")),
            Label = Util.LoadFromXml<string>(item.Element(Util.ns.a + "Label")),
            LanguageCode = Util.LoadFromXml<int>(item.Element(Util.ns.a + "LanguageCode")),
        };
        MetadataBase.LoadFromXml(item, localizedLabel);
        return localizedLabel;
    }
}