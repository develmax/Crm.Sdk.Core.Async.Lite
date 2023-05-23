using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveSubGroupsResourceGroupRequest : OrganizationRequest
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
    public Guid ResourceGroupId
    {
        get
        {
            if (Parameters.Contains("ResourceGroupId"))
                return (Guid)Parameters["ResourceGroupId"];
            return default(Guid);
        }
        set { Parameters["ResourceGroupId"] = value; }
    }
    public RetrieveSubGroupsResourceGroupRequest()
    {
        this.ResponseType = new RetrieveSubGroupsResourceGroupResponse();
        this.RequestName = "RetrieveSubGroupsResourceGroup";
    }
    internal override string GetRequestBody()
    {
        Parameters["Query"] = Query;
        Parameters["ResourceGroupId"] = ResourceGroupId;
        return GetSoapBody();
    }
}