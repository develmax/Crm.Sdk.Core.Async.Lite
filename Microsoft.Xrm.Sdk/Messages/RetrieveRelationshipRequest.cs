using System;

namespace Microsoft.Xrm.Sdk.Messages;

public sealed class RetrieveRelationshipRequest : OrganizationRequest
{
    public Guid MetadataId
    {
        get
        {
            if (Parameters.Contains("MetadataId"))
                return (Guid)Parameters["MetadataId"];
            return default(Guid);
        }
        set { Parameters["MetadataId"] = value; }
    }
    public string Name
    {
        get
        {
            if (Parameters.Contains("Name"))
                return (string)Parameters["Name"];
            return default(string);
        }
        set { Parameters["Name"] = value; }
    }
    public bool RetrieveAsIfPublished
    {
        get
        {
            if (Parameters.Contains("RetrieveAsIfPublished"))
                return (bool)Parameters["RetrieveAsIfPublished"];
            return default(bool);
        }
        set { Parameters["RetrieveAsIfPublished"] = value; }
    }
    public RetrieveRelationshipRequest()
    {
        this.ResponseType = new RetrieveRelationshipResponse();
        this.RequestName = "RetrieveRelationship";
    }
    internal override string GetRequestBody()
    {
        Parameters["MetadataId"] = MetadataId;
        Parameters["Name"] = Name;
        Parameters["RetrieveAsIfPublished"] = RetrieveAsIfPublished;
        return GetSoapBody();
    }
}