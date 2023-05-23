using System;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata;

public sealed class StringFormatName : ConstantsBase<string>
{
    public static readonly StringFormatName Email;
    public static readonly StringFormatName Phone;
    public static readonly StringFormatName PhoneticGuide;
    public static readonly StringFormatName Text;
    public static readonly StringFormatName TextArea;
    public static readonly StringFormatName TickerSymbol;
    public static readonly StringFormatName Url;
    public static readonly StringFormatName VersionNumber;
    static StringFormatName()
    {
        Email = Add<StringFormatName>("Email");
        Text = Add<StringFormatName>("Text");
        TextArea = Add<StringFormatName>("TextArea");
        Url = Add<StringFormatName>("Url");
        TickerSymbol = Add<StringFormatName>("TickerSymbol");
        PhoneticGuide = Add<StringFormatName>("PhoneticGuide");
        VersionNumber = Add<StringFormatName>("VersionNumber");
        Phone = Add<StringFormatName>("Phone");
    }
    protected override bool ValueExistsInList(String value)
    {
        return ValidValues.Contains(value, StringComparer.OrdinalIgnoreCase);
    }
    internal string ToValueXml()
    {
        return Util.ObjectToXml(Value, "k:Value", true);
    }
    static internal StringFormatName LoadFromXml(XElement item)
    {
        if (item.Elements().Count() == 0)
            return null;
        StringFormatName stringFormatName = new StringFormatName()
        {
            Value = Util.LoadFromXml<string>(item.Element(Util.ns.k + "Value"))
        };
        return stringFormatName;
    }
}