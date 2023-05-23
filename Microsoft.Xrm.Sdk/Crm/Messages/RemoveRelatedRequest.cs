using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RemoveRelatedRequest : OrganizationRequest
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
    public RemoveRelatedRequest()
    {
        this.ResponseType = new RemoveRelatedResponse();
        this.RequestName = "RemoveRelated";
    }
    internal override string GetRequestBody()
    {
        Parameters["Target"] = Target;
        return GetSoapBody();
    }
}