using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveParsedDataImportFileRequest : OrganizationRequest
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
    public PagingInfo PagingInfo
    {
        get
        {
            if (Parameters.Contains("PagingInfo"))
                return (PagingInfo)Parameters["PagingInfo"];
            return default(PagingInfo);
        }
        set { Parameters["PagingInfo"] = value; }
    }
    public RetrieveParsedDataImportFileRequest()
    {
        this.ResponseType = new RetrieveParsedDataImportFileResponse();
        this.RequestName = "RetrieveParsedDataImportFile";
    }
    internal override string GetRequestBody()
    {
        Parameters["ImportFileId"] = ImportFileId;
        Parameters["PagingInfo"] = PagingInfo;
        return GetSoapBody();
    }
}