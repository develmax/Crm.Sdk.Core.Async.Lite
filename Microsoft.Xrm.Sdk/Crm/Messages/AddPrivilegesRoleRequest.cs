using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class AddPrivilegesRoleRequest : OrganizationRequest
{
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
    public AddPrivilegesRoleRequest()
    {
        this.ResponseType = new AddPrivilegesRoleResponse();
        this.RequestName = "AddPrivilegesRole";
    }
    internal override string GetRequestBody()
    {
        Parameters["Privileges"] = Privileges;
        Parameters["RoleId"] = RoleId;
        return GetSoapBody();
    }
}