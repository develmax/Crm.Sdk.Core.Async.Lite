using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RouteToRequest : OrganizationRequest
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

    public RouteToRequest()
    {
        this.ResponseType = new RouteToResponse();
        this.RequestName = "RouteTo";
    }
    internal override string GetRequestBody()
    {
        Parameters["QueueItemId"] = QueueItemId;
        Parameters["Target"] = Target;
        return GetSoapBody();
    }
}