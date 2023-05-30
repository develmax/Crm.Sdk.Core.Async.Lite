using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class ImportTranslationRequest : OrganizationRequest
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
    public Guid ImportJobId
    {
        get
        {
            if (Parameters.Contains("ImportJobId"))
                return (Guid)Parameters["ImportJobId"];
            return default(Guid);
        }
        set { Parameters["ImportJobId"] = value; }
    }
    public ImportTranslationRequest()
    {
        this.ResponseType = new ImportTranslationResponse();
        this.RequestName = "ImportTranslation";
    }
    internal override string GetRequestBody()
    {
        Parameters["TranslationFile"] = TranslationFile;
        Parameters["ImportJobId"] = ImportJobId;
        return GetSoapBody();
    }
}