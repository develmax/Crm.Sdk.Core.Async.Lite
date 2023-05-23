using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RevokeAccessRequest : OrganizationRequest
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
    public EntityReference Revokee
    {
        get
        {
            if (Parameters.Contains("Revokee"))
                return (EntityReference)Parameters["Revokee"];
            return default(EntityReference);
        }
        set { Parameters["Revokee"] = value; }
    }
    public RevokeAccessRequest()
    {
        this.ResponseType = new RevokeAccessResponse();
        this.RequestName = "RevokeAccess";
    }
    internal override string GetRequestBody()
    {
        Parameters["Target"] = Target;
        Parameters["Revokee"] = Revokee;
        return GetSoapBody();
    }
}