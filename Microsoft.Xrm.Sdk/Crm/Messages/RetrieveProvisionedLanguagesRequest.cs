using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class RetrieveProvisionedLanguagesRequest : OrganizationRequest
{
    public RetrieveProvisionedLanguagesRequest()
    {
        this.ResponseType = new RetrieveProvisionedLanguagesResponse();
        this.RequestName = "RetrieveProvisionedLanguages";
    }
    internal override string GetRequestBody()
    {
        return GetSoapBody();
    }
}