using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class SendFaxRequest : OrganizationRequest
{
    public Guid FaxId
    {
        get
        {
            if (Parameters.Contains("FaxId"))
                return (Guid)Parameters["FaxId"];
            return default(Guid);
        }
        set { Parameters["FaxId"] = value; }
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
    public SendFaxRequest()
    {
        this.ResponseType = new SendFaxResponse();
        this.RequestName = "SendFax";
    }
    internal override string GetRequestBody()
    {
        Parameters["FaxId"] = FaxId;
        Parameters["IssueSend"] = IssueSend;
        return GetSoapBody();
    }
}