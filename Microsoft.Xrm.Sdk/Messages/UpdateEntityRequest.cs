using Microsoft.Xrm.Sdk.Metadata;

namespace Microsoft.Xrm.Sdk.Messages;

public sealed class UpdateEntityRequest : OrganizationRequest
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
    public bool? HasActivities
    {
        get
        {
            if (Parameters.Contains("HasActivities"))
                return (bool?)Parameters["HasActivities"];
            return default(bool?);
        }
        set { Parameters["HasActivities"] = value; }
    }
    public bool? HasNotes
    {
        get
        {
            if (Parameters.Contains("HasNotes"))
                return (bool?)Parameters["HasNotes"];
            return default(bool?);
        }
        set { Parameters["HasNotes"] = value; }
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
    public UpdateEntityRequest()
    {
        this.ResponseType = new UpdateEntityResponse();
        this.RequestName = "UpdateEntity";
    }
    internal override string GetRequestBody()
    {
        Parameters["Entity"] = Entity;
        Parameters["HasActivities"] = HasActivities;
        Parameters["HasNotes"] = HasNotes;
        Parameters["MergeLabels"] = MergeLabels;
        Parameters["SolutionUniqueName"] = SolutionUniqueName;
        return GetSoapBody();
    }
}