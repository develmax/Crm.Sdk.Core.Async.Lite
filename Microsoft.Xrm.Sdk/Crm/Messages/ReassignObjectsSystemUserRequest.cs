using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class ReassignObjectsSystemUserRequest : OrganizationRequest
{
    public EntityReference ReassignPrincipal
    {
        get
        {
            if (Parameters.Contains("ReassignPrincipal"))
                return (EntityReference)Parameters["ReassignPrincipal"];
            return default(EntityReference);
        }
        set { Parameters["ReassignPrincipal"] = value; }
    }
    public Guid UserId
    {
        get
        {
            if (Parameters.Contains("UserId"))
                return (Guid)Parameters["UserId"];
            return default(Guid);
        }
        set { Parameters["UserId"] = value; }
    }
    public ReassignObjectsSystemUserRequest()
    {
        this.ResponseType = new ReassignObjectsSystemUserResponse();
        this.RequestName = "ReassignObjectsSystemUser";
    }
    internal override string GetRequestBody()
    {
        Parameters["ReassignPrincipal"] = ReassignPrincipal;
        Parameters["UserId"] = UserId;
        return GetSoapBody();
    }
}