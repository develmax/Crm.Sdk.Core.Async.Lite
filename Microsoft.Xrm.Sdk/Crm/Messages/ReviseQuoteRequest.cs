using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class ReviseQuoteRequest : OrganizationRequest
{
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
    public ReviseQuoteRequest()
    {
        this.ResponseType = new ReviseQuoteResponse();
        this.RequestName = "ReviseQuote";
    }
    internal override string GetRequestBody()
    {
        Parameters["ColumnSet"] = ColumnSet;
        Parameters["QuoteId"] = QuoteId;
        return GetSoapBody();
    }
}