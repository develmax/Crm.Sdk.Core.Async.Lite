using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrievePrincipalAttributePrivilegesRequest : OrganizationRequest
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
    public RetrievePrincipalAttributePrivilegesRequest()
    {
        this.ResponseType = new RetrievePrincipalAttributePrivilegesResponse();
        this.RequestName = "RetrievePrincipalAttributePrivileges";
    }
    internal override string GetRequestBody()
    {
        Parameters["Principal"] = Principal;
        return GetSoapBody();
    }
}