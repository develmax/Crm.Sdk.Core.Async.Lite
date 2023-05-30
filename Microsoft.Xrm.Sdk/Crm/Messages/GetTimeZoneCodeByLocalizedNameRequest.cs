using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class GetTimeZoneCodeByLocalizedNameRequest : OrganizationRequest
{
    public int LocaleId
    {
        get
        {
            if (Parameters.Contains("LocaleId"))
                return (int)Parameters["LocaleId"];
            return default(int);
        }
        set { Parameters["LocaleId"] = value; }
    }
    public string LocalizedStandardName
    {
        get
        {
            if (Parameters.Contains("LocalizedStandardName"))
                return (string)Parameters["LocalizedStandardName"];
            return default(string);
        }
        set { Parameters["LocalizedStandardName"] = value; }
    }
    public GetTimeZoneCodeByLocalizedNameRequest()
    {
        this.ResponseType = new GetTimeZoneCodeByLocalizedNameResponse();
        this.RequestName = "GetTimeZoneCodeByLocalizedName";
    }
    internal override string GetRequestBody()
    {
        Parameters["LocaleId"] = LocaleId;
        Parameters["LocalizedStandardName"] = LocalizedStandardName;
        return GetSoapBody();
    }
}