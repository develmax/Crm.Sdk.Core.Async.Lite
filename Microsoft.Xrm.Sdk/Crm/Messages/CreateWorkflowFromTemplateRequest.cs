using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class CreateWorkflowFromTemplateRequest : OrganizationRequest
{
    public string WorkflowName
    {
        get
        {
            if (Parameters.Contains("WorkflowName"))
                return (string)Parameters["WorkflowName"];
            return default(string);
        }
        set { Parameters["WorkflowName"] = value; }
    }
    public Guid WorkflowTemplateId
    {
        get
        {
            if (Parameters.Contains("WorkflowTemplateId"))
                return (Guid)Parameters["WorkflowTemplateId"];
            return default(Guid);
        }
        set { Parameters["WorkflowTemplateId"] = value; }
    }
    public CreateWorkflowFromTemplateRequest()
    {
        this.ResponseType = new CreateWorkflowFromTemplateResponse();
        this.RequestName = "CreateWorkflowFromTemplate";
    }
    internal override string GetRequestBody()
    {
        Parameters["WorkflowName"] = WorkflowName;
        Parameters["WorkflowTemplateId"] = WorkflowTemplateId;
        return GetSoapBody();
    }
}