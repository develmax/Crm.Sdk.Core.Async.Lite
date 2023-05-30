using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class ReplacePrivilegesRoleRequest : OrganizationRequest
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
    public RolePrivilege[] Privileges
    {
        get
        {
            if (Parameters.Contains("Privileges"))
                return (RolePrivilege[])Parameters["Privileges"];
            return default(RolePrivilege[]);
        }
        set { Parameters["Privileges"] = value; }
    }
    public ReplacePrivilegesRoleRequest()
    {
        this.ResponseType = new ReplacePrivilegesRoleResponse();
        this.RequestName = "ReplacePrivilegesRole";
    }
    internal override string GetRequestBody()
    {
        Parameters["RoleId"] = RoleId;
        Parameters["Privileges"] = Privileges;
        return GetSoapBody();
    }
}