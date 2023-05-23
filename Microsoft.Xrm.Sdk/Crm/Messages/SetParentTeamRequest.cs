using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class SetParentTeamRequest : OrganizationRequest
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
    public SetParentTeamRequest()
    {
        this.ResponseType = new SetParentTeamResponse();
        this.RequestName = "SetParentTeam";
    }
    internal override string GetRequestBody()
    {
        Parameters["BusinessId"] = BusinessId;
        Parameters["TeamId"] = TeamId;
        return GetSoapBody();
    }
}