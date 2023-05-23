using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveProductPropertiesRequest : OrganizationRequest
{
    public EntityReference ParentObject
    {
        get
        {
            if (Parameters.Contains("ParentObject"))
                return (EntityReference)Parameters["ParentObject"];
            return default(EntityReference);
        }
        set { Parameters["ParentObject"] = value; }
    }
    public RetrieveProductPropertiesRequest()
    {
        this.ResponseType = new RetrieveProductPropertiesResponse();
        this.RequestName = "RetrieveProductProperties";
    }
    internal override string GetRequestBody()
    {
        Parameters["ParentObject"] = ParentObject;
        return GetSoapBody();
    }
}