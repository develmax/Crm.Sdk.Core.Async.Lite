using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class InstallSampleDataRequest : OrganizationRequest
{
    public InstallSampleDataRequest()
    {
        base.ResponseType = new InstallSampleDataResponse();
        base.RequestName = "InstallSampleData";
    }
    internal override string GetRequestBody()
    {
        return GetSoapBody();
    }
}