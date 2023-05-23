using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class ExecuteWorkflowRequest : OrganizationRequest
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
    public Guid WorkflowId
    {
        get
        {
            if (Parameters.Contains("WorkflowId"))
                return (Guid)Parameters["WorkflowId"];
            return default(Guid);
        }
        set { Parameters["WorkflowId"] = value; }
    }
    public ExecuteWorkflowRequest()
    {
        this.ResponseType = new ExecuteWorkflowResponse();
        this.RequestName = "ExecuteWorkflow";
    }
    internal override string GetRequestBody()
    {
        Parameters["EntityId"] = EntityId;
        Parameters["WorkflowId"] = WorkflowId;
        return GetSoapBody();
    }
}