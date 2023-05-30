using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class AddListMembersListRequest : OrganizationRequest
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
    public AddListMembersListRequest()
    {
        this.ResponseType = new AddListMembersListResponse();
        this.RequestName = "AddListMembersList";
    }
    internal override string GetRequestBody()
    {
        Parameters["ListId"] = ListId;
        Parameters["MemberIds"] = MemberIds;
        return GetSoapBody();
    }
}