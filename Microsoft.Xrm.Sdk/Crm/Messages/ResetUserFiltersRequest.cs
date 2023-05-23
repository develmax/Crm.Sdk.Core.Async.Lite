using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class ResetUserFiltersRequest : OrganizationRequest
{
    public int QueryType
    {
        get
        {
            if (Parameters.Contains("QueryType"))
                return (int)Parameters["QueryType"];
            return default(int);
        }
        set { Parameters["QueryType"] = value; }
    }
    public ResetUserFiltersRequest()
    {
        this.ResponseType = new ResetUserFiltersResponse();
        this.RequestName = "ResetUserFilters";
    }
    internal override string GetRequestBody()
    {
        Parameters["QueryType"] = QueryType;
        return GetSoapBody();
    }
}