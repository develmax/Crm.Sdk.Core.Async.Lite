using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class CheckPromoteEmailRequest : OrganizationRequest
{
    public int DirectionCode
    {
        get
        {
            if (Parameters.Contains("DirectionCode"))
                return (int)Parameters["DirectionCode"];
            return default(int);
        }
        set { Parameters["DirectionCode"] = value; }
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
    public CheckPromoteEmailRequest()
    {
        this.ResponseType = new CheckPromoteEmailResponse();
        this.RequestName = "CheckPromoteEmail";
    }
    internal override string GetRequestBody()
    {
        Parameters["DirectionCode"] = DirectionCode;
        Parameters["MessageId"] = MessageId;
        Parameters["Subject"] = Subject;
        return GetSoapBody();
    }
}