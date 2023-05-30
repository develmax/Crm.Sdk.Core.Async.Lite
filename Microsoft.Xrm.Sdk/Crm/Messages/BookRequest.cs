using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class BookRequest : OrganizationRequest
{
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
    public bool ReturnNotifications
    {
        get
        {
            if (Parameters.Contains("ReturnNotifications"))
                return (bool)Parameters["ReturnNotifications"];
            return default(bool);
        }
        set { Parameters["ReturnNotifications"] = value; }
    }
    public BookRequest()
    {
        this.ResponseType = new BookResponse();
        this.RequestName = "Book";
    }
    internal override string GetRequestBody()
    {
        Parameters["Target"] = Target;
        Parameters["ReturnNotifications"] = ReturnNotifications;
        return GetSoapBody();
    }
}