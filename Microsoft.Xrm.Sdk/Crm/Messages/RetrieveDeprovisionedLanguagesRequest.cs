using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveDeprovisionedLanguagesRequest : OrganizationRequest
{
    public RetrieveDeprovisionedLanguagesRequest()
    {
        this.ResponseType = new RetrieveDeprovisionedLanguagesResponse();
        this.RequestName = "RetrieveDeprovisionedLanguages";
    }
    internal override string GetRequestBody()
    {
        return GetSoapBody();
    }
}