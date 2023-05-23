using Microsoft.Xrm.Sdk.Metadata;

namespace Microsoft.Xrm.Sdk.Messages;

public sealed class CreateManyToManyRequest : OrganizationRequest
{
    public string IntersectEntitySchemaName
    {
        get
        {
            if (Parameters.Contains("IntersectEntitySchemaName"))
                return (string)Parameters["IntersectEntitySchemaName"];
            return default(string);
        }
        set { Parameters["IntersectEntitySchemaName"] = value; }
    }
    public ManyToManyRelationshipMetadata ManyToManyRelationship
    {
        get
        {
            if (Parameters.Contains("ManyToManyRelationship"))
                return (ManyToManyRelationshipMetadata)Parameters["ManyToManyRelationship"];
            return default(ManyToManyRelationshipMetadata);
        }
        set { Parameters["ManyToManyRelationship"] = value; }
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
    public CreateManyToManyRequest()
    {
        this.ResponseType = new CreateManyToManyResponse();
        this.RequestName = "CreateManyToMany";
    }
    internal override string GetRequestBody()
    {
        Parameters["IntersectEntitySchemaName"] = IntersectEntitySchemaName;
        Parameters["ManyToManyRelationship"] = ManyToManyRelationship;
        Parameters["SolutionUniqueName"] = SolutionUniqueName;
        return GetSoapBody();
    }
}