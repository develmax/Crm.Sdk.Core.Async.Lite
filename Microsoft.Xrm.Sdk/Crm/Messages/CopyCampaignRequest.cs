using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class CopyCampaignRequest : OrganizationRequest
{
    public Guid BaseCampaign
    {
        get
        {
            if (Parameters.Contains("BaseCampaign"))
                return (Guid)Parameters["BaseCampaign"];
            return default(Guid);
        }
        set { Parameters["BaseCampaign"] = value; }
    }
    public bool SaveAsTemplate
    {
        get
        {
            if (Parameters.Contains("SaveAsTemplate"))
                return (bool)Parameters["SaveAsTemplate"];
            return default(bool);
        }
        set { Parameters["SaveAsTemplate"] = value; }
    }
    public CopyCampaignRequest()
    {
        this.ResponseType = new CopyCampaignResponse();
        this.RequestName = "CopyCampaign";
    }
    internal override string GetRequestBody()
    {
        Parameters["BaseCampaign"] = BaseCampaign;
        Parameters["SaveAsTemplate"] = SaveAsTemplate;
        return GetSoapBody();
    }
}