using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class AddUserToRecordTeamRequest : OrganizationRequest
{
    public EntityReference Record
    {
        get
        {
            if (Parameters.Contains("Record"))
                return (EntityReference)Parameters["Record"];
            return default(EntityReference);
        }
        set { Parameters["Record"] = value; }
    }
    public Guid SystemUserId
    {
        get
        {
            if (Parameters.Contains("SystemUserId"))
                return (Guid)Parameters["SystemUserId"];
            return default(Guid);
        }
        set { Parameters["SystemUserId"] = value; }
    }
    public Guid TeamTemplateId
    {
        get
        {
            if (Parameters.Contains("TeamTemplateId"))
                return (Guid)Parameters["TeamTemplateId"];
            return default(Guid);
        }
        set { Parameters["TeamTemplateId"] = value; }
    }
    public AddUserToRecordTeamRequest()
    {
        this.ResponseType = new AddUserToRecordTeamResponse();
        this.RequestName = "AddUserToRecordTeam";
    }
    internal override string GetRequestBody()
    {
        Parameters["Record"] = Record;
        Parameters["SystemUserId"] = SystemUserId;
        Parameters["TeamTemplateId"] = TeamTemplateId;
        return GetSoapBody();
    }
}