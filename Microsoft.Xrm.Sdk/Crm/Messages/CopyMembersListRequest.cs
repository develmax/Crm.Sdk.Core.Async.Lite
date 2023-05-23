using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class CopyMembersListRequest : OrganizationRequest
{
    public Guid SourceListId
    {
        get
        {
            if (Parameters.Contains("SourceListId"))
                return (Guid)Parameters["SourceListId"];
            return default(Guid);
        }
        set { Parameters["SourceListId"] = value; }
    }
    public Guid TargetListId
    {
        get
        {
            if (Parameters.Contains("TargetListId"))
                return (Guid)Parameters["TargetListId"];
            return default(Guid);
        }
        set { Parameters["TargetListId"] = value; }
    }
    public CopyMembersListRequest()
    {
        this.ResponseType = new CopyMembersListResponse();
        this.RequestName = "CopyMembersList";
    }
    internal override string GetRequestBody()
    {
        Parameters["SourceListId"] = SourceListId;
        Parameters["TargetListId"] = TargetListId;
        return GetSoapBody();
    }
}