using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class ImportFieldTranslationRequest : OrganizationRequest
{
    public byte[] TranslationFile
    {
        get
        {
            if (Parameters.Contains("TranslationFile"))
                return (byte[])Parameters["TranslationFile"];
            return default(byte[]);
        }
        set { Parameters["TranslationFile"] = value; }
    }
    public ImportFieldTranslationRequest()
    {
        this.ResponseType = new ImportFieldTranslationResponse();
        this.RequestName = "ImportFieldTranslation";
    }
    internal override string GetRequestBody()
    {
        Parameters["TranslationFile"] = TranslationFile;
        return GetSoapBody();
    }
}