using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveByResourcesServiceRequest : OrganizationRequest
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
    public Guid[] ResourceIds
    {
        get
        {
            if (Parameters.Contains("ResourceIds"))
                return (Guid[])Parameters["ResourceIds"];
            return default(Guid[]);
        }
        set { Parameters["ResourceIds"] = value; }
    }
    public RetrieveByResourcesServiceRequest()
    {
        this.ResponseType = new RetrieveByResourcesServiceResponse();
        this.RequestName = "RetrieveByResourcesService";
    }
    internal override string GetRequestBody()
    {
        Parameters["Query"] = Query;
        Parameters["ResourceIds"] = ResourceIds;
        return GetSoapBody();
    }
}