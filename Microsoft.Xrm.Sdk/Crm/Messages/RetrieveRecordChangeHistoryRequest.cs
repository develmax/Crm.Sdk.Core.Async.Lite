using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class RetrieveRecordChangeHistoryRequest : OrganizationRequest
{
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
    public RetrieveRecordChangeHistoryRequest()
    {
        this.ResponseType = new RetrieveRecordChangeHistoryResponse();
        this.RequestName = "RetrieveRecordChangeHistory";
    }
    internal override string GetRequestBody()
    {
        Parameters["Target"] = Target;
        Parameters["PagingInfo"] = PagingInfo;
        return GetSoapBody();
    }
}