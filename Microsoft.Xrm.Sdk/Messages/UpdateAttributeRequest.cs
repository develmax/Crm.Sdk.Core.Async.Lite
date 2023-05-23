using Microsoft.Xrm.Sdk.Metadata;

namespace Microsoft.Xrm.Sdk.Messages;

public sealed class UpdateAttributeRequest : OrganizationRequest
{
    public AttributeMetadata Attribute
    {
        get
        {
            if (Parameters.Contains("Attribute"))
                return (AttributeMetadata)Parameters["Attribute"];
            return default(AttributeMetadata);
        }
        set { Parameters["Attribute"] = value; }
    }
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
    public UpdateAttributeRequest()
    {
        this.ResponseType = new UpdateAttributeResponse();
        this.RequestName = "UpdateAttribute";
    }
    internal override string GetRequestBody()
    {
        Parameters["Attribute"] = Attribute;
        Parameters["EntityName"] = EntityName;
        Parameters["MergeLabels"] = MergeLabels;
        Parameters["SolutionUniqueName"] = SolutionUniqueName;
        return GetSoapBody();
    }
}