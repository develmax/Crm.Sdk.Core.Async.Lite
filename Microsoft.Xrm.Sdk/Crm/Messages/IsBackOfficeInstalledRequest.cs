using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class IsBackOfficeInstalledRequest : OrganizationRequest
{
    public IsBackOfficeInstalledRequest()
    {
        this.ResponseType = new IsBackOfficeInstalledResponse();
        this.RequestName = "IsBackOfficeInstalled";
    }
    internal override string GetRequestBody()
    {
        return GetSoapBody();
    }
}