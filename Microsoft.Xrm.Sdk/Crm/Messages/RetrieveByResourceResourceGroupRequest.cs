using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveByResourceResourceGroupRequest : OrganizationRequest
{
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
    public Guid ResourceId
    {
        get
        {
            if (Parameters.Contains("ResourceId"))
                return (Guid)Parameters["ResourceId"];
            return default(Guid);
        }
        set { Parameters["ResourceId"] = value; }
    }
    public RetrieveByResourceResourceGroupRequest()
    {
        this.ResponseType = new RetrieveByResourceResourceGroupResponse();
        this.RequestName = "RetrieveByResourceResourceGroupResource";
    }
    internal override string GetRequestBody()
    {
        Parameters["Query"] = Query;
        Parameters["ResourceId"] = ResourceId;
        return GetSoapBody();
    }
}