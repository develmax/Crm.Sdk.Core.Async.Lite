using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class MakeAvailableToOrganizationReportRequest : OrganizationRequest
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
    public MakeAvailableToOrganizationReportRequest()
    {
        this.ResponseType = new MakeAvailableToOrganizationReportResponse();
        this.RequestName = "MakeAvailableToOrganizationReport";
    }
    internal override string GetRequestBody()
    {
        Parameters["ReportId"] = ReportId;
        return GetSoapBody();
    }
}