using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class GetTrackingTokenEmailRequest : OrganizationRequest
{
    public string Subject
    {
        get
        {
            if (Parameters.Contains("Subject"))
                return (string)Parameters["Subject"];
            return default(string);
        }
        set { Parameters["Subject"] = value; }
    }
    public GetTrackingTokenEmailRequest()
    {
        this.ResponseType = new GetTrackingTokenEmailResponse();
        this.RequestName = "GetTrackingTokenEmail";
    }
    internal override string GetRequestBody()
    {
        Parameters["Subject"] = Subject;
        return GetSoapBody();
    }
}