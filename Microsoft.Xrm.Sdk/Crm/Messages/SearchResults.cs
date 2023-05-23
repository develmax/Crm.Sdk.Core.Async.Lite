using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class SearchResults
{
    public AppointmentProposal[] Proposals { get; set; }
    public TraceInfo TraceInfo { get; set; }
    public SearchResults()
    {
        Proposals = new List<AppointmentProposal>().ToArray();
    }
    static internal SearchResults LoadFromXml(XElement item)
    {
        List<AppointmentProposal> list = new List<AppointmentProposal>();
        foreach (var proposals in item.Elements(Util.ns.g + "Proposals"))
        {
            foreach (var appointmentProposal in proposals.Elements(Util.ns.g + "AppointmentProposal"))
            {
                list.Add(AppointmentProposal.LoadFromXml(appointmentProposal));
            }
        }
        SearchResults searchResults = new SearchResults()
        {
            Proposals = list.ToArray(),
            TraceInfo = TraceInfo.LoadFromXml(item.Element(Util.ns.g + "TraceInfo"))
        };
        return searchResults;
    }
}