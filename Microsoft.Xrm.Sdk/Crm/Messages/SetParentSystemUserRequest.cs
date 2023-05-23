using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class SetParentSystemUserRequest : OrganizationRequest
{
    public bool KeepChildUsers
    {
        get
        {
            if (Parameters.Contains("KeepChildUsers"))
                return (bool)Parameters["KeepChildUsers"];
            return default(bool);
        }
        set { Parameters["KeepChildUsers"] = value; }
    }
    public Guid ParentId
    {
        get
        {
            if (Parameters.Contains("ParentId"))
                return (Guid)Parameters["ParentId"];
            return default(Guid);
        }
        set { Parameters["ParentId"] = value; }
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
    public SetParentSystemUserRequest()
    {
        this.ResponseType = new SetParentSystemUserResponse();
        this.RequestName = "SetParentSystemUser";
    }
    internal override string GetRequestBody()
    {
        Parameters["KeepChildUsers"] = KeepChildUsers;
        Parameters["ParentId"] = ParentId;
        Parameters["UserId"] = UserId;
        return GetSoapBody();
    }
}