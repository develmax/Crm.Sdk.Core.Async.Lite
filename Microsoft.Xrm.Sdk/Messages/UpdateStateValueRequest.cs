namespace Microsoft.Xrm.Sdk.Messages;

public sealed class UpdateStateValueRequest : OrganizationRequest
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
    public int? DefaultStatusCode
    {
        get
        {
            if (Parameters.Contains("DefaultStatusCode"))
                return (int?)Parameters["DefaultStatusCode"];
            return default(int?);
        }
        set { Parameters["DefaultStatusCode"] = value; }
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
    public bool MergeLabels
    {
        get
        {
            if (Parameters.Contains("MergeLabels"))
                return (bool)Parameters["MergeLabels"];
            return default(bool);
        }
        set { Parameters["MergeLabels"] = value; }
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
    public UpdateStateValueRequest()
    {
        this.ResponseType = new UpdateStateValueResponse();
        this.RequestName = "UpdateStateValue";
    }
    internal override string GetRequestBody()
    {
        Parameters["Value"] = Value;
        Parameters["MergeLabels"] = MergeLabels;
        Parameters["AttributeLogicalName"] = AttributeLogicalName;
        Parameters["EntityLogicalName"] = EntityLogicalName;
        Parameters["Label"] = Label;
        Parameters["Description"] = Description;
        Parameters["OptionSetName"] = OptionSetName;
        Parameters["DefaultStatusCode"] = DefaultStatusCode;
        return GetSoapBody();
    }
}