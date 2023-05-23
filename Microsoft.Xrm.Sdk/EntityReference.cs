using System;
using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk;

public sealed class EntityReference
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public string LogicalName { get; set; }
    public EntityReference() { }
    public EntityReference(string logicalName, Guid id)
    {
        this.LogicalName = logicalName;
        this.Id = id;
    }
    internal string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(Util.ObjectToXml(Id, "a:Id", true));
        sb.Append(Util.ObjectToXml(LogicalName, "a:LogicalName", true));
        sb.Append(Util.ObjectToXml(Name, "a:Name", true));
        return sb.ToString();
    }
    static internal EntityReference LoadFromXml(XElement item)
    {
        EntityReference entityReference = new EntityReference()
        {
            Id = Util.LoadFromXml<Guid>(item.Element(Util.ns.a + "Id")),
            LogicalName = Util.LoadFromXml<string>(item.Element(Util.ns.a + "LogicalName")),
            Name = Util.LoadFromXml<string>(item.Element(Util.ns.a + "Name"))
        };
        return entityReference;
    }
}