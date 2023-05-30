using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class CompoundUpdateRequest : OrganizationRequest
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
    public CompoundUpdateRequest()
    {
        this.ResponseType = new CompoundUpdateResponse();
        this.RequestName = "CompoundUpdate";
    }
    internal override string GetRequestBody()
    {
        Parameters["Entity"] = Entity;
        Parameters["ChildEntities"] = ChildEntities;
        return GetSoapBody();
    }
}