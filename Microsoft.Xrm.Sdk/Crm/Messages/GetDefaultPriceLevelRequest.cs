using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class GetDefaultPriceLevelRequest : OrganizationRequest
{
    public string EntityName
    {
        get
        {
            if (Parameters.Contains("EntityName"))
                return (string)Parameters["EntityName"];
            return default(string);
        }
        set { Parameters["EntityName"] = value; }
    }
    public GetDefaultPriceLevelRequest()
    {
        this.ResponseType = new GetDefaultPriceLevelResponse();
        this.RequestName = "GetDefaultPriceLevel";
    }
    internal override string GetRequestBody()
    {
        Parameters["EntityName"] = EntityName;
        return GetSoapBody();
    }
}