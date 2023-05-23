using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk;

public abstract class ManagedProperty<T>
{
    public bool CanBeChanged { get; set; }
    public string ManagedPropertyLogicalName { get; set; }
    public T Value { get; set; }
    public ManagedProperty() { this.CanBeChanged = true; }
    public ManagedProperty(string managedPropertyLogicalName)
    {
        this.ManagedPropertyLogicalName = managedPropertyLogicalName;
        this.CanBeChanged = true;
    }
    internal string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(Util.ObjectToXml(CanBeChanged, "a:CanBeChanged", true));
        sb.Append(Util.ObjectToXml(ManagedPropertyLogicalName, "a:ManagedPropertyLogicalName", true));
        return sb.ToString();
    }
    static internal void LoadFromXml(XElement item, ManagedProperty<T> meta)
    {
        if (item.Elements().Count() == 0)
            return;
        meta.CanBeChanged = Util.LoadFromXml<bool>(item.Element(Util.ns.a + "CanBeChanged"));
        meta.ManagedPropertyLogicalName = Util.LoadFromXml<string>(item.Element(Util.ns.a + "ManagedPropertyLogicalName"));
    }
}