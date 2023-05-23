using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class CalculateActualValueOpportunityRequest : OrganizationRequest
{
    public Guid OpportunityId
    {
        get
        {
            if (Parameters.Contains("OpportunityId"))
                return (Guid)Parameters["OpportunityId"];
            return default(Guid);
        }
        set { Parameters["OpportunityId"] = value; }
    }
    public CalculateActualValueOpportunityRequest()
    {
        this.ResponseType = new CalculateActualValueOpportunityResponse();
        this.RequestName = "CalculateActualValueOpportunity";
    }
    internal override string GetRequestBody()
    {
        Parameters["OpportunityId"] = OpportunityId;
        return GetSoapBody();
    }
}