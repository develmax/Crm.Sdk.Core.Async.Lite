using Microsoft.Xrm.Sdk.Metadata.Query;

namespace Microsoft.Xrm.Sdk.Messages;

public sealed class RetrieveMetadataChangesRequest : OrganizationRequest
{
    public string ClientVersionStamp
    {
        get
        {
            if (Parameters.Contains("ClientVersionStamp"))
                return (string)Parameters["ClientVersionStamp"];
            return default(string);
        }
        set { Parameters["ClientVersionStamp"] = value; }
    }
    public DeletedMetadataFilters DeletedMetadataFilters
    {
        get
        {
            if (Parameters.Contains("DeletedMetadataFilters"))
                return (DeletedMetadataFilters)Parameters["DeletedMetadataFilters"];
            return default(DeletedMetadataFilters);
        }
        set { Parameters["DeletedMetadataFilters"] = value; }
    }
    public EntityQueryExpression Query
    {
        get
        {
            if (Parameters.Contains("Query"))
                return (EntityQueryExpression)Parameters["Query"];
            return default(EntityQueryExpression);
        }
        set { Parameters["Query"] = value; }
    }
    public RetrieveMetadataChangesRequest()
    {
        this.ResponseType = new RetrieveMetadataChangesResponse();
        this.RequestName = "RetrieveMetadataChanges";
    }
    internal override string GetRequestBody()
    {
        Parameters["ClientVersionStamp"] = ClientVersionStamp;
        Parameters["DeletedMetadataFilters"] = DeletedMetadataFilters;
        Parameters["Query"] = Query;
        return GetSoapBody();
    }
}