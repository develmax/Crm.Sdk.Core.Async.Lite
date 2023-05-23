namespace Microsoft.Xrm.Sdk.Messages;

public sealed class OrderOptionRequest : OrganizationRequest
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
    public int[] Values
    {
        get
        {
            if (Parameters.Contains("Values"))
                return (int[])Parameters["Values"];
            return default(int[]);
        }
        set { Parameters["Values"] = value; }
    }
    public OrderOptionRequest()
    {
        this.ResponseType = new OrderOptionResponse();
        this.RequestName = "OrderOption";
    }
    internal override string GetRequestBody()
    {
        Parameters["AttributeLogicalName"] = AttributeLogicalName;
        Parameters["EntityLogicalName"] = EntityLogicalName;
        Parameters["OptionSetName"] = OptionSetName;
        Parameters["SolutionUniqueName"] = SolutionUniqueName;
        Parameters["Values"] = Values;
        return GetSoapBody();
    }
}