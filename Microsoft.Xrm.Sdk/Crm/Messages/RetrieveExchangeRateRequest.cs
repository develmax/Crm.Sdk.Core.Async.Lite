using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveExchangeRateRequest : OrganizationRequest
{
    public Guid TransactionCurrencyId
    {
        get
        {
            if (Parameters.Contains("TransactionCurrencyId"))
                return (Guid)Parameters["TransactionCurrencyId"];
            return default(Guid);
        }
        set { Parameters["TransactionCurrencyId"] = value; }
    }
    public RetrieveExchangeRateRequest()
    {
        this.ResponseType = new RetrieveExchangeRateResponse();
        this.RequestName = "RetrieveExchangeRate";
    }
    internal override string GetRequestBody()
    {
        Parameters["TransactionCurrencyId"] = TransactionCurrencyId;
        return GetSoapBody();
    }
}