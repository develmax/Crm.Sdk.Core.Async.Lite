using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class AddRecurrenceRequest : OrganizationRequest
{
    public Guid AppointmentId
    {
        get
        {
            if (Parameters.Contains("AppointmentId"))
                return (Guid)Parameters["AppointmentId"];
            return default(Guid);
        }
        set { Parameters["AppointmentId"] = value; }
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
    public AddRecurrenceRequest()
    {
        this.ResponseType = new AddRecurrenceResponse();
        this.RequestName = "AddRecurrence";
    }
    internal override string GetRequestBody()
    {
        Parameters["AppointmentId"] = AppointmentId;
        Parameters["Target"] = Target;
        return GetSoapBody();
    }
}