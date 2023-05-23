using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveDeploymentLicenseTypeRequest : OrganizationRequest
{
    public RetrieveDeploymentLicenseTypeRequest()
    {
        this.ResponseType = new RetrieveDeploymentLicenseTypeResponse();
        this.RequestName = "RetrieveDeploymentLicenseType";
    }
    internal override string GetRequestBody()
    {
        return GetSoapBody();
    }
}