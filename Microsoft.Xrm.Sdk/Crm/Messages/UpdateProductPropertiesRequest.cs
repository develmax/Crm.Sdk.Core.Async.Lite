using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class UpdateProductPropertiesRequest : OrganizationRequest
{
    public EntityCollection PropertyInstanceList
    {
        get
        {
            if (Parameters.Contains("PropertyInstanceList"))
                return (EntityCollection)Parameters["PropertyInstanceList"];
            return default(EntityCollection);
        }
        set { Parameters["PropertyInstanceList"] = value; }
    }
    public UpdateProductPropertiesRequest()
    {
        this.ResponseType = new UpdateProductPropertiesResponse();
        this.RequestName = "UpdateProductProperties";
    }
    internal override string GetRequestBody()
    {
        Parameters["PropertyInstanceList"] = PropertyInstanceList;
        return GetSoapBody();
    }
}