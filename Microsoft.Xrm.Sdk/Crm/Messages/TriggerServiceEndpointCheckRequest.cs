using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class TriggerServiceEndpointCheckRequest : OrganizationRequest
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
    public TriggerServiceEndpointCheckRequest()
    {
        this.ResponseType = new TriggerServiceEndpointCheckResponse();
        this.RequestName = "TriggerServiceEndpointCheck";
    }
    internal override string GetRequestBody()
    {
        Parameters["Entity"] = Entity;
        return GetSoapBody();
    }
}