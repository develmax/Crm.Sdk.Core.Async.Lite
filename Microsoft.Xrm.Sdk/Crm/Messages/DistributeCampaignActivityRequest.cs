using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class DistributeCampaignActivityRequest : OrganizationRequest
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
    public Guid CampaignActivityId
    {
        get
        {
            if (Parameters.Contains("CampaignActivityId"))
                return (Guid)Parameters["CampaignActivityId"];
            return default(Guid);
        }
        set { Parameters["CampaignActivityId"] = value; }
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
    public bool Propagate
    {
        get
        {
            if (Parameters.Contains("Propagate"))
                return (bool)Parameters["Propagate"];
            return default(bool);
        }
        set { Parameters["Propagate"] = value; }
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
    public DistributeCampaignActivityRequest()
    {
        this.ResponseType = new DistributeCampaignActivityResponse();
        this.RequestName = "DistributeCampaignActivity";
    }
    internal override string GetRequestBody()
    {
        Parameters["Activity"] = Activity;
        Parameters["CampaignActivityId"] = CampaignActivityId;
        Parameters["Owner"] = Owner;
        Parameters["OwnershipOptions"] = OwnershipOptions;
        Parameters["PostWorkflowEvent"] = PostWorkflowEvent;
        Parameters["Propagate"] = Propagate;
        Parameters["QueueId"] = QueueId;
        Parameters["SendEmail"] = SendEmail;
        Parameters["TemplateId"] = TemplateId;
        return GetSoapBody();
    }
}