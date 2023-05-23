using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class CreateInstanceRequest : OrganizationRequest
{
    public int Count
    {
        get
        {
            if (Parameters.Contains("Count"))
                return (int)Parameters["Count"];
            return default(int);
        }
        set { Parameters["Count"] = value; }
    }
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
    public CreateInstanceRequest()
    {
        this.ResponseType = new CreateInstanceResponse();
        this.RequestName = "CreateInstance";
    }
    internal override string GetRequestBody()
    {
        Parameters["Count"] = Count;
        Parameters["Target"] = Target;
        return GetSoapBody();
    }
}