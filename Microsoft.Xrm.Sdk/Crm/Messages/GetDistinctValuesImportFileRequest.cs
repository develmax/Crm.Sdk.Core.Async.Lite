using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class GetDistinctValuesImportFileRequest : OrganizationRequest
{
    public int columnNumber
    {
        get
        {
            if (Parameters.Contains("columnNumber"))
                return (int)Parameters["columnNumber"];
            return default(int);
        }
        set { Parameters["columnNumber"] = value; }
    }
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
    public int pageNumber
    {
        get
        {
            if (Parameters.Contains("pageNumber"))
                return (int)Parameters["pageNumber"];
            return default(int);
        }
        set { Parameters["pageNumber"] = value; }
    }
    public int recordsPerPage
    {
        get
        {
            if (Parameters.Contains("recordsPerPage"))
                return (int)Parameters["recordsPerPage"];
            return default(int);
        }
        set { Parameters["recordsPerPage"] = value; }
    }
    public GetDistinctValuesImportFileRequest()
    {
        this.ResponseType = new GetDistinctValuesImportFileResponse();
        this.RequestName = "GetDistinctValuesImportFile";
    }
    internal override string GetRequestBody()
    {
        Parameters["columnNumber"] = columnNumber;
        Parameters["ImportFileId"] = ImportFileId;
        Parameters["pageNumber"] = pageNumber;
        Parameters["recordsPerPage"] = recordsPerPage;
        return GetSoapBody();
    }
}