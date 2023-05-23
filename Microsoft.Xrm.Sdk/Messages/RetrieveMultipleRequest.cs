using Microsoft.Xrm.Sdk.Query;

namespace Microsoft.Xrm.Sdk.Messages;

public sealed class RetrieveMultipleRequest : OrganizationRequest
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
    public RetrieveMultipleRequest()
    {
        this.ResponseType = new RetrieveMultipleResponse();
        this.RequestName = "RetrieveMultiple";
    }
    internal override string GetRequestBody()
    {
        Parameters["Query"] = Query;
        return GetSoapBody();
    }
}