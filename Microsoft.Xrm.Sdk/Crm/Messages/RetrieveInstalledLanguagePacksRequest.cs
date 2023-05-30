using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class RetrieveInstalledLanguagePacksRequest : OrganizationRequest
{
    public RetrieveInstalledLanguagePacksRequest()
    {
        this.ResponseType = new RetrieveInstalledLanguagePacksResponse();
        this.RequestName = "RetrieveInstalledLanguagePacks";
    }
    internal override string GetRequestBody()
    {
        return GetSoapBody();
    }
}