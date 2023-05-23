using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class GetHeaderColumnsImportFileRequest : OrganizationRequest
{
    public Guid ImportFileId
    {
        get
        {
            if (Parameters.Contains("ImportFileId"))
                return (Guid)Parameters["ImportFileId"];
            return default(Guid);
        }
        set { Parameters["ImportFileId"] = value; }
    }
    public GetHeaderColumnsImportFileRequest()
    {
        this.ResponseType = new GetHeaderColumnsImportFileResponse();
        this.RequestName = "GetHeaderColumnsImportFile";
    }
    internal override string GetRequestBody()
    {
        Parameters["ImportFileId"] = ImportFileId;
        return GetSoapBody();
    }
}