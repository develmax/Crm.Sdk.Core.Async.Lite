using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class RetrieveDuplicatesRequest : OrganizationRequest
{
    public Entity BusinessEntity
    {
        get
        {
            if (Parameters.Contains("BusinessEntity"))
                return (Entity)Parameters["BusinessEntity"];
            return default(Entity);
        }
        set { Parameters["BusinessEntity"] = value; }
    }
    public string MatchingEntityName
    {
        get
        {
            if (Parameters.Contains("MatchingEntityName"))
                return (string)Parameters["MatchingEntityName"];
            return default(string);
        }
        set { Parameters["MatchingEntityName"] = value; }
    }
    public PagingInfo PagingInfo
    {
        get
        {
            if (Parameters.Contains("PagingInfo"))
                return (PagingInfo)Parameters["PagingInfo"];
            return default(PagingInfo);
        }
        set { Parameters["PagingInfo"] = value; }
    }
    public RetrieveDuplicatesRequest()
    {
        this.ResponseType = new RetrieveDuplicatesResponse();
        this.RequestName = "RetrieveDuplicates";
    }
    internal override string GetRequestBody()
    {
        Parameters["BusinessEntity"] = BusinessEntity;
        Parameters["MatchingEntityName"] = MatchingEntityName;
        Parameters["PagingInfo"] = PagingInfo;
        return GetSoapBody();
    }
}