using Microsoft.Xrm.Sdk.Metadata;

namespace Microsoft.Xrm.Sdk.Messages;

public sealed class RetrieveAllEntitiesRequest : OrganizationRequest
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
    public RetrieveAllEntitiesRequest()
    {
        this.ResponseType = new RetrieveAllEntitiesResponse();
        this.RequestName = "RetrieveAllEntities";
    }
    internal override string GetRequestBody()
    {
        Parameters["EntityFilters"] = EntityFilters;
        Parameters["RetrieveAsIfPublished"] = RetrieveAsIfPublished;
        return GetSoapBody();
    }
}