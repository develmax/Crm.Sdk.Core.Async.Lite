using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveUnpublishedMultipleRequest : OrganizationRequest
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
    public RetrieveUnpublishedMultipleRequest()
    {
        this.ResponseType = new RetrieveUnpublishedMultipleResponse();
        this.RequestName = "RetrieveUnpublishedMultiple";
    }
    internal override string GetRequestBody()
    {
        Parameters["Query"] = Query;
        return GetSoapBody();
    }
}