using Microsoft.Xrm.Sdk.Metadata;

namespace Microsoft.Xrm.Sdk.Messages;

public sealed class CreateOneToManyRequest : OrganizationRequest
{
    public LookupAttributeMetadata Lookup
    {
        get
        {
            if (Parameters.Contains("Lookup"))
                return (LookupAttributeMetadata)Parameters["Lookup"];
            return default(LookupAttributeMetadata);
        }
        set { Parameters["Lookup"] = value; }
    }
    public OneToManyRelationshipMetadata OneToManyRelationship
    {
        get
        {
            if (Parameters.Contains("OneToManyRelationship"))
                return (OneToManyRelationshipMetadata)Parameters["OneToManyRelationship"];
            return default(OneToManyRelationshipMetadata);
        }
        set { Parameters["OneToManyRelationship"] = value; }
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
    public CreateOneToManyRequest()
    {
        this.ResponseType = new CreateOneToManyResponse();
        this.RequestName = "CreateOneToMany";
    }
    internal override string GetRequestBody()
    {
        Parameters["Lookup"] = Lookup;
        Parameters["OneToManyRelationship"] = OneToManyRelationship;
        Parameters["SolutionUniqueName"] = SolutionUniqueName;
        return GetSoapBody();
    }
}