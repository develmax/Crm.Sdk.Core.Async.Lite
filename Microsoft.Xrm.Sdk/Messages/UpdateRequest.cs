namespace Microsoft.Xrm.Sdk.Messages;

public sealed class UpdateRequest : OrganizationRequest
{
    public Entity Target
    {
        get
        {
            if (Parameters.Contains("Target"))
                return (Entity)Parameters["Target"];
            return default(Entity);
        }
        set { Parameters["Target"] = value; }
    }
    public UpdateRequest()
    {
        this.ResponseType = new UpdateResponse();
        this.RequestName = "Update";
    }
    internal override string GetRequestBody()
    {
        Parameters["Target"] = Target;
        return GetSoapBody();
    }
}