using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class CloseIncidentRequest : OrganizationRequest
{
    public Entity IncidentResolution
    {
        get
        {
            if (Parameters.Contains("IncidentResolution"))
                return (Entity)Parameters["IncidentResolution"];
            return default(Entity);
        }
        set { Parameters["IncidentResolution"] = value; }
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
    public CloseIncidentRequest()
    {
        this.ResponseType = new CloseIncidentResponse();
        this.RequestName = "CloseIncident";
    }
    internal override string GetRequestBody()
    {
        Parameters["IncidentResolution"] = IncidentResolution;
        Parameters["Status"] = Status;
        return GetSoapBody();
    }
}