using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveDependenciesForUninstallRequest : OrganizationRequest
{
    public string SolutionUniqueName
    {
        get
        {
            if (Parameters.Contains("SolutionUniqueName"))
                return (string)Parameters["SolutionUniqueName"];
            return default(string);
        }
        set { Parameters["SolutionUniqueName"] = value; }
    }
    public RetrieveDependenciesForUninstallRequest()
    {
        this.ResponseType = new RetrieveDependenciesForUninstallResponse();
        this.RequestName = "RetrieveDependenciesForUninstall";
    }
    internal override string GetRequestBody()
    {
        Parameters["SolutionUniqueName"] = SolutionUniqueName;
        return GetSoapBody();
    }
}