using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class ConvertOwnerTeamToAccessTeamRequest : OrganizationRequest
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
    public ConvertOwnerTeamToAccessTeamRequest()
    {
        this.ResponseType = new ConvertOwnerTeamToAccessTeamResponse();
        this.RequestName = "ConvertOwnerTeamToAccessTeam";
    }
    internal override string GetRequestBody()
    {
        Parameters["TeamId"] = TeamId;
        return GetSoapBody();
    }
}