using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RescheduleRequest : OrganizationRequest
{
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
    public bool ReturnNotifications
    {
        get
        {
            if (Parameters.Contains("ReturnNotifications"))
                return (bool)Parameters["ReturnNotifications"];
            return default(bool);
        }
        set { Parameters["ReturnNotifications"] = value; }
    }
    public RescheduleRequest()
    {
        this.ResponseType = new RescheduleResponse();
        this.RequestName = "Reschedule";
    }
    internal override string GetRequestBody()
    {
        Parameters["Target"] = Target;
        Parameters["ReturnNotifications"] = ReturnNotifications;
        return GetSoapBody();
    }
}