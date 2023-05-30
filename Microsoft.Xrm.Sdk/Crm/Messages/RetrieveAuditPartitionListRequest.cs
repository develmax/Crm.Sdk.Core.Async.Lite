using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class RetrieveAuditPartitionListRequest : OrganizationRequest
{
    public RetrieveAuditPartitionListRequest()
    {
        this.ResponseType = new RetrieveAuditPartitionListResponse();
        this.RequestName = "RetrieveAuditPartitionList";
    }
    internal override string GetRequestBody()
    {
        return GetSoapBody();
    }
}