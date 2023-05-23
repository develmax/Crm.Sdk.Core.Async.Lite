using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class UninstallSampleDataRequest : OrganizationRequest
{
    public UninstallSampleDataRequest()
    {
        this.ResponseType = new UninstallSampleDataResponse();
        this.RequestName = "UninstallSampleData";
    }
    internal override string GetRequestBody()
    {
        return GetSoapBody();
    }
}