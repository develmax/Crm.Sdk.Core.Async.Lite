using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class RetrieveMembersTeamRequest : OrganizationRequest
{
    public Guid EntityId
    {
        get
        {
            if (Parameters.Contains("EntityId"))
                return (Guid)Parameters["EntityId"];
            return default(Guid);
        }
        set { Parameters["EntityId"] = value; }
    }
    public ColumnSet MemberColumnSet
    {
        get
        {
            if (Parameters.Contains("MemberColumnSet"))
                return (ColumnSet)Parameters["MemberColumnSet"];
            return default(ColumnSet);
        }
        set { Parameters["MemberColumnSet"] = value; }
    }
    public RetrieveMembersTeamRequest()
    {
        this.ResponseType = new RetrieveMembersTeamResponse();
        this.RequestName = "RetrieveMembersTeam";
    }
    internal override string GetRequestBody()
    {
        Parameters["EntityId"] = EntityId;
        Parameters["MemberColumnSet"] = MemberColumnSet;
        return GetSoapBody();
    }
}