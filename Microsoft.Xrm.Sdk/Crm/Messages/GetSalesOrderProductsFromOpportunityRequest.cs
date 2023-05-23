using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class GetSalesOrderProductsFromOpportunityRequest : OrganizationRequest
{
    public Guid SalesOrderId
    {
        get
        {
            if (Parameters.Contains("SalesOrderId"))
                return (Guid)Parameters["SalesOrderId"];
            return default(Guid);
        }
        set { Parameters["SalesOrderId"] = value; }
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
    public GetSalesOrderProductsFromOpportunityRequest()
    {
        this.ResponseType = new GetSalesOrderProductsFromOpportunityResponse();
        this.RequestName = "GetSalesOrderProductsFromOpportunity";
    }
    internal override string GetRequestBody()
    {
        Parameters["SalesOrderId"] = SalesOrderId;
        Parameters["OpportunityId"] = OpportunityId;
        return GetSoapBody();
    }
}