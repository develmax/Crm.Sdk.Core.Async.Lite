using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class CloseQuoteRequest : OrganizationRequest
{
    public Entity QuoteClose
    {
        get
        {
            if (Parameters.Contains("QuoteClose"))
                return (Entity)Parameters["QuoteClose"];
            return default(Entity);
        }
        set { Parameters["QuoteClose"] = value; }
    }
    public OptionSetValue Status
    {
        get
        {
            if (Parameters.Contains("Status"))
                return (OptionSetValue)Parameters["Status"];
            return default(OptionSetValue);
        }
        set { Parameters["Status"] = value; }
    }
    public CloseQuoteRequest()
    {
        this.ResponseType = new CloseQuoteResponse();
        this.RequestName = "CloseQuote";
    }
    internal override string GetRequestBody()
    {
        Parameters["QuoteClose"] = QuoteClose;
        Parameters["Status"] = Status;
        return GetSoapBody();
    }
}