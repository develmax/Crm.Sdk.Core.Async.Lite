using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveInstalledLanguagePackVersionRequest : OrganizationRequest
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
    public RetrieveInstalledLanguagePackVersionRequest()
    {
        this.ResponseType = new RetrieveInstalledLanguagePackVersionResponse();
        this.RequestName = "RetrieveInstalledLanguagePackVersion";
    }
    internal override string GetRequestBody()
    {
        Parameters["Language"] = Language;
        return GetSoapBody();
    }
}