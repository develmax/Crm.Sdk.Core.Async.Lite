using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RemoveMemberListRequest : OrganizationRequest
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
    public RemoveMemberListRequest()
    {
        this.ResponseType = new RemoveMemberListResponse();
        this.RequestName = "RemoveMemberList";
    }
    internal override string GetRequestBody()
    {
        Parameters["EntityId"] = EntityId;
        Parameters["ListId"] = ListId;
        return GetSoapBody();
    }
}