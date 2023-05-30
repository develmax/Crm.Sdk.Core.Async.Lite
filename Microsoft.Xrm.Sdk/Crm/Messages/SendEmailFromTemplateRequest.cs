using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class SendEmailFromTemplateRequest : OrganizationRequest
{
    public Guid RegardingId
    {
        get
        {
            if (Parameters.Contains("RegardingId"))
                return (Guid)Parameters["RegardingId"];
            return default(Guid);
        }
        set { Parameters["RegardingId"] = value; }
    }
    public string RegardingType
    {
        get
        {
            if (Parameters.Contains("RegardingType"))
                return (string)Parameters["RegardingType"];
            return default(string);
        }
        set { Parameters["RegardingType"] = value; }
    }
    public Entity Target
    {
        get
        {
            if (Parameters.Contains("Target"))
                return (Entity)Parameters["Target"];
            return default(Entity);
        }
        set { Parameters["Target"] = value; }
    }
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
    public SendEmailFromTemplateRequest()
    {
        this.ResponseType = new SendEmailFromTemplateResponse();
        this.RequestName = "SendEmailFromTemplate";
    }
    internal override string GetRequestBody()
    {
        Parameters["RegardingId"] = RegardingId;
        Parameters["RegardingType"] = RegardingType;
        Parameters["Target"] = Target;
        Parameters["TemplateId"] = TemplateId;
        return GetSoapBody();
    }
}