using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class RemoveItemCampaignRequest : OrganizationRequest
{
    public Guid CampaignId
    {
        get
        {
            if (Parameters.Contains("CampaignId"))
                return (Guid)Parameters["CampaignId"];
            return default(Guid);
        }
        set { Parameters["CampaignId"] = value; }
    }
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
    public RemoveItemCampaignRequest()
    {
        this.ResponseType = new RemoveItemCampaignResponse();
        this.RequestName = "RemoveItemCampaign";
    }
    internal override string GetRequestBody()
    {
        Parameters["CampaignId"] = CampaignId;
        Parameters["EntityId"] = EntityId;
        return GetSoapBody();
    }
}