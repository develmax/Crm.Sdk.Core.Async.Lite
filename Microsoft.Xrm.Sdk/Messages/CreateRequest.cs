namespace Microsoft.Xrm.Sdk.Messages;

public sealed class CreateRequest : OrganizationRequest
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
    public CreateRequest()
    {
        this.ResponseType = new CreateResponse();
        this.RequestName = "Create";
    }
    internal override string GetRequestBody()
    {
        Parameters["Target"] = Target;
        return GetSoapBody();
    }
}