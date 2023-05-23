using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class CopyCampaignResponseRequest : OrganizationRequest
{
    public EntityReference CampaignResponseId
    {
        get
        {
            if (Parameters.Contains("CampaignResponseId"))
                return (EntityReference)Parameters["CampaignResponseId"];
            return default(EntityReference);
        }
        set { Parameters["CampaignResponseId"] = value; }
    }
    public CopyCampaignResponseRequest()
    {
        this.ResponseType = new CopyCampaignResponseResponse();
        this.RequestName = "CopyCampaignResponse";
    }
    internal override string GetRequestBody()
    {
        Parameters["CampaignResponseId"] = CampaignResponseId;
        return GetSoapBody();
    }
}