using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class CreateActivitiesListRequest : OrganizationRequest
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
    public Guid ListId
    {
        get
        {
            if (Parameters.Contains("ListId"))
                return (Guid)Parameters["ListId"];
            return default(Guid);
        }
        set { Parameters["ListId"] = value; }
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
    public bool sendEmail
    {
        get
        {
            if (Parameters.Contains("sendEmail"))
                return (bool)Parameters["sendEmail"];
            return default(bool);
        }
        set { Parameters["sendEmail"] = value; }
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
    public CreateActivitiesListRequest()
    {
        this.ResponseType = new CreateActivitiesListResponse();
        this.RequestName = "CreateActivitiesList";
    }
    internal override string GetRequestBody()
    {
        Parameters["Activity"] = Activity;
        Parameters["FriendlyName"] = FriendlyName;
        Parameters["ListId"] = ListId;
        Parameters["Owner"] = Owner;
        Parameters["OwnershipOptions"] = OwnershipOptions;
        Parameters["PostWorkflowEvent"] = PostWorkflowEvent;
        Parameters["Propagate"] = Propagate;
        Parameters["QueueId"] = QueueId;
        Parameters["sendEmail"] = sendEmail;
        Parameters["TemplateId"] = TemplateId;
        return GetSoapBody();
    }
}