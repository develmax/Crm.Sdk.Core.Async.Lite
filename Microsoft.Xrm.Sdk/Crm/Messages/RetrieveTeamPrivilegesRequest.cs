using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveTeamPrivilegesRequest : OrganizationRequest
{
    public Guid TeamId
    {
        get
        {
            if (Parameters.Contains("TeamId"))
                return (Guid)Parameters["TeamId"];
            return default(Guid);
        }
        set { Parameters["TeamId"] = value; }
    }
    public RetrieveTeamPrivilegesRequest()
    {
        this.ResponseType = new RetrieveTeamPrivilegesResponse();
        this.RequestName = "RetrieveTeamPrivileges";
    }
    internal override string GetRequestBody()
    {
        Parameters["TeamId"] = TeamId;
        return GetSoapBody();
    }
}