using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class LockSalesOrderPricingRequest : OrganizationRequest
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
    public LockSalesOrderPricingRequest()
    {
        this.ResponseType = new LockSalesOrderPricingResponse();
        this.RequestName = "LockSalesOrderPricing";
    }
    internal override string GetRequestBody()
    {
        Parameters["SalesOrderId"] = SalesOrderId;
        return GetSoapBody();
    }
}