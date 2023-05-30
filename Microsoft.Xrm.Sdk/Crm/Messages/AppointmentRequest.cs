using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class AppointmentRequest
{
    public int AnchorOffset { get; set; }
    public AppointmentsToIgnore[] AppointmentsToIgnore { get; set; }
    public ConstraintRelation[] Constraints { get; set; }
    public SearchDirection Direction { get; set; }
    public int Duration { get; set; }
    public int NumberOfResults { get; set; }
    public ObjectiveRelation[] Objectives { get; set; }
    public int RecurrenceDuration { get; set; }
    public int RecurrenceTimeZoneCode { get; set; }
    public RequiredResource[] RequiredResources { get; set; }
    public string SearchRecurrenceRule { get; set; }
    public DateTime? SearchRecurrenceStart { get; set; }
    public DateTime? SearchWindowEnd { get; set; }
    public DateTime? SearchWindowStart { get; set; }
    public Guid ServiceId { get; set; }
    public Guid[] Sites { get; set; }
    public int UserTimeZoneCode { get; set; }
    public AppointmentRequest()
    {
        AppointmentsToIgnore = new List<AppointmentsToIgnore>().ToArray();
        Constraints = new List<ConstraintRelation>().ToArray();
        Objectives = new List<ObjectiveRelation>().ToArray();
        RequiredResources = new List<RequiredResource>().ToArray();
        Sites = new List<Guid>().ToArray();
    }
    internal string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(Util.ObjectToXml(AnchorOffset, "g:AnchorOffset", true));
        sb.Append(Util.ObjectToXml(AppointmentsToIgnore, "g:AppointmentsToIgnore", true));
        sb.Append(Util.ObjectToXml(Constraints, "g:Constraints", true));
        sb.Append(Util.ObjectToXml(Direction, "g:Direction", true));
        sb.Append(Util.ObjectToXml(Duration, "g:Duration", true));
        sb.Append(Util.ObjectToXml(NumberOfResults, "g:NumberOfResults", true));
        sb.Append(Util.ObjectToXml(Objectives, "g:Objectives", true));
        sb.Append(Util.ObjectToXml(RecurrenceDuration, "g:RecurrenceDuration", true));
        sb.Append(Util.ObjectToXml(RecurrenceTimeZoneCode, "g:RecurrenceTimeZoneCode", true));
        sb.Append(Util.ObjectToXml(RequiredResources, "g:RequiredResources", true));
        sb.Append(Util.ObjectToXml(SearchRecurrenceRule, "g:SearchRecurrenceRule", true));
        sb.Append(Util.ObjectToXml(SearchRecurrenceStart, "g:SearchRecurrenceStart", true));
        sb.Append(Util.ObjectToXml(SearchWindowEnd, "g:SearchWindowEnd", true));
        sb.Append(Util.ObjectToXml(SearchWindowStart, "g:SearchWindowStart", true));
        sb.Append(Util.ObjectToXml(ServiceId, "g:ServiceId", true));
        sb.Append(Util.ObjectToXml(Sites, "g:Sites", true));
        sb.Append(Util.ObjectToXml(UserTimeZoneCode, "g:UserTimeZoneCode", true));
        return sb.ToString();
    }
}