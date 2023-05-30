using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class CheckIncomingEmailRequest : OrganizationRequest
{
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
    public CheckIncomingEmailRequest()
    {
        this.ResponseType = new CheckIncomingEmailResponse();
        this.RequestName = "CheckIncomingEmail";
    }
    internal override string GetRequestBody()
    {
        Parameters["Bcc"] = Bcc;
        Parameters["Cc"] = Cc;
        Parameters["ExtraProperties"] = ExtraProperties;
        Parameters["From"] = From;
        Parameters["MessageId"] = MessageId;
        Parameters["Subject"] = Subject;
        Parameters["To"] = To;
        return GetSoapBody();
    }
}