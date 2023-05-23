using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class GenerateSocialProfileRequest : OrganizationRequest
{
    public Entity Entity
    {
        get
        {
            if (Parameters.Contains("Entity"))
                return (Entity)Parameters["Entity"];
            return default(Entity);
        }
        set { Parameters["OpportunityId"] = value; }
    }
    public GenerateSocialProfileRequest()
    {
        this.ResponseType = new GenerateSocialProfileResponse();
        this.RequestName = "GenerateSocialProfile";
    }
    internal override string GetRequestBody()
    {
        Parameters["Entity"] = Entity;
        return GetSoapBody();
    }
}