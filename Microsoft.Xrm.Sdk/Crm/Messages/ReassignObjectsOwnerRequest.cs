using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class ReassignObjectsOwnerRequest : OrganizationRequest
{
    public EntityReference FromPrincipal
    {
        get
        {
            if (Parameters.Contains("FromPrincipal"))
                return (EntityReference)Parameters["FromPrincipal"];
            return default(EntityReference);
        }
        set { Parameters["FromPrincipal"] = value; }
    }
    public EntityReference ToPrincipal
    {
        get
        {
            if (Parameters.Contains("ToPrincipal"))
                return (EntityReference)Parameters["ToPrincipal"];
            return default(EntityReference);
        }
        set { Parameters["ToPrincipal"] = value; }
    }
    public ReassignObjectsOwnerRequest()
    {
        this.ResponseType = new ReassignObjectsOwnerResponse();
        this.RequestName = "ReassignObjectsOwner";
    }
    internal override string GetRequestBody()
    {
        Parameters["FromPrincipal"] = FromPrincipal;
        Parameters["ToPrincipal"] = ToPrincipal;
        return GetSoapBody();
    }
}