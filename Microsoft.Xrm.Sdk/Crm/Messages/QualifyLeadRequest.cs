using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class QualifyLeadRequest : OrganizationRequest
{
    public bool CreateAccount
    {
        get
        {
            if (Parameters.Contains("CreateAccount"))
                return (bool)Parameters["CreateAccount"];
            return default(bool);
        }
        set { Parameters["CreateAccount"] = value; }
    }
    public bool CreateContact
    {
        get
        {
            if (Parameters.Contains("CreateContact"))
                return (bool)Parameters["CreateContact"];
            return default(bool);
        }
        set { Parameters["CreateContact"] = value; }
    }
    public bool CreateOpportunity
    {
        get
        {
            if (Parameters.Contains("CreateOpportunity"))
                return (bool)Parameters["CreateOpportunity"];
            return default(bool);
        }
        set { Parameters["CreateOpportunity"] = value; }
    }
    public EntityReference LeadId
    {
        get
        {
            if (Parameters.Contains("LeadId"))
                return (EntityReference)Parameters["LeadId"];
            return default(EntityReference);
        }
        set { Parameters["LeadId"] = value; }
    }
    public EntityReference OpportunityCurrencyId
    {
        get
        {
            if (Parameters.Contains("OpportunityCurrencyId"))
                return (EntityReference)Parameters["OpportunityCurrencyId"];
            return default(EntityReference);
        }
        set { Parameters["OpportunityCurrencyId"] = value; }
    }
    public EntityReference OpportunityCustomerId
    {
        get
        {
            if (Parameters.Contains("OpportunityCustomerId"))
                return (EntityReference)Parameters["OpportunityCustomerId"];
            return default(EntityReference);
        }
        set { Parameters["OpportunityCustomerId"] = value; }
    }
    public EntityReference SourceCampaignId
    {
        get
        {
            if (Parameters.Contains("SourceCampaignId"))
                return (EntityReference)Parameters["SourceCampaignId"];
            return default(EntityReference);
        }
        set { Parameters["SourceCampaignId"] = value; }
    }
    public OptionSetValue Status
    {
        get
        {
            if (Parameters.Contains("Status"))
                return (OptionSetValue)Parameters["Status"];
            return default(OptionSetValue);
        }
        set { Parameters["Status"] = value; }
    }
    public QualifyLeadRequest()
    {
        this.ResponseType = new QualifyLeadResponse();
        this.RequestName = "QualifyLead";
    }
    internal override string GetRequestBody()
    {
        Parameters["CreateAccount"] = CreateAccount;
        Parameters["CreateContact"] = CreateContact;
        Parameters["CreateOpportunity"] = CreateOpportunity;
        Parameters["LeadId"] = LeadId;
        Parameters["OpportunityCurrencyId"] = OpportunityCurrencyId;
        Parameters["OpportunityCustomerId"] = OpportunityCustomerId;
        Parameters["SourceCampaignId"] = SourceCampaignId;
        Parameters["Status"] = Status;
        return GetSoapBody();
    }
}