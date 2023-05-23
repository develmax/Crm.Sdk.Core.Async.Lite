using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class ExecuteByIdSavedQueryRequest : OrganizationRequest
{
    public Guid EntityId
    {
        get
        {
            if (Parameters.Contains("EntityId"))
                return (Guid)Parameters["EntityId"];
            return default(Guid);
        }
        set { Parameters["EntityId"] = value; }
    }
    public ExecuteByIdSavedQueryRequest()
    {
        this.ResponseType = new ExecuteByIdSavedQueryResponse();
        this.RequestName = "ExecuteByIdSavedQuery";
    }
    internal override string GetRequestBody()
    {
        Parameters["EntityId"] = EntityId;
        return GetSoapBody();
    }
}