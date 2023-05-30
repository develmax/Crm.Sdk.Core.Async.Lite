using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class PropagateByExpressionRequest : OrganizationRequest
{
    public Entity Activity
    {
        get
        {
            if (Parameters.Contains("Activity"))
                return (Entity)Parameters["Activity"];
            return default(Entity);
        }
        set { Parameters["Activity"] = value; }
    }
    public bool ExecuteImmediately
    {
        get
        {
            if (Parameters.Contains("ExecuteImmediately"))
                return (bool)Parameters["ExecuteImmediately"];
            return default(bool);
        }
        set { Parameters["ExecuteImmediately"] = value; }
    }
    public string FriendlyName
    {
        get
        {
            if (Parameters.Contains("FriendlyName"))
                return (string)Parameters["FriendlyName"];
            return default(string);
        }
        set { Parameters["FriendlyName"] = value; }
    }
    public EntityReference Owner
    {
        get
        {
            if (Parameters.Contains("Owner"))
                return (EntityReference)Parameters["Owner"];
            return default(EntityReference);
        }
        set { Parameters["Owner"] = value; }
    }
    public PropagationOwnershipOptions OwnershipOptions
    {
        get
        {
            if (Parameters.Contains("OwnershipOptions"))
                return (PropagationOwnershipOptions)Parameters["OwnershipOptions"];
            return default(PropagationOwnershipOptions);
        }
        set { Parameters["OwnershipOptions"] = value; }
    }
    public bool PostWorkflowEvent
    {
        get
        {
            if (Parameters.Contains("PostWorkflowEvent"))
                return (bool)Parameters["PostWorkflowEvent"];
            return default(bool);
        }
        set { Parameters["PostWorkflowEvent"] = value; }
    }
    public QueryBase QueryExpression
    {
        get
        {
            if (Parameters.Contains("QueryExpression"))
                return (QueryBase)Parameters["QueryExpression"];
            return default(QueryBase);
        }
        set { Parameters["QueryExpression"] = value; }
    }
    public Guid QueueId
    {
        get
        {
            if (Parameters.Contains("QueueId"))
                return (Guid)Parameters["QueueId"];
            return default(Guid);
        }
        set { Parameters["QueueId"] = value; }
    }
    public bool SendEmail
    {
        get
        {
            if (Parameters.Contains("SendEmail"))
                return (bool)Parameters["SendEmail"];
            return default(bool);
        }
        set { Parameters["SendEmail"] = value; }
    }
    public Guid TemplateId
    {
        get
        {
            if (Parameters.Contains("TemplateId"))
                return (Guid)Parameters["TemplateId"];
            return default(Guid);
        }
        set { Parameters["TemplateId"] = value; }
    }
    public PropagateByExpressionRequest()
    {
        this.ResponseType = new PropagateByExpressionResponse();
        this.RequestName = "PropagateByExpression";
    }
    internal override string GetRequestBody()
    {
        Parameters["Activity"] = Activity;
        Parameters["ExecuteImmediately"] = ExecuteImmediately;
        Parameters["FriendlyName"] = FriendlyName;
        Parameters["Owner"] = Owner;
        Parameters["OwnershipOptions"] = OwnershipOptions;
        Parameters["PostWorkflowEvent"] = PostWorkflowEvent;
        Parameters["QueryExpression"] = QueryExpression;
        Parameters["QueueId"] = QueueId;
        Parameters["SendEmail"] = SendEmail;
        Parameters["TemplateId"] = TemplateId;
        return GetSoapBody();
    }
}