using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class VerifyProcessStateDataRequest : OrganizationRequest
{
    public string ProcessState
    {
        get
        {
            if (Parameters.Contains("ProcessState"))
                return (string)Parameters["ProcessState"];
            return default(string);
        }
        set { Parameters["ProcessState"] = value; }
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
    public VerifyProcessStateDataRequest()
    {
        this.ResponseType = new VerifyProcessStateDataResponse();
        this.RequestName = "VerifyProcessStateData";
    }
    internal override string GetRequestBody()
    {
        Parameters["ProcessState"] = ProcessState;
        Parameters["Target"] = Target;
        return GetSoapBody();
    }
}