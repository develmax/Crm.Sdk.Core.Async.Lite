using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class AddPrincipalToQueueRequest : OrganizationRequest
{
    public Entity Principal
    {
        get
        {
            if (Parameters.Contains("Principal"))
                return (Entity)Parameters["Principal"];
            return default(Entity);
        }
        set { Parameters["Principal"] = value; }
    }
    public Guid QueueId
    {
        get
        {
            if (Parameters.Contains("QueueId"))
                return (Guid)Parameters["QueueId"];
            return default(Guid);
        }
        set { Parameters["QueueId"] = value; }
    }
    public AddPrincipalToQueueRequest()
    {
        this.ResponseType = new AddPrincipalToQueueResponse();
        this.RequestName = "AddPrincipalToQueue";
    }
    internal override string GetRequestBody()
    {
        Parameters["Principal"] = Principal;
        Parameters["QueueId"] = QueueId;
        return GetSoapBody();
    }
}