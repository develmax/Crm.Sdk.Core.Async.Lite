namespace Microsoft.Xrm.Sdk.Messages;

public sealed class DeleteRequest : OrganizationRequest
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
    public DeleteRequest()
    {
        this.ResponseType = new DeleteResponse();
        this.RequestName = "Delete";
    }
    internal override string GetRequestBody()
    {
        Parameters["Target"] = Target;
        return GetSoapBody();
    }
}