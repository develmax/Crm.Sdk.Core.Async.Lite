using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class WhoAmIRequest : OrganizationRequest
{
    public WhoAmIRequest()
    {
        base.ResponseType = new WhoAmIResponse();
        base.RequestName = "WhoAmI";
    }
    internal override string GetRequestBody()
    {
        return GetSoapBody();
    }
}