using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveMembersBulkOperationRequest : OrganizationRequest
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
    public int EntitySource
    {
        get
        {
            if (Parameters.Contains("EntitySource"))
                return (int)Parameters["EntitySource"];
            return default(int);
        }
        set { Parameters["EntitySource"] = value; }
    }
    public QueryBase Query
    {
        get
        {
            if (Parameters.Contains("Query"))
                return (QueryBase)Parameters["Query"];
            return default(QueryBase);
        }
        set { Parameters["Query"] = value; }
    }
    public RetrieveMembersBulkOperationRequest()
    {
        this.ResponseType = new RetrieveMembersBulkOperationResponse();
        this.RequestName = "RetrieveMembersBulkOperation";
    }
    internal override string GetRequestBody()
    {
        Parameters["BulkOperationId"] = BulkOperationId;
        Parameters["BulkOperationSource"] = BulkOperationSource;
        Parameters["EntitySource"] = EntitySource;
        Parameters["Query"] = Query;
        return GetSoapBody();
    }
}