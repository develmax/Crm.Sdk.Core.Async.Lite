using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class SendTemplateRequest : OrganizationRequest
{
    public OptionSetValue DeliveryPriorityCode
    {
        get
        {
            if (Parameters.Contains("DeliveryPriorityCode"))
                return (OptionSetValue)Parameters["DeliveryPriorityCode"];
            return default(OptionSetValue);
        }
        set { Parameters["DeliveryPriorityCode"] = value; }
    }
    public Guid[] RecipientIds
    {
        get
        {
            if (Parameters.Contains("RecipientIds"))
                return (Guid[])Parameters["RecipientIds"];
            return default(Guid[]);
        }
        set { Parameters["RecipientIds"] = value; }
    }
    public string RecipientType
    {
        get
        {
            if (Parameters.Contains("RecipientType"))
                return (string)Parameters["RecipientType"];
            return default(string);
        }
        set { Parameters["RecipientType"] = value; }
    }
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
    public EntityReference Sender
    {
        get
        {
            if (Parameters.Contains("Sender"))
                return (EntityReference)Parameters["Sender"];
            return default(EntityReference);
        }
        set { Parameters["Sender"] = value; }
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
    public SendTemplateRequest()
    {
        this.ResponseType = new SendTemplateResponse();
        this.RequestName = "SendTemplate";
    }
    internal override string GetRequestBody()
    {
        Parameters["DeliveryPriorityCode"] = DeliveryPriorityCode;
        Parameters["RecipientIds"] = RecipientIds;
        Parameters["RecipientType"] = RecipientType;
        Parameters["RegardingId"] = RegardingId;
        Parameters["RegardingType"] = RegardingType;
        Parameters["Sender"] = Sender;
        Parameters["TemplateId"] = TemplateId;
        return GetSoapBody();
    }
}