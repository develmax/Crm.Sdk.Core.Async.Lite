namespace Microsoft.Xrm.Sdk.Messages;

public sealed class DisassociateRequest : OrganizationRequest
{
    public EntityReference Target
    {
        get
        {
            if (Parameters.Contains("Target"))
                return (EntityReference)Parameters["Target"];
            return default(EntityReference);
        }
        set { Parameters["Target"] = value; }
    }
    public EntityReferenceCollection RelatedEntities
    {
        get
        {
            if (Parameters.Contains("RelatedEntities"))
                return (EntityReferenceCollection)Parameters["RelatedEntities"];
            return default(EntityReferenceCollection);
        }
        set { Parameters["RelatedEntities"] = value; }
    }
    public Relationship Relationship
    {
        get
        {
            if (Parameters.Contains("Relationship"))
                return (Relationship)Parameters["Relationship"];
            return default(Relationship);
        }
        set { Parameters["Relationship"] = value; }
    }
    public DisassociateRequest()
    {
        this.ResponseType = new DisassociateResponse();
        this.RequestName = "Disassociate";
    }
    internal override string GetRequestBody()
    {
        Parameters["Target"] = Target;
        Parameters["RelatedEntities"] = RelatedEntities;
        Parameters["Relationship"] = Relationship;
        return GetSoapBody();
    }
}