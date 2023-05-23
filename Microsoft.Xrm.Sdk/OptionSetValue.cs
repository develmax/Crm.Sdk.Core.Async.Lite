using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk;

public sealed class OptionSetValue
{
    public int Value { get; set; }
    public OptionSetValue()
    {
    }
    public OptionSetValue(int value)
    {
        this.Value = value;
    }
    internal string ToValueXml()
    {
        return Util.ObjectToXml(Value, "a:Value", true);
    }
    static internal OptionSetValue LoadFromXml(XElement item)
    {
        OptionSetValue optionSet = new OptionSetValue()
        {
            Value = Util.LoadFromXml<int>(item.Element(Util.ns.a + "Value"))
        };
        return optionSet;
    }
}