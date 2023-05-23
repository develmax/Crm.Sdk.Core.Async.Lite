using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class QueryMultipleSchedulesRequest : OrganizationRequest
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
    public Guid[] ResourceIds
    {
        get
        {
            if (Parameters.Contains("ResourceIds"))
                return (Guid[])Parameters["ResourceIds"];
            return default(Guid[]);
        }
        set { Parameters["ResourceIds"] = value; }
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
    public QueryMultipleSchedulesRequest()
    {
        this.ResponseType = new QueryMultipleSchedulesResponse();
        this.RequestName = "QueryMultipleSchedules";
    }
    internal override string GetRequestBody()
    {
        Parameters["Start"] = Start;
        Parameters["End"] = End;
        Parameters["ResourceIds"] = ResourceIds;
        Parameters["TimeCodes"] = TimeCodes;
        return GetSoapBody();
    }
}