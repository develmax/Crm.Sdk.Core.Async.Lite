using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class RemoveItemCampaignActivityRequest : OrganizationRequest
{
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
    public Guid ItemId
    {
        get
        {
            if (Parameters.Contains("ItemId"))
                return (Guid)Parameters["ItemId"];
            return default(Guid);
        }
        set { Parameters["ItemId"] = value; }
    }
    public RemoveItemCampaignActivityRequest()
    {
        this.ResponseType = new RemoveItemCampaignActivityResponse();
        this.RequestName = "RemoveItemCampaignActivity";
    }
    internal override string GetRequestBody()
    {
        Parameters["CampaignActivityId"] = CampaignActivityId;
        Parameters["ItemId"] = ItemId;
        return GetSoapBody();
    }
}