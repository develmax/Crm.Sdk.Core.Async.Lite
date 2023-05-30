using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class WinQuoteRequest : OrganizationRequest
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
    public WinQuoteRequest()
    {
        this.ResponseType = new WinQuoteResponse();
        this.RequestName = "WinQuote";
    }
    internal override string GetRequestBody()
    {
        Parameters["QuoteClose"] = QuoteClose;
        Parameters["Status"] = Status;
        return GetSoapBody();
    }
}