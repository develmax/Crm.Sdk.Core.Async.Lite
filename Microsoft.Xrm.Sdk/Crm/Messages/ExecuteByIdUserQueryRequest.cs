using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class ExecuteByIdUserQueryRequest : OrganizationRequest
{
    public EntityReference EntityId
    {
        get
        {
            if (Parameters.Contains("EntityId"))
                return (EntityReference)Parameters["EntityId"];
            return default(EntityReference);
        }
        set { Parameters["EntityId"] = value; }
    }
    public ExecuteByIdUserQueryRequest()
    {
        this.ResponseType = new ExecuteByIdUserQueryResponse();
        this.RequestName = "ExecuteByIdUserQuery";
    }
    internal override string GetRequestBody()
    {
        Parameters["EntityId"] = EntityId;
        return GetSoapBody();
    }
}