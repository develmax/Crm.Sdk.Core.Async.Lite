using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class UtcTimeFromLocalTimeRequest : OrganizationRequest
{
    public DateTime LocalTime
    {
        get
        {
            if (Parameters.Contains("LocalTime"))
                return (DateTime)Parameters["LocalTime"];
            return default(DateTime);
        }
        set { Parameters["LocalTime"] = value; }
    }
    public int TimeZoneCode
    {
        get
        {
            if (Parameters.Contains("TimeZoneCode"))
                return (int)Parameters["TimeZoneCode"];
            return default(int);
        }
        set { Parameters["TimeZoneCode"] = value; }
    }
    public UtcTimeFromLocalTimeRequest()
    {
        this.ResponseType = new UtcTimeFromLocalTimeResponse();
        this.RequestName = "UtcTimeFromLocalTime";
    }
    internal override string GetRequestBody()
    {
        Parameters["LocalTime"] = LocalTime;
        Parameters["TimeZoneCode"] = TimeZoneCode;
        return GetSoapBody();
    }
}