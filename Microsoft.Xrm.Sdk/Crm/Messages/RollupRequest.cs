using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class RollupRequest : OrganizationRequest
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
    public RollupType RollupType
    {
        get
        {
            if (Parameters.Contains("RollupType"))
                return (RollupType)Parameters["RollupType"];
            return default(RollupType);
        }
        set { Parameters["RollupType"] = value; }
    }
    public EntityReference Target
    {
        get
        {
            if (Parameters.Contains("Target"))
                return (EntityReference)Parameters["Target"];
            return default(EntityReference);
        }
        set { Parameters["Target"] = value; }
    }
    public RollupRequest()
    {
        this.ResponseType = new RollupResponse();
        this.RequestName = "Rollup";
    }
    internal override string GetRequestBody()
    {
        Parameters["Query"] = Query;
        Parameters["RollupType"] = RollupType;
        Parameters["Target"] = Target;
        return GetSoapBody();
    }
}