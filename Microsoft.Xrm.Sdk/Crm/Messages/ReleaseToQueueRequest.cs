using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class ReleaseToQueueRequest : OrganizationRequest
{
    public Guid QueueItemId
    {
        get
        {
            if (Parameters.Contains("QueueItemId"))
                return (Guid)Parameters["QueueItemId"];
            return default(Guid);
        }
        set { Parameters["QueueItemId"] = value; }
    }
    public ReleaseToQueueRequest()
    {
        this.ResponseType = new ReleaseToQueueResponse();
        this.RequestName = "ReleaseToQueue";
    }
    internal override string GetRequestBody()
    {
        Parameters["QueueItemId"] = QueueItemId;
        return GetSoapBody();
    }
}