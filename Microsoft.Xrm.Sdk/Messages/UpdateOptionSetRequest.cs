using Microsoft.Xrm.Sdk.Metadata;

namespace Microsoft.Xrm.Sdk.Messages;

public sealed class UpdateOptionSetRequest : OrganizationRequest
{
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
    public OptionSetMetadataBase OptionSet
    {
        get
        {
            if (Parameters.Contains("OptionSet"))
                return (OptionSetMetadataBase)Parameters["OptionSet"];
            return default(OptionSetMetadataBase);
        }
        set { Parameters["OptionSet"] = value; }
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
    public UpdateOptionSetRequest()
    {
        this.ResponseType = new UpdateOptionSetResponse();
        this.RequestName = "UpdateOptionSet";
    }
    internal override string GetRequestBody()
    {
        Parameters["MergeLabels"] = MergeLabels;
        Parameters["OptionSet"] = OptionSet;
        Parameters["SolutionUniqueName"] = SolutionUniqueName;
        return GetSoapBody();
    }
}