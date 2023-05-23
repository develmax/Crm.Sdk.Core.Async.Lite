using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk;

public sealed class BooleanManagedProperty : ManagedProperty<bool>
{
    public BooleanManagedProperty() { }
    public BooleanManagedProperty(bool value)
    {
        this.Value = value;
    }
    internal new string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(base.ToValueXml());
        sb.Append(Util.ObjectToXml(Value, "a:Value", true));
        return sb.ToString();
    }
    static internal BooleanManagedProperty LoadFromXml(XElement item)
    {
        if (item.Elements().Count() == 0)
            return new BooleanManagedProperty();
        BooleanManagedProperty booleanManagedProperty = new BooleanManagedProperty();
        ManagedProperty<bool>.LoadFromXml(item, booleanManagedProperty);
        booleanManagedProperty.Value = Util.LoadFromXml<bool>(item.Element(Util.ns.a + "Value"));
        return booleanManagedProperty;
    }
}