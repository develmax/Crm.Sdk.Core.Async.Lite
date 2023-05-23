using Microsoft.Xrm.Sdk.Metadata;

namespace Microsoft.Xrm.Sdk.Messages;

public sealed class UpdateRelationshipRequest : OrganizationRequest
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
    public RelationshipMetadataBase Relationship
    {
        get
        {
            if (Parameters.Contains("Relationship"))
                return (RelationshipMetadataBase)Parameters["Relationship"];
            return default(RelationshipMetadataBase);
        }
        set { Parameters["Relationship"] = value; }
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
    public UpdateRelationshipRequest()
    {
        this.ResponseType = new UpdateRelationshipResponse();
        this.RequestName = "UpdateRelationship";
    }
    internal override string GetRequestBody()
    {
        Parameters["MergeLabels"] = MergeLabels;
        Parameters["Relationship"] = Relationship;
        Parameters["SolutionUniqueName"] = SolutionUniqueName;
        return GetSoapBody();
    }
}