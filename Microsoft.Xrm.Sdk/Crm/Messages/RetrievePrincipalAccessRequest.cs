using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrievePrincipalAccessRequest : OrganizationRequest
{
    public EntityReference Principal
    {
        get
        {
            if (Parameters.Contains("Principal"))
                return (EntityReference)Parameters["Principal"];
            return default(EntityReference);
        }
        set { Parameters["Principal"] = value; }
    }
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
    public RetrievePrincipalAccessRequest()
    {
        this.ResponseType = new RetrievePrincipalAccessResponse();
        this.RequestName = "RetrievePrincipalAccess";
    }
    internal override string GetRequestBody()
    {
        Parameters["Principal"] = Principal;
        Parameters["Target"] = Target;
        return GetSoapBody();
    }
}