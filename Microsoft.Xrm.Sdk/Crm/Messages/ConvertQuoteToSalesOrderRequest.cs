using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class ConvertQuoteToSalesOrderRequest : OrganizationRequest
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
    public ColumnSet ColumnSet
    {
        get
        {
            if (Parameters.Contains("ColumnSet"))
                return (ColumnSet)Parameters["ColumnSet"];
            return default(ColumnSet);
        }
        set { Parameters["ColumnSet"] = value; }
    }
    public ConvertQuoteToSalesOrderRequest()
    {
        this.ResponseType = new ConvertQuoteToSalesOrderResponse();
        this.RequestName = "ConvertQuoteToSalesOrder";
    }
    internal override string GetRequestBody()
    {
        Parameters["QuoteId"] = QuoteId;
        Parameters["ColumnSet"] = ColumnSet;
        return GetSoapBody();
    }
}