using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RenewEntitlementRequest : OrganizationRequest
{
    public Guid EntitlementId
    {
        get
        {
            if (Parameters.Contains("EntitlementId"))
                return (Guid)Parameters["EntitlementId"];
            return default(Guid);
        }
        set { Parameters["EntitlementId"] = value; }
    }
    public int Status
    {
        get
        {
            if (Parameters.Contains("Status"))
                return (int)Parameters["Status"];
            return default(int);
        }
        set { Parameters["Status"] = value; }
    }
    public RenewEntitlementRequest()
    {
        this.ResponseType = new RenewEntitlementResponse();
        this.RequestName = "RenewEntitlement";
    }
    internal override string GetRequestBody()
    {
        Parameters["EntitlementId"] = EntitlementId;
        Parameters["Status"] = Status;
        return GetSoapBody();
    }
}