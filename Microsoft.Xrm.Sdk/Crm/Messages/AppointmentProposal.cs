using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class AppointmentProposal
{
    public DateTime? End { get; set; }
    public ProposalParty[] ProposalParties { get; set; }
    public Guid SiteId { get; set; }
    public string SiteName { get; set; }
    public DateTime? Start { get; set; }
    public AppointmentProposal()
    {
        ProposalParties = new List<ProposalParty>().ToArray();
    }
    static internal AppointmentProposal LoadFromXml(XElement item)
    {
        List<ProposalParty> list = new List<ProposalParty>();
        foreach (var proposalParties in item.Elements(Util.ns.g + "ProposalParties"))
        {
            foreach (var proposalParty in proposalParties.Elements(Util.ns.g + "ProposalParty"))
            {
                list.Add(ProposalParty.LoadFromXml(proposalParty));
            }
        }
        AppointmentProposal appointmentProposal = new AppointmentProposal()
        {
            End = Util.LoadFromXml<DateTime?>(item.Element(Util.ns.g + "End")),
            ProposalParties = list.ToArray(),
            SiteId = Util.LoadFromXml<Guid>(item.Element(Util.ns.g + "SiteId")),
            SiteName = item.Element(Util.ns.g + "SiteName").Value,
            Start = Util.LoadFromXml<DateTime?>(item.Element(Util.ns.g + "Start"))
        };
        return appointmentProposal;
    }
}