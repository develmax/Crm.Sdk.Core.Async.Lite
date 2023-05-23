using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class QueryScheduleRequest : OrganizationRequest
{
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
    public Guid ResourceId
    {
        get
        {
            if (Parameters.Contains("ResourceId"))
                return (Guid)Parameters["ResourceId"];
            return default(Guid);
        }
        set { Parameters["ResourceId"] = value; }
    }
    public TimeCode[] TimeCodes
    {
        get
        {
            if (Parameters.Contains("TimeCodes"))
                return (TimeCode[])Parameters["TimeCodes"];
            return default(TimeCode[]);
        }
        set { Parameters["TimeCodes"] = value; }
    }
    public QueryScheduleRequest()
    {
        this.ResponseType = new QueryScheduleResponse();
        this.RequestName = "QuerySchedule";
    }
    internal override string GetRequestBody()
    {
        Parameters["Start"] = Start;
        Parameters["End"] = End;
        Parameters["ResourceId"] = ResourceId;
        Parameters["TimeCodes"] = TimeCodes;
        return GetSoapBody();
    }
}