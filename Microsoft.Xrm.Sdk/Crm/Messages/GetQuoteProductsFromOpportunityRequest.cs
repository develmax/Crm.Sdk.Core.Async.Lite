using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class GetQuoteProductsFromOpportunityRequest : OrganizationRequest
{
    public Guid QuoteId
    {
        get
        {
            if (Parameters.Contains("QuoteId"))
                return (Guid)Parameters["QuoteId"];
            return default(Guid);
        }
        set { Parameters["QuoteId"] = value; }
    }
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
    public GetQuoteProductsFromOpportunityRequest()
    {
        this.ResponseType = new GetQuoteProductsFromOpportunityResponse();
        this.RequestName = "GetQuoteProductsFromOpportunity";
    }
    internal override string GetRequestBody()
    {
        Parameters["QuoteId"] = QuoteId;
        Parameters["OpportunityId"] = OpportunityId;
        return GetSoapBody();
    }
}