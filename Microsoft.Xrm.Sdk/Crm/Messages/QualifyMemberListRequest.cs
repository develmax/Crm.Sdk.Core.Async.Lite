using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class QualifyMemberListRequest : OrganizationRequest
{
    public Guid ListId
    {
        get
        {
            if (Parameters.Contains("ListId"))
                return (Guid)Parameters["ListId"];
            return default(Guid);
        }
        set { Parameters["ListId"] = value; }
    }
    public Guid[] MembersId
    {
        get
        {
            if (Parameters.Contains("MembersId"))
                return (Guid[])Parameters["MembersId"];
            return default(Guid[]);
        }
        set { Parameters["MembersId"] = value; }
    }
    public bool OverrideorRemove
    {
        get
        {
            if (Parameters.Contains("OverrideorRemove"))
                return (bool)Parameters["OverrideorRemove"];
            return default(bool);
        }
        set { Parameters["OverrideorRemove"] = value; }
    }
    public QualifyMemberListRequest()
    {
        this.ResponseType = new QualifyMemberListResponse();
        this.RequestName = "QualifyMemberList";
    }
    internal override string GetRequestBody()
    {
        Parameters["ListId"] = ListId;
        Parameters["MembersId"] = MembersId;
        Parameters["OverrideorRemove"] = OverrideorRemove;
        return GetSoapBody();
    }
}