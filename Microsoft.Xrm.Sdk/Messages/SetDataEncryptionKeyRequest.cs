namespace Microsoft.Xrm.Sdk.Messages;

public sealed class SetDataEncryptionKeyRequest : OrganizationRequest
{
    public string EncryptionKey
    {
        get
        {
            if (Parameters.Contains("EncryptionKey"))
                return (string)Parameters["EncryptionKey"];
            return default(string);
        }
        set { Parameters["EncryptionKey"] = value; }
    }
    public bool ChangeEncryptionKey
    {
        get
        {
            if (Parameters.Contains("ChangeEncryptionKey"))
                return (bool)Parameters["ChangeEncryptionKey"];
            return default(bool);
        }
        set { Parameters["ChangeEncryptionKey"] = value; }
    }
    public SetDataEncryptionKeyRequest()
    {
        this.ResponseType = new SetDataEncryptionKeyResponse();
        this.RequestName = "SetDataEncryptionKey";
    }
    internal override string GetRequestBody()
    {
        Parameters["EncryptionKey"] = EncryptionKey;
        Parameters["ChangeEncryptionKey"] = ChangeEncryptionKey;
        return GetSoapBody();
    }
}