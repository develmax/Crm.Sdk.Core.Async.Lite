namespace Microsoft.Xrm.Sdk.Messages;

public sealed class CanBeReferencingRequest : OrganizationRequest
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
    public CanBeReferencingRequest()
    {
        this.ResponseType = new CanBeReferencingResponse();
        this.RequestName = "CanBeReferencing";
    }
    internal override string GetRequestBody()
    {
        Parameters["EntityName"] = EntityName;
        return GetSoapBody();
    }
}