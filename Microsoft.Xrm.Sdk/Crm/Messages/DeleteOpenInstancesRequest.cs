using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class DeleteOpenInstancesRequest : OrganizationRequest
{
    public DateTime SeriesEndDate
    {
        get
        {
            if (Parameters.Contains("SeriesEndDate"))
                return (DateTime)Parameters["SeriesEndDate"];
            return default(DateTime);
        }
        set { Parameters["SeriesEndDate"] = value; }
    }
    public int StateOfPastInstances
    {
        get
        {
            if (Parameters.Contains("StateOfPastInstances"))
                return (int)Parameters["StateOfPastInstances"];
            return default(int);
        }
        set { Parameters["StateOfPastInstances"] = value; }
    }
    public Entity Target
    {
        get
        {
            if (Parameters.Contains("Target"))
                return (Entity)Parameters["Target"];
            return default(Entity);
        }
        set { Parameters["Target"] = value; }
    }
    public DeleteOpenInstancesRequest()
    {
        this.ResponseType = new DeleteOpenInstancesResponse();
        this.RequestName = "DeleteOpenInstances";
    }
    internal override string GetRequestBody()
    {
        Parameters["SeriesEndDate"] = SeriesEndDate;
        Parameters["StateOfPastInstances"] = StateOfPastInstances;
        Parameters["Target"] = Target;
        return GetSoapBody();
    }
}