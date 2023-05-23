using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class CompoundUpdateDuplicateDetectionRuleRequest : OrganizationRequest
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
    public CompoundUpdateDuplicateDetectionRuleRequest()
    {
        this.ResponseType = new CompoundUpdateDuplicateDetectionRuleResponse();
        this.RequestName = "CompoundUpdateDuplicateDetectionRule";
    }
    internal override string GetRequestBody()
    {
        Parameters["Entity"] = Entity;
        Parameters["ChildEntities"] = ChildEntities;
        return GetSoapBody();
    }
}