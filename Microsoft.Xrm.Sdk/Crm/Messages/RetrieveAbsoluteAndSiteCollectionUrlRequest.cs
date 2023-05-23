using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveAbsoluteAndSiteCollectionUrlRequest : OrganizationRequest
{
    public Entity Target
    {
        get
        {
            if (Parameters.Contains("Target"))
                return (Entity)Parameters["Target"];
            return default(Entity);
        }
        set { Parameters["Target"] = value; }
    }
    public RetrieveAbsoluteAndSiteCollectionUrlRequest()
    {
        this.ResponseType = new RetrieveAbsoluteAndSiteCollectionUrlResponse();
        this.RequestName = "RetrieveAbsoluteAndSiteCollectionUrl";
    }
    internal override string GetRequestBody()
    {
        Parameters["Target"] = Target;
        return GetSoapBody();
    }
}