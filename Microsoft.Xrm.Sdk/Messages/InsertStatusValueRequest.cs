namespace Microsoft.Xrm.Sdk.Messages;

public sealed class InsertStatusValueRequest : OrganizationRequest
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
    public Label Description
    {
        get
        {
            if (Parameters.Contains("Description"))
                return (Label)Parameters["Description"];
            return default(Label);
        }
        set { Parameters["Description"] = value; }
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
    public Label Label
    {
        get
        {
            if (Parameters.Contains("Label"))
                return (Label)Parameters["Label"];
            return default(Label);
        }
        set { Parameters["Label"] = value; }
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
    public int StateCode
    {
        get
        {
            if (Parameters.Contains("StateCode"))
                return (int)Parameters["StateCode"];
            return default(int);
        }
        set { Parameters["StateCode"] = value; }
    }
    public int? Value
    {
        get
        {
            if (Parameters.Contains("Value"))
                return (int?)Parameters["Value"];
            return default(int?);
        }
        set { Parameters["Value"] = value; }
    }
    public InsertStatusValueRequest()
    {
        this.ResponseType = new InsertStatusValueResponse();
        this.RequestName = "InsertStatusValue";
    }
    internal override string GetRequestBody()
    {
        Parameters["AttributeLogicalName"] = AttributeLogicalName;
        Parameters["Description"] = Description;
        Parameters["EntityLogicalName"] = EntityLogicalName;
        Parameters["Label"] = Label;
        Parameters["OptionSetName"] = OptionSetName;
        Parameters["SolutionUniqueName"] = SolutionUniqueName;
        Parameters["StateCode"] = StateCode;
        Parameters["Value"] = Value;
        return GetSoapBody();
    }
}