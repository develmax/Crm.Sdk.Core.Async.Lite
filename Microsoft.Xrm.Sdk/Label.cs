using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk;

public sealed class Label
{
    public LocalizedLabelCollection LocalizedLabels { get; set; }
    public LocalizedLabel UserLocalizedLabel { get; set; }
    public Label()
    {
        this.LocalizedLabels = new LocalizedLabelCollection();
    }
    public Label(LocalizedLabel userLocalizedLabel, LocalizedLabel[] labels)
        : this()
    {
        this.UserLocalizedLabel = userLocalizedLabel;
        foreach (LocalizedLabel label in labels)
        {
            this.LocalizedLabels.Add(label);
        }
    }
    public Label(string label, int languageCode)
        : this()
    {
        this.LocalizedLabels.Add(new LocalizedLabel(label, languageCode));
    }
    internal string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(Util.ObjectToXml(LocalizedLabels, "a:LocalizedLabels", true));
        sb.Append(Util.ObjectToXml(UserLocalizedLabel, "a:UserLocalizedLabel", true));
        return sb.ToString();
    }
    static internal Label LoadFromXml(XElement item)
    {
        if (item.Elements().Count() == 0)
            return new Label();
        Label label = new Label()
        {
            UserLocalizedLabel = LocalizedLabel.LoadFromXml(item.Element(Util.ns.a + "UserLocalizedLabel")),
            LocalizedLabels = LocalizedLabelCollection.LoadFromXml(item.Element(Util.ns.a + "LocalizedLabels"))
        };
        return label;
    }
}