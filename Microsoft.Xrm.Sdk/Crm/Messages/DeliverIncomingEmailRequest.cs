using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class DeliverIncomingEmailRequest : OrganizationRequest
{
    public EntityCollection Attachments
    {
        get
        {
            if (Parameters.Contains("Attachments"))
                return (EntityCollection)Parameters["Attachments"];
            return default(EntityCollection);
        }
        set { Parameters["Attachments"] = value; }
    }
    public string Bcc
    {
        get
        {
            if (Parameters.Contains("Bcc"))
                return (string)Parameters["Bcc"];
            return default(string);
        }
        set { Parameters["Bcc"] = value; }
    }
    public string Body
    {
        get
        {
            if (Parameters.Contains("Body"))
                return (string)Parameters["Body"];
            return default(string);
        }
        set { Parameters["Body"] = value; }
    }
    public string Cc
    {
        get
        {
            if (Parameters.Contains("Cc"))
                return (string)Parameters["Cc"];
            return default(string);
        }
        set { Parameters["Cc"] = value; }
    }
    public Entity ExtraProperties
    {
        get
        {
            if (Parameters.Contains("ExtraProperties"))
                return (Entity)Parameters["ExtraProperties"];
            return default(Entity);
        }
        set { Parameters["ExtraProperties"] = value; }
    }
    public string From
    {
        get
        {
            if (Parameters.Contains("From"))
                return (string)Parameters["From"];
            return default(string);
        }
        set { Parameters["From"] = value; }
    }
    public string Importance
    {
        get
        {
            if (Parameters.Contains("Importance"))
                return (string)Parameters["Importance"];
            return default(string);
        }
        set { Parameters["Importance"] = value; }
    }
    public string MessageId
    {
        get
        {
            if (Parameters.Contains("MessageId"))
                return (string)Parameters["MessageId"];
            return default(string);
        }
        set { Parameters["MessageId"] = value; }
    }
    public DateTime ReceivedOn
    {
        get
        {
            if (Parameters.Contains("ReceivedOn"))
                return (DateTime)Parameters["ReceivedOn"];
            return default(DateTime);
        }
        set { Parameters["ReceivedOn"] = value; }
    }
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
    public string SubmittedBy
    {
        get
        {
            if (Parameters.Contains("SubmittedBy"))
                return (string)Parameters["SubmittedBy"];
            return default(string);
        }
        set { Parameters["SubmittedBy"] = value; }
    }
    public string To
    {
        get
        {
            if (Parameters.Contains("To"))
                return (string)Parameters["To"];
            return default(string);
        }
        set { Parameters["To"] = value; }
    }
    public bool ValidateBeforeCreate
    {
        get
        {
            if (Parameters.Contains("ValidateBeforeCreate"))
                return (bool)Parameters["ValidateBeforeCreate"];
            return default(bool);
        }
        set { Parameters["ValidateBeforeCreate"] = value; }
    }
    public DeliverIncomingEmailRequest()
    {
        this.ResponseType = new DeliverIncomingEmailResponse();
        this.RequestName = "DeliverIncomingEmail";
    }
    internal override string GetRequestBody()
    {
        Parameters["Attachments"] = Attachments;
        Parameters["Bcc"] = Bcc;
        Parameters["Body"] = Body;
        Parameters["Cc"] = Cc;
        Parameters["ExtraProperties"] = ExtraProperties;
        Parameters["From"] = From;
        Parameters["Importance"] = Importance;
        Parameters["MessageId"] = MessageId;
        Parameters["ReceivedOn"] = ReceivedOn;
        Parameters["Subject"] = Subject;
        Parameters["SubmittedBy"] = SubmittedBy;
        Parameters["To"] = To;
        Parameters["ValidateBeforeCreate"] = ValidateBeforeCreate;
        return GetSoapBody();
    }
}