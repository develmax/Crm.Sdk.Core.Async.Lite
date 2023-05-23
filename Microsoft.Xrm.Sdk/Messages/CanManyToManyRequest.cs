namespace Microsoft.Xrm.Sdk.Messages;

public sealed class CanManyToManyRequest : OrganizationRequest
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
    public CanManyToManyRequest()
    {
        this.ResponseType = new CanManyToManyResponse();
        this.RequestName = "CanManyToMany";

    }
    internal override string GetRequestBody()
    {
        Parameters["EntityName"] = EntityName;
        return GetSoapBody();
    }
}