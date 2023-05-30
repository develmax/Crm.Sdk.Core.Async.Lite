using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class RetrieveRolePrivilegesRoleRequest : OrganizationRequest
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
    public RetrieveRolePrivilegesRoleRequest()
    {
        this.ResponseType = new RetrieveRolePrivilegesRoleResponse();
        this.RequestName = "RetrieveRolePrivilegesRole";
    }
    internal override string GetRequestBody()
    {
        Parameters["RoleId"] = RoleId;
        return GetSoapBody();
    }
}