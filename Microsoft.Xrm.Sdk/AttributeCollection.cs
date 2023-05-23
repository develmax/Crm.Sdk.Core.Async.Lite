using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk;

public sealed class AttributeCollection : DataCollection<string, object>
{
    internal string ToXml()
    {
        StringBuilder sb = new StringBuilder();

        if (this.Count == 0)
        {
            return sb.Append("<a:Attributes/>").ToString();
        }
        sb.Append("<a:Attributes>");
        foreach (var item in this)
        {
            sb.Append("<a:KeyValuePairOfstringanyType>");
            sb.Append("<b:key>" + item.Key + "</b:key>");
            sb.Append(Util.ObjectToXml(item.Value, "b:value"));
            sb.Append("</a:KeyValuePairOfstringanyType>");
        }
        sb.Append("</a:Attributes>");
        return sb.ToString();
    }
    internal void LoadFromXml(XElement item)
    {
        foreach (var att in item.Elements(Util.ns.a + "Attributes").Elements(Util.ns.a + "KeyValuePairOfstringanyType"))
        {
            AttributeLoadFromXml(att);
        }
    }
    internal void AttributeLoadFromXml(XElement item)
    {
        string key = Util.LoadFromXml<string>(item.Element(Util.ns.b + "key"));
        object value = Util.ObjectFromXml(item.Element(Util.ns.b + "value"));
        this.Add(key, value);
    }
}