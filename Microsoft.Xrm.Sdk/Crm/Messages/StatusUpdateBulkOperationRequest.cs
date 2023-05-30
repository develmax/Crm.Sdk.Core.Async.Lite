using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class StatusUpdateBulkOperationRequest : OrganizationRequest
{
    public Guid BulkOperationId
    {
        get
        {
            if (Parameters.Contains("BulkOperationId"))
                return (Guid)Parameters["BulkOperationId"];
            return default(Guid);
        }
        set { Parameters["BulkOperationId"] = value; }
    }
    public int FailureCount
    {
        get
        {
            if (Parameters.Contains("FailureCount"))
                return (int)Parameters["FailureCount"];
            return default(int);
        }
        set { Parameters["FailureCount"] = value; }
    }
    public int SuccessCount
    {
        get
        {
            if (Parameters.Contains("SuccessCount"))
                return (int)Parameters["SuccessCount"];
            return default(int);
        }
        set { Parameters["SuccessCount"] = value; }
    }
    public StatusUpdateBulkOperationRequest()
    {
        this.ResponseType = new StatusUpdateBulkOperationResponse();
        this.RequestName = "StatusUpdateBulkOperation";
    }
    internal override string GetRequestBody()
    {
        Parameters["BulkOperationId"] = BulkOperationId;
        Parameters["FailureCount"] = FailureCount;
        Parameters["SuccessCount"] = SuccessCount;
        return GetSoapBody();
    }
}