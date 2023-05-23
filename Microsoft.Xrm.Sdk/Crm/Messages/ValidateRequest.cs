using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class ValidateRequest : OrganizationRequest
{
    public EntityCollection Activities
    {
        get
        {
            if (Parameters.Contains("Activities"))
                return (EntityCollection)Parameters["Activities"];
            return default(EntityCollection);
        }
        set { Parameters["Activities"] = value; }
    }
    public ValidateRequest()
    {
        this.ResponseType = new ValidateResponse();
        this.RequestName = "Validate";
    }
    internal override string GetRequestBody()
    {
        Parameters["Activities"] = Activities;
        return GetSoapBody();
    }
}