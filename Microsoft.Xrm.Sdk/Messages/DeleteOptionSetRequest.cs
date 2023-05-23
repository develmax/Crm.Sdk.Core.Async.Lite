namespace Microsoft.Xrm.Sdk.Messages;

public sealed class DeleteOptionSetRequest : OrganizationRequest
{
    public string Name
    {
        get
        {
            if (Parameters.Contains("Name"))
                return (string)Parameters["Name"];
            return default(string);
        }
        set { Parameters["Name"] = value; }
    }
    public DeleteOptionSetRequest()
    {
        this.ResponseType = new DeleteOptionSetResponse();
        this.RequestName = "DeleteOptionSet";
    }
    internal override string GetRequestBody()
    {
        Parameters["Name"] = Name;
        return GetSoapBody();
    }
}