using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class WinOpportunityRequest : OrganizationRequest
{
    public Entity OpportunityClose
    {
        get
        {
            if (Parameters.Contains("OpportunityClose"))
                return (Entity)Parameters["OpportunityClose"];
            return default(Entity);
        }
        set { Parameters["OpportunityClose"] = value; }
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
    public WinOpportunityRequest()
    {
        this.ResponseType = new WinOpportunityResponse();
        this.RequestName = "WinOpportunity";
    }
    internal override string GetRequestBody()
    {
        Parameters["OpportunityClose"] = OpportunityClose;
        Parameters["Status"] = Status;
        return GetSoapBody();
    }
}