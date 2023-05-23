namespace Microsoft.Xrm.Sdk.Messages;

public sealed class DeleteRelationshipRequest : OrganizationRequest
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
    public DeleteRelationshipRequest()
    {
        this.ResponseType = new DeleteRelationshipResponse();
        this.RequestName = "DeleteRelationship";
    }
    internal override string GetRequestBody()
    {
        Parameters["Name"] = Name;
        return GetSoapBody();
    }
}