using System;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk;

public sealed class AliasedValue
{
    public string AttributeLogicalName { get; set; }
    public string EntityLogicalName { get; set; }
    public Object Value { get; set; }
    static public AliasedValue LoadFromXml(XElement item)
    {
        AliasedValue aliasedValue = new AliasedValue()
        {
            AttributeLogicalName = Util.LoadFromXml<string>(item.Element(Util.ns.a + "AttributeLogicalName")),
            EntityLogicalName = Util.LoadFromXml<string>(item.Element(Util.ns.a + "EntityLogicalName")),
            Value = Util.ObjectFromXml(item.Element(Util.ns.a + "Value"))
        };
        return aliasedValue;
    }
}