using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class ExecuteFetchRequest : OrganizationRequest
{
    public string FetchXml
    {
        get
        {
            if (Parameters.Contains("FetchXml"))
                return (string)Parameters["FetchXml"];
            return default(string);
        }
        set { Parameters["FetchXml"] = value; }
    }
    public ExecuteFetchRequest()
    {
        this.ResponseType = new ExecuteFetchResponse();
        this.RequestName = "ExecuteFetch";
    }
    internal override string GetRequestBody()
    {
        Parameters["FetchXml"] = FetchXml;
        return GetSoapBody();
    }
}