using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveFormattedImportJobResultsRequest : OrganizationRequest
{
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
    public RetrieveFormattedImportJobResultsRequest()
    {
        this.ResponseType = new RetrieveFormattedImportJobResultsResponse();
        this.RequestName = "RetrieveFormattedImportJobResults";
    }
    internal override string GetRequestBody()
    {
        Parameters["ImportJobId"] = ImportJobId;
        return GetSoapBody();
    }
}