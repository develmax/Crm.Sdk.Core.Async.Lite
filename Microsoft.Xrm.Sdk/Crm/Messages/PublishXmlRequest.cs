using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class PublishXmlRequest : OrganizationRequest
{
    public string ParameterXml
    {
        get
        {
            if (Parameters.Contains("ParameterXml"))
                return (string)Parameters["ParameterXml"];
            return default(string);
        }
        set { Parameters["ParameterXml"] = value; }
    }
    public PublishXmlRequest()
    {
        this.ResponseType = new PublishXmlResponse();
        this.RequestName = "PublishXml";
    }
    internal override string GetRequestBody()
    {
        Parameters["ParameterXml"] = ParameterXml;
        return GetSoapBody();
    }
}