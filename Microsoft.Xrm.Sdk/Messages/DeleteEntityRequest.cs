namespace Microsoft.Xrm.Sdk.Messages;

public sealed class DeleteEntityRequest : OrganizationRequest
{
    public string LogicalName
    {
        get
        {
            if (Parameters.Contains("LogicalName"))
                return (string)Parameters["LogicalName"];
            return default(string);
        }
        set { Parameters["LogicalName"] = value; }
    }
    public DeleteEntityRequest()
    {
        this.ResponseType = new DeleteEntityResponse();
        this.RequestName = "DeleteEntity";
    }
    internal override string GetRequestBody()
    {
        Parameters["LogicalName"] = LogicalName;
        return GetSoapBody();
    }
}