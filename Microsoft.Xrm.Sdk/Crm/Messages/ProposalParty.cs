using System;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class ProposalParty
{
    public string DisplayName { get; set; }
    public double EffortRequired { get; set; }
    public string EntityName { get; set; }
    public Guid ResourceId { get; set; }
    public Guid ResourceSpecId { get; set; }
    static internal ProposalParty LoadFromXml(XElement item)
    {
        ProposalParty proposalParty = new ProposalParty()
        {
            DisplayName = item.Element(Util.ns.g + "DisplayName").Value,
            EffortRequired = Util.LoadFromXml<double>(item.Element(Util.ns.g + "EffortRequired")),
            EntityName = item.Element(Util.ns.g + "EntityName").Value,
            ResourceId = Util.LoadFromXml<Guid>(item.Element(Util.ns.g + "ResourceId")),
            ResourceSpecId = Util.LoadFromXml<Guid>(item.Element(Util.ns.g + "ResourceSpecId"))
        };
        return proposalParty;
    }
}