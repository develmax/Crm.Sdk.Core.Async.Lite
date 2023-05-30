using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class ModifyAccessRequest : OrganizationRequest
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
    public ModifyAccessRequest()
    {
        this.ResponseType = new ModifyAccessResponse();
        this.RequestName = "ModifyAccess";
    }
    internal override string GetRequestBody()
    {
        Parameters["Target"] = Target;
        Parameters["PrincipalAccess"] = PrincipalAccess;
        return GetSoapBody();
    }
}