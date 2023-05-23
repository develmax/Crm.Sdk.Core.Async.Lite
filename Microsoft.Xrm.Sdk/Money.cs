using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk;

public sealed class Money
{
    public Money()
    {
    }
    public Money(decimal Value)
    {
        this.Value = Value;
    }
    public decimal Value { get; set; }
    internal string ToValueXml()
    {
        return Util.ObjectToXml(Value, "a:Value", true);
    }
    static internal Money LoadFromXml(XElement item)
    {
        Money money = new Money()
        {
            Value = Util.LoadFromXml<decimal>(item.Element(Util.ns.a + "Value"))
        };
        return money;
    }
}