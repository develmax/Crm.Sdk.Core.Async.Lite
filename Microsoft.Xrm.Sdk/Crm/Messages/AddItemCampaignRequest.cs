using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages
{
    public sealed class AddItemCampaignRequest : OrganizationRequest
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
        public AddItemCampaignRequest()
        {
            this.ResponseType = new AddItemCampaignResponse();
            this.RequestName = "AddItemCampaign";
        }
        internal override string GetRequestBody()
        {
            Parameters["CampaignId"] = CampaignId;
            Parameters["EntityId"] = EntityId;
            Parameters["EntityName"] = EntityName;
            return GetSoapBody();
        }
    }
}