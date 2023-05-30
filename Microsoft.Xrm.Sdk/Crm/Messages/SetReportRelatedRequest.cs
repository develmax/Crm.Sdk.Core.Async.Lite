using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class SetReportRelatedRequest : OrganizationRequest
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
    public int[] Entities
    {
        get
        {
            if (Parameters.Contains("Entities"))
                return (int[])Parameters["Entities"];
            return default(int[]);
        }
        set { Parameters["Entities"] = value; }
    }
    public int[] Categories
    {
        get
        {
            if (Parameters.Contains("Categories"))
                return (int[])Parameters["Categories"];
            return default(int[]);
        }
        set { Parameters["Categories"] = value; }
    }
    public int[] Visibility
    {
        get
        {
            if (Parameters.Contains("Visibility"))
                return (int[])Parameters["Visibility"];
            return default(int[]);
        }
        set { Parameters["Visibility"] = value; }
    }
    public SetReportRelatedRequest()
    {
        this.ResponseType = new SetReportRelatedResponse();
        this.RequestName = "SetReportRelated";
    }
    internal override string GetRequestBody()
    {
        Parameters["ReportId"] = ReportId;
        Parameters["Entities"] = Entities;
        Parameters["Categories"] = Categories;
        Parameters["Visibility"] = Visibility;
        return GetSoapBody();
    }
}