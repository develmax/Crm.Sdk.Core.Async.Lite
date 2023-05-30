using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class ExpandCalendarRequest : OrganizationRequest
{
    public Guid CalendarId
    {
        get
        {
            if (Parameters.Contains("CalendarId"))
                return (Guid)Parameters["CalendarId"];
            return default(Guid);
        }
        set { Parameters["CalendarId"] = value; }
    }
    public DateTime Start
    {
        get
        {
            if (Parameters.Contains("Start"))
                return (DateTime)Parameters["Start"];
            return default(DateTime);
        }
        set { Parameters["Start"] = value; }
    }
    public DateTime End
    {
        get
        {
            if (Parameters.Contains("End"))
                return (DateTime)Parameters["End"];
            return default(DateTime);
        }
        set { Parameters["End"] = value; }
    }
    public ExpandCalendarRequest()
    {
        this.ResponseType = new ExpandCalendarResponse();
        this.RequestName = "ExpandCalendar";
    }
    internal override string GetRequestBody()
    {
        Parameters["CalendarId"] = CalendarId;
        Parameters["Start"] = Start;
        Parameters["End"] = End;
        return GetSoapBody();
    }
}