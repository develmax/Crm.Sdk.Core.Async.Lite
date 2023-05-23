using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class ExportTranslationRequest : OrganizationRequest
{
    public string SolutionName
    {
        get
        {
            if (Parameters.Contains("SolutionName"))
                return (string)Parameters["SolutionName"];
            return default(string);
        }
        set { Parameters["SolutionName"] = value; }
    }
    public ExportTranslationRequest()
    {
        this.ResponseType = new ExportTranslationResponse();
        this.RequestName = "ExportTranslation";
    }
    internal override string GetRequestBody()
    {
        Parameters["SolutionName"] = SolutionName;
        return GetSoapBody();
    }
}