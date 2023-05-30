using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class IsValidStateTransitionRequest : OrganizationRequest
{
    public EntityReference Entity
    {
        get
        {
            if (Parameters.Contains("Entity"))
                return (EntityReference)Parameters["Entity"];
            return default(EntityReference);
        }
        set { Parameters["Entity"] = value; }
    }
    public string NewState
    {
        get
        {
            if (Parameters.Contains("NewState"))
                return (string)Parameters["NewState"];
            return default(string);
        }
        set { Parameters["NewState"] = value; }
    }
    public int NewStatus
    {
        get
        {
            if (Parameters.Contains("NewStatus"))
                return (int)Parameters["NewStatus"];
            return default(int);
        }
        set { Parameters["NewStatus"] = value; }
    }
    public IsValidStateTransitionRequest()
    {
        this.ResponseType = new IsValidStateTransitionResponse();
        this.RequestName = "IsValidStateTransition";
    }
    internal override string GetRequestBody()
    {
        Parameters["Entity"] = Entity;
        Parameters["NewState"] = NewState;
        Parameters["NewStatus"] = NewStatus;
        return GetSoapBody();
    }
}