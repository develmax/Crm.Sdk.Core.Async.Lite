using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata;

public sealed class AttributeRequiredLevelManagedProperty : ManagedProperty<AttributeRequiredLevel>
{
    public AttributeRequiredLevelManagedProperty() { }
    public AttributeRequiredLevelManagedProperty(AttributeRequiredLevel value)
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
    static internal AttributeRequiredLevelManagedProperty LoadFromXml(XElement item)
    {
        if (item.Elements().Count() == 0)
            return new AttributeRequiredLevelManagedProperty();
        AttributeRequiredLevelManagedProperty attributeRequiredLevelManagedProperty = new AttributeRequiredLevelManagedProperty();
        ManagedProperty<AttributeRequiredLevel>.LoadFromXml(item, attributeRequiredLevelManagedProperty);
        attributeRequiredLevelManagedProperty.Value = Util.LoadFromXml<AttributeRequiredLevel>(item.Element(Util.ns.a + "Value"));
        return attributeRequiredLevelManagedProperty;
    }
}