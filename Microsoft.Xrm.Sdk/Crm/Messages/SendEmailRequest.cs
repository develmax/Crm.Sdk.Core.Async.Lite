using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class SendEmailRequest : OrganizationRequest
{
    public Guid EmailId
    {
        get
        {
            if (Parameters.Contains("EmailId"))
                return (Guid)Parameters["EmailId"];
            return default(Guid);
        }
        set { Parameters["EmailId"] = value; }
    }
    public bool IssueSend
    {
        get
        {
            if (Parameters.Contains("IssueSend"))
                return (bool)Parameters["IssueSend"];
            return default(bool);
        }
        set { Parameters["IssueSend"] = value; }
    }
    public string TrackingToken
    {
        get
        {
            if (Parameters.Contains("TrackingToken"))
                return (string)Parameters["TrackingToken"];
            return default(string);
        }
        set { Parameters["TrackingToken"] = value; }
    }
    public SendEmailRequest()
    {
        this.ResponseType = new SendEmailResponse();
        this.RequestName = "SendEmail";
    }
    internal override string GetRequestBody()
    {
        Parameters["EmailId"] = EmailId;
        Parameters["IssueSend"] = IssueSend;
        Parameters["TrackingToken"] = TrackingToken;
        return GetSoapBody();
    }
}