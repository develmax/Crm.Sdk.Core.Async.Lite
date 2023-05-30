using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class LogSuccessBulkOperationRequest : OrganizationRequest
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
    public Guid CreatedObjectId
    {
        get
        {
            if (Parameters.Contains("CreatedObjectId"))
                return (Guid)Parameters["CreatedObjectId"];
            return default(Guid);
        }
        set { Parameters["CreatedObjectId"] = value; }
    }
    public int CreatedObjectTypeCode
    {
        get
        {
            if (Parameters.Contains("CreatedObjectTypeCode"))
                return (int)Parameters["CreatedObjectTypeCode"];
            return default(int);
        }
        set { Parameters["CreatedObjectTypeCode"] = value; }
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
    public LogSuccessBulkOperationRequest()
    {
        this.ResponseType = new LogSuccessBulkOperationResponse();
        this.RequestName = "LogSuccessBulkOperation";
    }
    internal override string GetRequestBody()
    {
        Parameters["BulkOperationId"] = BulkOperationId;
        Parameters["RegardingObjectId"] = RegardingObjectId;
        Parameters["RegardingObjectTypeCode"] = RegardingObjectTypeCode;
        Parameters["CreatedObjectId"] = CreatedObjectId;
        Parameters["CreatedObjectTypeCode"] = CreatedObjectTypeCode;
        Parameters["AdditionalInfo"] = AdditionalInfo;
        return GetSoapBody();
    }
}