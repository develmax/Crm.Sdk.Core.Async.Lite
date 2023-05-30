using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class RetrieveAttributeChangeHistoryRequest : OrganizationRequest
{
    public EntityReference Target
    {
        get
        {
            if (Parameters.Contains("Target"))
                return (EntityReference)Parameters["Target"];
            return default(EntityReference);
        }
        set { Parameters["Target"] = value; }
    }
    public string AttributeLogicalName
    {
        get
        {
            if (Parameters.Contains("AttributeLogicalName"))
                return (string)Parameters["AttributeLogicalName"];
            return default(string);
        }
        set { Parameters["AttributeLogicalName"] = value; }
    }
    public PagingInfo PagingInfo
    {
        get
        {
            if (Parameters.Contains("PagingInfo"))
                return (PagingInfo)Parameters["PagingInfo"];
            return default(PagingInfo);
        }
        set { Parameters["PagingInfo"] = value; }
    }
    public RetrieveAttributeChangeHistoryRequest()
    {
        this.ResponseType = new RetrieveAttributeChangeHistoryResponse();
        this.RequestName = "RetrieveAttributeChangeHistory";
    }
    internal override string GetRequestBody()
    {
        Parameters["Target"] = Target;
        Parameters["AttributeLogicalName"] = AttributeLogicalName;
        Parameters["PagingInfo"] = PagingInfo;
        return GetSoapBody();
    }
}