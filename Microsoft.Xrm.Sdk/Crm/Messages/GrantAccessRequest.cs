using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class GrantAccessRequest : OrganizationRequest
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
    public PrincipalAccess PrincipalAccess
    {
        get
        {
            if (Parameters.Contains("PrincipalAccess"))
                return (PrincipalAccess)Parameters["PrincipalAccess"];
            return default(PrincipalAccess);
        }
        set { Parameters["PrincipalAccess"] = value; }
    }
    public GrantAccessRequest()
    {
        this.ResponseType = new GrantAccessResponse();
        this.RequestName = "GrantAccess";
    }
    internal override string GetRequestBody()
    {
        Parameters["Target"] = Target;
        Parameters["PrincipalAccess"] = PrincipalAccess;
        return GetSoapBody();
    }
}