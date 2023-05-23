using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class SetStateRequest : OrganizationRequest
{
    public EntityReference EntityMoniker
    {
        get
        {
            if (Parameters.Contains("EntityMoniker"))
                return (EntityReference)Parameters["EntityMoniker"];
            return default(EntityReference);
        }
        set { Parameters["EntityMoniker"] = value; }
    }
    public OptionSetValue State
    {
        get
        {
            if (Parameters.Contains("State"))
                return (OptionSetValue)Parameters["State"];
            return default(OptionSetValue);
        }
        set { Parameters["State"] = value; }
    }
    public OptionSetValue Status
    {
        get
        {
            if (Parameters.Contains("Status"))
                return (OptionSetValue)Parameters["Status"];
            return default(OptionSetValue);
        }
        set { Parameters["Status"] = value; }
    }
    public SetStateRequest()
    {
        this.ResponseType = new SetStateResponse();
        this.RequestName = "SetState";
    }
    internal override string GetRequestBody()
    {
        Parameters["EntityMoniker"] = EntityMoniker;
        Parameters["State"] = State;
        Parameters["Status"] = Status;
        return GetSoapBody();
    }
}