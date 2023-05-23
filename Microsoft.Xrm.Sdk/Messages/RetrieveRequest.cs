using Microsoft.Xrm.Sdk.Query;

namespace Microsoft.Xrm.Sdk.Messages;

public sealed class RetrieveRequest : OrganizationRequest
{
    public ColumnSet ColumnSet
    {
        get
        {
            if (Parameters.Contains("ColumnSet"))
                return (ColumnSet)Parameters["ColumnSet"];
            return default(ColumnSet);
        }
        set { Parameters["ColumnSet"] = value; }
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
    public RetrieveRequest()
    {
        this.ResponseType = new RetrieveResponse();
        this.RequestName = "Retrieve";
    }
    internal override string GetRequestBody()
    {
        Parameters["ColumnSet"] = ColumnSet;
        Parameters["Target"] = Target;
        return GetSoapBody();
    }
}