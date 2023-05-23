using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RevertProductRequest : OrganizationRequest
{
    public EntityReference Target
    {
        get
        {
            if (Parameters.Contains("Target"))
                return (EntityReference)Parameters["Target"];
            return default(EntityReference);
        }
        set { Parameters["Target"] = value; }
    }
    public RevertProductRequest()
    {
        this.ResponseType = new RevertProductResponse();
        this.RequestName = "RevertProduct";
    }
    internal override string GetRequestBody()
    {
        Parameters["Target"] = Target;
        return GetSoapBody();
    }
}