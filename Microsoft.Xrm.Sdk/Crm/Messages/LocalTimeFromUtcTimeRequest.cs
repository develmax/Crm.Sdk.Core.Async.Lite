using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class LocalTimeFromUtcTimeRequest : OrganizationRequest
{
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
    public DateTime UtcTime
    {
        get
        {
            if (Parameters.Contains("UtcTime"))
                return (DateTime)Parameters["UtcTime"];
            return default(DateTime);
        }
        set { Parameters["UtcTime"] = value; }
    }
    public LocalTimeFromUtcTimeRequest()
    {
        this.ResponseType = new LocalTimeFromUtcTimeResponse();
        this.RequestName = "LocalTimeFromUtcTime";
    }
    internal override string GetRequestBody()
    {
        Parameters["TimeZoneCode"] = TimeZoneCode;
        Parameters["UtcTime"] = UtcTime;
        return GetSoapBody();
    }
}