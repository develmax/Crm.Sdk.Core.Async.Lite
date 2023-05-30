using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class CleanUpBulkOperationRequest : OrganizationRequest
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
    public int BulkOperationSource
    {
        get
        {
            if (Parameters.Contains("BulkOperationSource"))
                return (int)Parameters["BulkOperationSource"];
            return default(int);
        }
        set { Parameters["BulkOperationSource"] = value; }
    }
    public CleanUpBulkOperationRequest()
    {
        this.ResponseType = new CleanUpBulkOperationResponse();
        this.RequestName = "CleanUpBulkOperation";
    }
    internal override string GetRequestBody()
    {
        Parameters["BulkOperationId"] = BulkOperationId;
        Parameters["BulkOperationSource"] = BulkOperationSource;
        return GetSoapBody();
    }
}