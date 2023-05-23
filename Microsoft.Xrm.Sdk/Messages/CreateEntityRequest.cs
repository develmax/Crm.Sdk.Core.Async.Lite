using Microsoft.Xrm.Sdk.Metadata;

namespace Microsoft.Xrm.Sdk.Messages;

public sealed class CreateEntityRequest : OrganizationRequest
{
    public EntityMetadata Entity
    {
        get
        {
            if (Parameters.Contains("Entity"))
                return (EntityMetadata)Parameters["Entity"];
            return default(EntityMetadata);
        }
        set { Parameters["Entity"] = value; }
    }
    public bool HasActivities
    {
        get
        {
            if (Parameters.Contains("HasActivities"))
                return (bool)Parameters["HasActivities"];
            return default(bool);
        }
        set { Parameters["HasActivities"] = value; }
    }
    public bool HasNotes
    {
        get
        {
            if (Parameters.Contains("HasNotes"))
                return (bool)Parameters["HasNotes"];
            return default(bool);
        }
        set { Parameters["HasNotes"] = value; }
    }
    public StringAttributeMetadata PrimaryAttribute
    {
        get
        {
            if (Parameters.Contains("PrimaryAttribute"))
                return (StringAttributeMetadata)Parameters["PrimaryAttribute"];
            return default(StringAttributeMetadata);
        }
        set { Parameters["PrimaryAttribute"] = value; }
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
    public CreateEntityRequest()
    {
        this.ResponseType = new CreateEntityResponse();
        this.RequestName = "CreateEntity";
    }
    internal override string GetRequestBody()
    {
        Parameters["Entity"] = Entity;
        Parameters["HasActivities"] = HasActivities;
        Parameters["HasNotes"] = HasNotes;
        Parameters["PrimaryAttribute"] = PrimaryAttribute;
        Parameters["SolutionUniqueName"] = SolutionUniqueName;
        return GetSoapBody();
    }
}