using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class ProcessOneMemberBulkOperationRequest : OrganizationRequest
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
    public Entity Entity
    {
        get
        {
            if (Parameters.Contains("Entity"))
                return (Entity)Parameters["Entity"];
            return default(Entity);
        }
        set { Parameters["Entity"] = value; }
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
    public ProcessOneMemberBulkOperationRequest()
    {
        this.ResponseType = new ProcessOneMemberBulkOperationResponse();
        this.RequestName = "ProcessOneMemberBulkOperation";
    }
    internal override string GetRequestBody()
    {
        Parameters["BulkOperationId"] = BulkOperationId;
        Parameters["Entity"] = Entity;
        Parameters["BulkOperationSource"] = BulkOperationSource;
        return GetSoapBody();
    }
}