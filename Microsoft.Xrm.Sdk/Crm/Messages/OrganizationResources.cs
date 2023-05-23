using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class OrganizationResources
{
    public int CurrentNumberOfActiveUsers { get; set; }
    public int MaxNumberOfActiveUsers { get; set; }
    public int CurrentNumberOfNonInteractiveUsers { get; set; }
    public int MaxNumberOfNonInteractiveUsers { get; set; }
    public int CurrentNumberOfCustomEntities { get; set; }
    public int MaxNumberOfCustomEntities { get; set; }
    public int CurrentNumberOfPublishedWorkflows { get; set; }
    public int MaxNumberOfPublishedWorkflows { get; set; }
    public int CurrentStorage { get; set; }
    public int MaxStorage { get; set; }
    static internal OrganizationResources LoadFromXml(XElement item)
    {
        OrganizationResources OrganizationResources = new OrganizationResources()
        {
            CurrentNumberOfActiveUsers = Util.LoadFromXml<int>(item.Element(Util.ns.a + "CurrentNumberOfActiveUsers")),
            MaxNumberOfActiveUsers = Util.LoadFromXml<int>(item.Element(Util.ns.a + "MaxNumberOfActiveUsers")),
            CurrentNumberOfNonInteractiveUsers = Util.LoadFromXml<int>(item.Element(Util.ns.a + "CurrentNumberOfNonInteractiveUsers")),
            MaxNumberOfNonInteractiveUsers = Util.LoadFromXml<int>(item.Element(Util.ns.a + "MaxNumberOfNonInteractiveUsers")),
            CurrentNumberOfCustomEntities = Util.LoadFromXml<int>(item.Element(Util.ns.a + "CurrentNumberOfCustomEntities")),
            MaxNumberOfCustomEntities = Util.LoadFromXml<int>(item.Element(Util.ns.a + "MaxNumberOfCustomEntities")),
            CurrentNumberOfPublishedWorkflows = Util.LoadFromXml<int>(item.Element(Util.ns.a + "CurrentNumberOfPublishedWorkflows")),
            MaxNumberOfPublishedWorkflows = Util.LoadFromXml<int>(item.Element(Util.ns.a + "MaxNumberOfPublishedWorkflows")),
            CurrentStorage = Util.LoadFromXml<int>(item.Element(Util.ns.a + "CurrentStorage")),
            MaxStorage = Util.LoadFromXml<int>(item.Element(Util.ns.a + "MaxStorage")),
        };
        return OrganizationResources;
    }
}