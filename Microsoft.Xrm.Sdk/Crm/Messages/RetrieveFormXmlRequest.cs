using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveFormXmlRequest : OrganizationRequest
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
    public RetrieveFormXmlRequest()
    {
        this.ResponseType = new RetrieveFormXmlResponse();
        this.RequestName = "RetrieveFormXml";
    }
    internal override string GetRequestBody()
    {
        Parameters["EntityName"] = EntityName;
        return GetSoapBody();
    }
}