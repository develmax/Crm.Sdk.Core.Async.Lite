using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class DownloadReportDefinitionRequest : OrganizationRequest
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
    public DownloadReportDefinitionRequest()
    {
        this.ResponseType = new DownloadReportDefinitionResponse();
        this.RequestName = "DownloadReportDefinition";
    }
    internal override string GetRequestBody()
    {
        Parameters["ReportId"] = ReportId;
        return GetSoapBody();
    }
}