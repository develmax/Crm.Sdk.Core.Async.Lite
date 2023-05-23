using System;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class TimeInfo
{
    public int ActivityStatusCode { get; set; }
    public Guid CalendarId { get; set; }
    public string DisplayText { get; set; }
    public double Effort { get; set; }
    public DateTime? End { get; set; }
    public bool IsActivity { get; set; }
    public Guid SourceId { get; set; }
    public int SourceTypeCode { get; set; }
    public DateTime? Start { get; set; }
    public SubCode SubCode { get; set; }
    public TimeCode TimeCode { get; set; }
    static internal TimeInfo LoadFromXml(XElement item)
    {
        TimeInfo timeInfo = new TimeInfo()
        {
            ActivityStatusCode = Util.LoadFromXml<int>(item.Element(Util.ns.g + "ActivityStatusCode")),
            CalendarId = Util.LoadFromXml<Guid>(item.Element(Util.ns.g + "CalendarId")),
            DisplayText = item.Element(Util.ns.g + "DisplayText").Value,
            Effort = Util.LoadFromXml<double>(item.Element(Util.ns.g + "Effort")),
            End = Util.LoadFromXml<DateTime>(item.Element(Util.ns.g + "End")),
            IsActivity = Util.LoadFromXml<bool>(item.Element(Util.ns.g + "IsActivity")),
            SourceId = Util.LoadFromXml<Guid>(item.Element(Util.ns.g + "SourceId")),
            SourceTypeCode = Util.LoadFromXml<int>(item.Element(Util.ns.g + "SourceTypeCode")),
            Start = Util.LoadFromXml<DateTime>(item.Element(Util.ns.g + "Start")),
            SubCode = Util.LoadFromXml<SubCode>(item.Element(Util.ns.g + "SubCode")),
            TimeCode = Util.LoadFromXml<TimeCode>(item.Element(Util.ns.g + "TimeCode")),
        };
        return timeInfo;
    }
}