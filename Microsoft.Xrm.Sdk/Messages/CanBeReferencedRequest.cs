namespace Microsoft.Xrm.Sdk.Messages;

public sealed class CanBeReferencedRequest : OrganizationRequest
{
    public string EntityName
    {
        get
        {
            if (Parameters.Contains("EntityName"))
                return (string)Parameters["EntityName"];
            return default(string);
        }
        set { Parameters["EntityName"] = value; }
    }
    public CanBeReferencedRequest()
    {
        this.ResponseType = new CanBeReferencedResponse();
        this.RequestName = "CanBeReferenced";
    }
    internal override string GetRequestBody()
    {
        Parameters["EntityName"] = EntityName;
        return GetSoapBody();
    }
}