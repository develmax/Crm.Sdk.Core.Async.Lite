using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class ExportFieldTranslationRequest : OrganizationRequest
{
    public ExportFieldTranslationRequest()
    {
        this.ResponseType = new ExportFieldTranslationResponse();
        this.RequestName = "ExportFieldTranslation";
    }
    internal override string GetRequestBody()
    {
        return GetSoapBody();
    }
}