using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class RetrieveSharedPrincipalsAndAccessRequest : OrganizationRequest
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
    public RetrieveSharedPrincipalsAndAccessRequest()
    {
        this.ResponseType = new RetrieveSharedPrincipalsAndAccessResponse();
        this.RequestName = "RetrieveSharedPrincipalsAndAccess";
    }
    internal override string GetRequestBody()
    {
        Parameters["Target"] = Target;
        return GetSoapBody();
    }
}