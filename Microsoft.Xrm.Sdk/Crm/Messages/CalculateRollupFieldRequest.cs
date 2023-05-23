using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class CalculateRollupFieldRequest : OrganizationRequest
{
    public string FieldName
    {
        get
        {
            if (Parameters.Contains("FieldName"))
                return (string)Parameters["FieldName"];
            return default(string);
        }
        set { Parameters["FieldName"] = value; }
    }
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
    public CalculateRollupFieldRequest()
    {
        this.ResponseType = new CalculateRollupFieldResponse();
        this.RequestName = "CalculateRollupField";
    }
    internal override string GetRequestBody()
    {
        Parameters["FieldName"] = FieldName;
        Parameters["Target"] = Target;
        return GetSoapBody();
    }
}