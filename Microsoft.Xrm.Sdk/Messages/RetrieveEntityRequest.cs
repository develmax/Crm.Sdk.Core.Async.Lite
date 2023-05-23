using System;
using Microsoft.Xrm.Sdk.Metadata;

namespace Microsoft.Xrm.Sdk.Messages;

public sealed class RetrieveEntityRequest : OrganizationRequest
{
    public EntityFilters EntityFilters
    {
        get
        {
            if (Parameters.Contains("EntityFilters"))
                return (EntityFilters)Parameters["EntityFilters"];
            return default(EntityFilters);
        }
        set { Parameters["EntityFilters"] = value; }
    }
    public string LogicalName
    {
        get
        {
            if (Parameters.Contains("LogicalName"))
                return (string)Parameters["LogicalName"];
            return default(string);
        }
        set { Parameters["LogicalName"] = value; }
    }
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
    public RetrieveEntityRequest()
    {
        this.ResponseType = new RetrieveEntityResponse();
        this.RequestName = "RetrieveEntity";
    }
    internal override string GetRequestBody()
    {
        Parameters["EntityFilters"] = EntityFilters;
        Parameters["LogicalName"] = LogicalName;
        Parameters["MetadataId"] = MetadataId;
        Parameters["RetrieveAsIfPublished"] = RetrieveAsIfPublished;
        return GetSoapBody();
    }
}