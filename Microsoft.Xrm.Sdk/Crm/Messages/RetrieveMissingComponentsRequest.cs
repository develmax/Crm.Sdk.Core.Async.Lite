using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveMissingComponentsRequest : OrganizationRequest
{
    public byte[] CustomizationFile
    {
        get
        {
            if (Parameters.Contains("CustomizationFile"))
                return (byte[])Parameters["CustomizationFile"];
            return default(byte[]);
        }
        set { Parameters["CustomizationFile"] = value; }
    }
    public RetrieveMissingComponentsRequest()
    {
        this.ResponseType = new RetrieveMissingComponentsResponse();
        this.RequestName = "RetrieveMissingComponents";
    }
    internal override string GetRequestBody()
    {
        Parameters["CustomizationFile"] = CustomizationFile;
        return GetSoapBody();
    }
}