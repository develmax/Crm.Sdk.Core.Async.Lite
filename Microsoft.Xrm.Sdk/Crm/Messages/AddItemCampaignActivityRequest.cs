using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class AddItemCampaignActivityRequest : OrganizationRequest
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
    public string EntityName
    {
        get
        {
            if (Parameters.Contains("EntityName"))
                return (string)Parameters["EntityName"];
            return default(string);
        }
        set { Parameters["EntityName"] = value; }
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
    public AddItemCampaignActivityRequest()
    {
        this.ResponseType = new AddItemCampaignActivityResponse();
        this.RequestName = "AddItemCampaignActivity";
    }
    internal override string GetRequestBody()
    {
        Parameters["CampaignActivityId"] = CampaignActivityId;
        Parameters["EntityName"] = EntityName;
        Parameters["ItemId"] = ItemId;
        return GetSoapBody();
    }
}