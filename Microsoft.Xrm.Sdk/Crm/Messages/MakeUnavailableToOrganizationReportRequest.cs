using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class MakeUnavailableToOrganizationReportRequest : OrganizationRequest
{
    public Guid ReportId
    {
        get
        {
            if (Parameters.Contains("ReportId"))
                return (Guid)Parameters["ReportId"];
            return default(Guid);
        }
        set { Parameters["ReportId"] = value; }
    }
    public MakeUnavailableToOrganizationReportRequest()
    {
        this.ResponseType = new MakeUnavailableToOrganizationReportResponse();
        this.RequestName = "MakeUnavailableToOrganizationReport";
    }
    internal override string GetRequestBody()
    {
        Parameters["ReportId"] = ReportId;
        return GetSoapBody();
    }
}