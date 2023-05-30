using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class AssignRequest : OrganizationRequest
{
    public EntityReference Assignee
    {
        get
        {
            if (Parameters.Contains("Assignee"))
                return (EntityReference)Parameters["Assignee"];
            return default(EntityReference);
        }
        set { Parameters["Assignee"] = value; }
    }
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
    public AssignRequest()
    {
        this.ResponseType = new AssignResponse();
        this.RequestName = "Assign";
    }
    internal override string GetRequestBody()
    {
        Parameters["Assignee"] = Assignee;
        Parameters["Target"] = Target;
        return GetSoapBody();
    }
}