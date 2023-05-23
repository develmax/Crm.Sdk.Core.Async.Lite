namespace Microsoft.Xrm.Sdk.Messages;

public sealed class DeleteAttributeRequest : OrganizationRequest
{
    public string EntityLogicalName
    {
        get
        {
            if (Parameters.Contains("EntityLogicalName"))
                return (string)Parameters["EntityLogicalName"];
            return default(string);
        }
        set { Parameters["EntityLogicalName"] = value; }
    }
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
    public DeleteAttributeRequest()
    {
        this.ResponseType = new DeleteAttributeResponse();
        this.RequestName = "DeleteAttribute";
    }
    internal override string GetRequestBody()
    {
        Parameters["EntityLogicalName"] = EntityLogicalName;
        Parameters["LogicalName"] = LogicalName;
        return GetSoapBody();
    }
}