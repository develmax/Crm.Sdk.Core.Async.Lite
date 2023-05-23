using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class SetBusinessSystemUserRequest : OrganizationRequest
{
    public Guid BusinessId
    {
        get
        {
            if (Parameters.Contains("BusinessId"))
                return (Guid)Parameters["BusinessId"];
            return default(Guid);
        }
        set { Parameters["BusinessId"] = value; }
    }
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
    public SetBusinessSystemUserRequest()
    {
        this.ResponseType = new SetBusinessSystemUserResponse();
        this.RequestName = "SetBusinessSystemUser";
    }
    internal override string GetRequestBody()
    {
        Parameters["BusinessId"] = BusinessId;
        Parameters["ReassignPrincipal"] = ReassignPrincipal;
        Parameters["UserId"] = UserId;
        return GetSoapBody();
    }
}