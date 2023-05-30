using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class GetInvoiceProductsFromOpportunityRequest : OrganizationRequest
{
    public Guid InvoiceId
    {
        get
        {
            if (Parameters.Contains("InvoiceId"))
                return (Guid)Parameters["InvoiceId"];
            return default(Guid);
        }
        set { Parameters["InvoiceId"] = value; }
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
    public GetInvoiceProductsFromOpportunityRequest()
    {
        this.ResponseType = new GetInvoiceProductsFromOpportunityResponse();
        this.RequestName = "GetInvoiceProductsFromOpportunity";
    }
    internal override string GetRequestBody()
    {
        Parameters["InvoiceId"] = InvoiceId;
        Parameters["OpportunityId"] = OpportunityId;
        return GetSoapBody();
    }
}