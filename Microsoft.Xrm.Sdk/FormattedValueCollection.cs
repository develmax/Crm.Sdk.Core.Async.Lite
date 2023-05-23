using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk;

public sealed class FormattedValueCollection : DataCollection<string, string>
{
    internal string ToXml()
    {
        StringBuilder sb = new StringBuilder();

        if (this.Count == 0)
        {
            return sb.Append("<a:FormattedValues/>").ToString();
        }

        sb.Append("<a:FormattedValues>");
        foreach (var item in this)
        {
            sb.Append("<a:KeyValuePairOfstringstring>");
            sb.Append("<b:key>" + item.Key + "</b:key><b:value>" + item.Value + "</b:value>");
            sb.Append("</a:KeyValuePairOfstringstring>");
        }
        sb.Append("</a:FormattedValues>");
        return sb.ToString();
    }
    internal void LoadFromXml(XElement item)
    {
        foreach (var fmt in item.Elements(Util.ns.a + "FormattedValues").Elements(Util.ns.a + "KeyValuePairOfstringstring"))
        {
            FormattedValueLoadFromXml(fmt);
        }
    }
    internal void FormattedValueLoadFromXml(XElement item)
    {
        string key = Util.LoadFromXml<string>(item.Element(Util.ns.b + "key"));
        string value = Util.LoadFromXml<string>(item.Element(Util.ns.b + "value"));
        this.Add(key, value);
    }
}