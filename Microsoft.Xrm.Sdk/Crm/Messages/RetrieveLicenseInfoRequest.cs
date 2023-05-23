using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveLicenseInfoRequest : OrganizationRequest
{
    public int AccessMode
    {
        get
        {
            if (Parameters.Contains("AccessMode"))
                return (int)Parameters["AccessMode"];
            return default(int);
        }
        set { Parameters["AccessMode"] = value; }
    }
    public RetrieveLicenseInfoRequest()
    {
        this.ResponseType = new RetrieveLicenseInfoResponse();
        this.RequestName = "RetrieveLicenseInfo";
    }
    internal override string GetRequestBody()
    {
        Parameters["AccessMode"] = AccessMode;
        return GetSoapBody();
    }
}