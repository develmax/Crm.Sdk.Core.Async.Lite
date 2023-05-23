namespace Microsoft.Xrm.Sdk.Messages;

public sealed class DeleteOptionValueRequest : OrganizationRequest
{
    public string AttributeLogicalName
    {
        get
        {
            if (Parameters.Contains("AttributeLogicalName"))
                return (string)Parameters["AttributeLogicalName"];
            return default(string);
        }
        set { Parameters["AttributeLogicalName"] = value; }
    }
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
    public string OptionSetName
    {
        get
        {
            if (Parameters.Contains("OptionSetName"))
                return (string)Parameters["OptionSetName"];
            return default(string);
        }
        set { Parameters["OptionSetName"] = value; }
    }
    public string SolutionUniqueName
    {
        get
        {
            if (Parameters.Contains("SolutionUniqueName"))
                return (string)Parameters["SolutionUniqueName"];
            return default(string);
        }
        set { Parameters["SolutionUniqueName"] = value; }
    }
    public int Value
    {
        get
        {
            if (Parameters.Contains("Value"))
                return (int)Parameters["Value"];
            return default(int);
        }
        set { Parameters["Value"] = value; }
    }
    public DeleteOptionValueRequest()
    {
        this.ResponseType = new DeleteOptionValueResponse();
        this.RequestName = "DeleteOptionValue";
    }
    internal override string GetRequestBody()
    {
        Parameters["AttributeLogicalName"] = AttributeLogicalName;
        Parameters["EntityLogicalName"] = EntityLogicalName;
        Parameters["OptionSetName"] = OptionSetName;
        Parameters["SolutionUniqueName"] = SolutionUniqueName;
        Parameters["Value"] = Value;
        return GetSoapBody();
    }
}