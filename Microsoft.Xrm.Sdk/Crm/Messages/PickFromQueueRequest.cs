using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class PickFromQueueRequest : OrganizationRequest
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
    public bool RemoveQueueItem
    {
        get
        {
            if (Parameters.Contains("RemoveQueueItem"))
                return (bool)Parameters["RemoveQueueItem"];
            return default(bool);
        }
        set { Parameters["RemoveQueueItem"] = value; }
    }
    public Guid WorkerId
    {
        get
        {
            if (Parameters.Contains("WorkerId"))
                return (Guid)Parameters["WorkerId"];
            return default(Guid);
        }
        set { Parameters["WorkerId"] = value; }
    }
    public PickFromQueueRequest()
    {
        this.ResponseType = new PickFromQueueResponse();
        this.RequestName = "PickFromQueue";
    }
    internal override string GetRequestBody()
    {
        Parameters["QueueItemId"] = QueueItemId;
        Parameters["RemoveQueueItem"] = RemoveQueueItem;
        Parameters["WorkerId"] = WorkerId;
        return GetSoapBody();
    }
}