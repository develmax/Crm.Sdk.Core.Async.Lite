using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class RemovePrivilegeRoleRequest : OrganizationRequest
{
    public Guid RoleId
    {
        get
        {
            if (Parameters.Contains("RoleId"))
                return (Guid)Parameters["RoleId"];
            return default(Guid);
        }
        set { Parameters["RoleId"] = value; }
    }
    public Guid PrivilegeId
    {
        get
        {
            if (Parameters.Contains("PrivilegeId"))
                return (Guid)Parameters["PrivilegeId"];
            return default(Guid);
        }
        set { Parameters["PrivilegeId"] = value; }
    }
    public RemovePrivilegeRoleRequest()
    {
        this.ResponseType = new RemovePrivilegeRoleResponse();
        this.RequestName = "RemovePrivilegeRole";
    }
    internal override string GetRequestBody()
    {
        Parameters["RoleId"] = RoleId;
        Parameters["PrivilegeId"] = PrivilegeId;
        return GetSoapBody();
    }
}