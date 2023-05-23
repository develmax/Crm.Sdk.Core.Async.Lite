using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class ProcessInboundEmailRequest : OrganizationRequest
{
    public Guid InboundEmailActivity
    {
        get
        {
            if (Parameters.Contains("InboundEmailActivity"))
                return (Guid)Parameters["InboundEmailActivity"];
            return default(Guid);
        }
        set { Parameters["InboundEmailActivity"] = value; }
    }
    public ProcessInboundEmailRequest()
    {
        this.ResponseType = new ProcessInboundEmailResponse();
        this.RequestName = "ProcessInboundEmail";
    }
    internal override string GetRequestBody()
    {
        Parameters["InboundEmailActivity"] = InboundEmailActivity;
        return GetSoapBody();
    }
}