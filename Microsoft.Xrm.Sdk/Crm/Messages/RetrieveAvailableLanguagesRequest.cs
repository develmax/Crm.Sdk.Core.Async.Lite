using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class RetrieveAvailableLanguagesRequest : OrganizationRequest
{
    public RetrieveAvailableLanguagesRequest()
    {
        this.ResponseType = new RetrieveAvailableLanguagesResponse();
        this.RequestName = "RetrieveAvailableLanguages";
    }
    internal override string GetRequestBody()
    {
        return GetSoapBody();
    }
}