using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class LogFailureBulkOperationRequest : OrganizationRequest
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
    public Guid RegardingObjectId
    {
        get
        {
            if (Parameters.Contains("RegardingObjectId"))
                return (Guid)Parameters["RegardingObjectId"];
            return default(Guid);
        }
        set { Parameters["RegardingObjectId"] = value; }
    }
    public int RegardingObjectTypeCode
    {
        get
        {
            if (Parameters.Contains("RegardingObjectTypeCode"))
                return (int)Parameters["RegardingObjectTypeCode"];
            return default(int);
        }
        set { Parameters["RegardingObjectTypeCode"] = value; }
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
    public string Message
    {
        get
        {
            if (Parameters.Contains("Message"))
                return (string)Parameters["Message"];
            return default(string);
        }
        set { Parameters["Message"] = value; }
    }
    public string AdditionalInfo
    {
        get
        {
            if (Parameters.Contains("AdditionalInfo"))
                return (string)Parameters["AdditionalInfo"];
            return default(string);
        }
        set { Parameters["AdditionalInfo"] = value; }
    }
    public LogFailureBulkOperationRequest()
    {
        this.ResponseType = new LogFailureBulkOperationResponse();
        this.RequestName = "LogFailureBulkOperation";
    }
    internal override string GetRequestBody()
    {
        Parameters["BulkOperationId"] = BulkOperationId;
        Parameters["RegardingObjectId"] = RegardingObjectId;
        Parameters["RegardingObjectTypeCode"] = RegardingObjectTypeCode;
        Parameters["ErrorCode"] = ErrorCode;
        Parameters["Message"] = Message;
        Parameters["AdditionalInfo"] = AdditionalInfo;
        return GetSoapBody();
    }
}