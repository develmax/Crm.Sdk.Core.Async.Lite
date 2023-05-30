using System;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class ResourceInfo
{
    public string DisplayName { get; set; }
    public string EntityName { get; set; }
    public Guid Id { get; set; }
    static internal ResourceInfo LoadFromXml(XElement item)
    {
        ResourceInfo resourceInfo = new ResourceInfo()
        {
            Id = Util.LoadFromXml<Guid>(item.Element(Util.ns.g + "Id")),
            DisplayName = item.Element(Util.ns.g + "DisplayName").Value,
            EntityName = item.Element(Util.ns.g + "EntityName").Value
        };
        return resourceInfo;
    }
}