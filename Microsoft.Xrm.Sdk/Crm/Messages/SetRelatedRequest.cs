using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class SetRelatedRequest : OrganizationRequest
{
    public EntityReference[] Target
    {
        get
        {
            if (Parameters.Contains("Target"))
                return (EntityReference[])Parameters["Target"];
            return default(EntityReference[]);
        }
        set { Parameters["Target"] = value; }
    }
    public SetRelatedRequest()
    {
        this.ResponseType = new SetRelatedResponse();
        this.RequestName = "SetRelated";
    }
    internal override string GetRequestBody()
    {
        Parameters["Target"] = Target;
        return GetSoapBody();
    }
}