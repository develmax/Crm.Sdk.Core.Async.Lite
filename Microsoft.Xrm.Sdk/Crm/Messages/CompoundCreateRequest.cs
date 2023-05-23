using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class CompoundCreateRequest : OrganizationRequest
{
    public Entity Entity
    {
        get
        {
            if (Parameters.Contains("Entity"))
                return (Entity)Parameters["Entity"];
            return default(Entity);
        }
        set { Parameters["Entity"] = value; }
    }
    public EntityCollection ChildEntities
    {
        get
        {
            if (Parameters.Contains("ChildEntities"))
                return (EntityCollection)Parameters["ChildEntities"];
            return default(EntityCollection);
        }
        set { Parameters["ChildEntities"] = value; }
    }
    public CompoundCreateRequest()
    {
        this.ResponseType = new CompoundCreateResponse();
        this.RequestName = "CompoundCreate";
    }
    internal override string GetRequestBody()
    {
        Parameters["Entity"] = Entity;
        Parameters["ChildEntities"] = ChildEntities;
        return GetSoapBody();
    }
}