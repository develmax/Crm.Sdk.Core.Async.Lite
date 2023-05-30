using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class MakeUnavailableToOrganizationTemplateRequest : OrganizationRequest
{
    public Guid TemplateId
    {
        get
        {
            if (Parameters.Contains("TemplateId"))
                return (Guid)Parameters["TemplateId"];
            return default(Guid);
        }
        set { Parameters["TemplateId"] = value; }
    }
    public MakeUnavailableToOrganizationTemplateRequest()
    {
        this.ResponseType = new MakeUnavailableToOrganizationTemplateResponse();
        this.RequestName = "MakeUnavailableToOrganizationTemplate";
    }
    internal override string GetRequestBody()
    {
        Parameters["TemplateId"] = TemplateId;
        return GetSoapBody();
    }
}