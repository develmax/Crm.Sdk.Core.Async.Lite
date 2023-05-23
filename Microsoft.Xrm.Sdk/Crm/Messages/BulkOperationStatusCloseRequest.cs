using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class BulkOperationStatusCloseRequest : OrganizationRequest
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
    public int StatusReason
    {
        get
        {
            if (Parameters.Contains("StatusReason"))
                return (int)Parameters["StatusReason"];
            return default(int);
        }
        set { Parameters["StatusReason"] = value; }
    }
    public int ErrorCode
    {
        get
        {
            if (Parameters.Contains("ErrorCode"))
                return (int)Parameters["ErrorCode"];
            return default(int);
        }
        set { Parameters["ErrorCode"] = value; }
    }
    public BulkOperationStatusCloseRequest()
    {
        this.ResponseType = new BulkOperationStatusCloseResponse();
        this.RequestName = "BulkOperationStatusClose";
    }
    internal override string GetRequestBody()
    {
        Parameters["BulkOperationId"] = BulkOperationId;
        Parameters["FailureCount"] = FailureCount;
        Parameters["SuccessCount"] = SuccessCount;
        Parameters["StatusReason"] = StatusReason;
        Parameters["ErrorCode"] = ErrorCode;
        return GetSoapBody();
    }
}