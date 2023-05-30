using System;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class ComponentDetail
{
    public string DisplayName { get; set; }
    public Guid Id { get; set; }
    public string ParentDisplayName { get; set; }
    public Guid ParentId { get; set; }
    public string ParentSchemaName { get; set; }
    public string SchemaName { get; set; }
    public string Solution { get; set; }
    public int Type { get; set; }
    static internal ComponentDetail LoadFromXml(XElement item)
    {
        ComponentDetail componentDetail = new ComponentDetail()
        {
            DisplayName = item.Element(Util.ns.a + "DisplayName").Value,
            Id = Util.LoadFromXml<Guid>(item.Element(Util.ns.a + "Id")),
            ParentDisplayName = item.Element(Util.ns.a + "ParentDisplayName").Value,
            ParentId = Util.LoadFromXml<Guid>(item.Element(Util.ns.a + "ParentId")),
            ParentSchemaName = item.Element(Util.ns.a + "ParentSchemaName").Value,
            SchemaName = item.Element(Util.ns.a + "SchemaName").Value,
            Solution = item.Element(Util.ns.a + "Solution").Value,
            Type = Util.LoadFromXml<int>(item.Element(Util.ns.a + "Type"))
        };
        return componentDetail;
    }
}