using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class GetDecryptionKeyRequest : OrganizationRequest
{
    public GetDecryptionKeyRequest()
    {
        this.ResponseType = new GetDecryptionKeyResponse();
        this.RequestName = "GetDecryptionKey";
    }
    internal override string GetRequestBody()
    {
        return GetSoapBody();
    }
}