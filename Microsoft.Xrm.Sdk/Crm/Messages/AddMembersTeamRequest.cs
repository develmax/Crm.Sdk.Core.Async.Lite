using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class AddMembersTeamRequest : OrganizationRequest
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
    public Guid[] MemberIds
    {
        get
        {
            if (Parameters.Contains("MemberIds"))
                return (Guid[])Parameters["MemberIds"];
            return default(Guid[]);
        }
        set { Parameters["MemberIds"] = value; }
    }
    public AddMembersTeamRequest()
    {
        this.ResponseType = new AddMembersTeamResponse();
        this.RequestName = "AddMembersTeam";
    }
    internal override string GetRequestBody()
    {
        Parameters["TeamId"] = TeamId;
        Parameters["MemberIds"] = MemberIds;
        return GetSoapBody();
    }
}