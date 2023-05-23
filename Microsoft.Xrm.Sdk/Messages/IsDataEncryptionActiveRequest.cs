namespace Microsoft.Xrm.Sdk.Messages;

public sealed class IsDataEncryptionActiveRequest : OrganizationRequest
{
    public IsDataEncryptionActiveRequest()
    {
        this.ResponseType = new IsDataEncryptionActiveResponse();
        this.RequestName = "IsDataEncryptionActive";
    }
    internal override string GetRequestBody()
    {
        return GetSoapBody();
    }
}