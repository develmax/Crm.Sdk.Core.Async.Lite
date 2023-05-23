using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class LoseOpportunityRequest : OrganizationRequest
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
    public LoseOpportunityRequest()
    {
        this.ResponseType = new LoseOpportunityResponse();
        this.RequestName = "LoseOpportunity";
    }
    internal override string GetRequestBody()
    {
        Parameters["OpportunityClose"] = OpportunityClose;
        Parameters["Status"] = Status;
        return GetSoapBody();
    }
}