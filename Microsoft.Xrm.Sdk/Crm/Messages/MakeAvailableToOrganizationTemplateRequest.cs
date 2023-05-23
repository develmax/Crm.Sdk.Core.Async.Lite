using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class MakeAvailableToOrganizationTemplateRequest : OrganizationRequest
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
    public MakeAvailableToOrganizationTemplateRequest()
    {
        this.ResponseType = new MakeAvailableToOrganizationTemplateResponse();
        this.RequestName = "MakeAvailableToOrganizationTemplate";
    }
    internal override string GetRequestBody()
    {
        Parameters["TemplateId"] = TemplateId;
        return GetSoapBody();
    }
}