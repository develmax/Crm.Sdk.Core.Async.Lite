using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class ImportRecordsImportRequest : OrganizationRequest
{
    public Guid ImportId
    {
        get
        {
            if (Parameters.Contains("ImportId"))
                return (Guid)Parameters["ImportId"];
            return default(Guid);
        }
        set { Parameters["ImportId"] = value; }
    }
    public ImportRecordsImportRequest()
    {
        this.ResponseType = new ImportRecordsImportResponse();
        this.RequestName = "ImportRecordsImport";
    }
    internal override string GetRequestBody()
    {
        Parameters["ImportId"] = ImportId;
        return GetSoapBody();
    }
}