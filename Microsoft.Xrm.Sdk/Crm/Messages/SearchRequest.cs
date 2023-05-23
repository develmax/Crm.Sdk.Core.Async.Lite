using Microsoft.Crm.Sdk.OData.Messages;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class SearchRequest : OrganizationRequest
{
    public AppointmentRequest AppointmentRequest
    {
        get
        {
            if (Parameters.Contains("AppointmentRequest"))
                return (AppointmentRequest)Parameters["AppointmentRequest"];
            return default(AppointmentRequest);
        }
        set { Parameters["AppointmentRequest"] = value; }
    }
    public SearchRequest()
    {
        this.ResponseType = new SearchResponse();
        this.RequestName = "Search";
    }
    internal override string GetRequestBody()
    {
        Parameters["AppointmentRequest"] = AppointmentRequest;
        return GetSoapBody();
    }
}