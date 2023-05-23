using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class DeprovisionLanguageRequest : OrganizationRequest
{
    public int Language
    {
        get
        {
            if (Parameters.Contains("Language"))
                return (int)Parameters["Language"];
            return default(int);
        }
        set { Parameters["Language"] = value; }
    }
    public DeprovisionLanguageRequest()
    {
        this.ResponseType = new DeprovisionLanguageResponse();
        this.RequestName = "DeprovisionLanguage";
    }
    internal override string GetRequestBody()
    {
        Parameters["Language"] = Language;
        return GetSoapBody();
    }
}