using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class ValidateSavedQueryRequest : OrganizationRequest
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
    public int QueryType
    {
        get
        {
            if (Parameters.Contains("QueryType"))
                return (int)Parameters["QueryType"];
            return default(int);
        }
        set { Parameters["QueryType"] = value; }
    }
    public ValidateSavedQueryRequest()
    {
        this.ResponseType = new ValidateSavedQueryResponse();
        this.RequestName = "ValidateSavedQuery";
    }
    internal override string GetRequestBody()
    {
        Parameters["FetchXml"] = FetchXml;
        Parameters["QueryType"] = QueryType;
        return GetSoapBody();
    }
}