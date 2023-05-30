using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class RetrieveEntityRibbonRequest : OrganizationRequest
{
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
    public RibbonLocationFilters RibbonLocationFilter
    {
        get
        {
            if (Parameters.Contains("RibbonLocationFilter"))
                return (RibbonLocationFilters)Parameters["RibbonLocationFilter"];
            return default(RibbonLocationFilters);
        }
        set { Parameters["RibbonLocationFilter"] = value; }
    }
    public RetrieveEntityRibbonRequest()
    {
        this.ResponseType = new RetrieveEntityRibbonResponse();
        this.RequestName = "RetrieveEntityRibbon";
    }
    internal override string GetRequestBody()
    {
        Parameters["EntityName"] = EntityName;
        Parameters["RibbonLocationFilter"] = RibbonLocationFilter;
        return GetSoapBody();
    }
}