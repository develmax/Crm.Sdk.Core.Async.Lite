using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class RetrieveApplicationRibbonRequest : OrganizationRequest
{
    public RetrieveApplicationRibbonRequest()
    {
        this.ResponseType = new RetrieveApplicationRibbonResponse();
        this.RequestName = "RetrieveApplicationRibbon";
    }
    internal override string GetRequestBody()
    {
        return GetSoapBody();
    }
}