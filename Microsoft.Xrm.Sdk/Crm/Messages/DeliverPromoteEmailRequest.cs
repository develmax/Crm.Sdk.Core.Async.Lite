using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class DeliverPromoteEmailRequest : OrganizationRequest
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
    public DeliverPromoteEmailRequest()
    {
        this.ResponseType = new DeliverPromoteEmailResponse();
        this.RequestName = "DeliverPromoteEmail";
    }
    internal override string GetRequestBody()
    {
        this.Parameters["Attachments"] = Attachments;
        this.Parameters["Bcc"] = Bcc;
        this.Parameters["Body"] = Body;
        this.Parameters["Cc"] = Cc;
        this.Parameters["EmailId"] = EmailId;
        this.Parameters["ExtraProperties"] = ExtraProperties;
        this.Parameters["From"] = From;
        this.Parameters["Importance"] = Importance;
        this.Parameters["MessageId"] = MessageId;
        this.Parameters["ReceivedOn"] = ReceivedOn;
        this.Parameters["Subject"] = Subject;
        this.Parameters["SubmittedBy"] = SubmittedBy;
        this.Parameters["To"] = To;
        return GetSoapBody();
    }
}