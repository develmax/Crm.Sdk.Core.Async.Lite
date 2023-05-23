using Microsoft.Xrm.Sdk.Metadata;

namespace Microsoft.Xrm.Sdk.Messages;

public sealed class CreateAttributeRequest : OrganizationRequest
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
    public CreateAttributeRequest()
    {
        this.ResponseType = new CreateAttributeResponse();
        this.RequestName = "CreateAttribute";
    }
    internal override string GetRequestBody()
    {
        Parameters["Attribute"] = Attribute;
        Parameters["EntityName"] = EntityName;
        Parameters["SolutionUniqueName"] = SolutionUniqueName;
        return GetSoapBody();
    }
}