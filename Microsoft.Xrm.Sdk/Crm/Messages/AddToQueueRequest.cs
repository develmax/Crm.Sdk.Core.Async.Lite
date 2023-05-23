using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class AddToQueueRequest : OrganizationRequest
{
    public Guid DestinationQueueId
    {
        get
        {
            if (Parameters.Contains("DestinationQueueId"))
                return (Guid)Parameters["DestinationQueueId"];
            return default(Guid);
        }
        set { Parameters["DestinationQueueId"] = value; }
    }
    public Guid SourceQueueId
    {
        get
        {
            if (Parameters.Contains("SourceQueueId"))
                return (Guid)Parameters["SourceQueueId"];
            return default(Guid);
        }
        set { Parameters["SourceQueueId"] = value; }
    }
    public EntityReference Target
    {
        get
        {
            if (Parameters.Contains("Target"))
                return (EntityReference)Parameters["Target"];
            return default(EntityReference);
        }
        set { Parameters["Target"] = value; }
    }
    public Entity QueueItemProperties
    {
        get
        {
            if (Parameters.Contains("QueueItemProperties"))
                return (Entity)Parameters["QueueItemProperties"];
            return default(Entity);
        }
        set { Parameters["QueueItemProperties"] = value; }
    }
    public AddToQueueRequest()
    {
        this.ResponseType = new AddToQueueResponse();
        this.RequestName = "AddToQueue";
    }
    internal override string GetRequestBody()
    {
        Parameters["DestinationQueueId"] = DestinationQueueId;
        Parameters["SourceQueueId"] = SourceQueueId;
        Parameters["Target"] = Target;
        Parameters["QueueItemProperties"] = QueueItemProperties;
        return GetSoapBody();
    }
}