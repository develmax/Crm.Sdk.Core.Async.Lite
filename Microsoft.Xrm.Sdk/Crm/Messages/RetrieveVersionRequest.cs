using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class RetrieveVersionRequest : OrganizationRequest
{
    public RetrieveVersionRequest()
    {
        this.ResponseType = new RetrieveVersionResponse();
        this.RequestName = "RetrieveVersion";
    }
    internal override string GetRequestBody()
    {
        return GetSoapBody();
    }
}