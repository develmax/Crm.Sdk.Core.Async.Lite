using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class BulkDeleteRequest : OrganizationRequest
{
    public Guid[] CCRecipients
    {
        get
        {
            if (Parameters.Contains("CCRecipients"))
                return (Guid[])Parameters["CCRecipients"];
            return default(Guid[]);
        }
        set { Parameters["CCRecipients"] = value; }
    }
    public string JobName
    {
        get
        {
            if (Parameters.Contains("JobName"))
                return (string)Parameters["JobName"];
            return default(string);
        }
        set { Parameters["JobName"] = value; }
    }
    public QueryExpression[] QuerySet
    {
        get
        {
            if (Parameters.Contains("QuerySet"))
                return (QueryExpression[])Parameters["QuerySet"];
            return default(QueryExpression[]);
        }
        set { Parameters["QuerySet"] = value; }
    }
    public string RecurrencePattern
    {
        get
        {
            if (Parameters.Contains("RecurrencePattern"))
                return (string)Parameters["RecurrencePattern"];
            return default(string);
        }
        set { Parameters["RecurrencePattern"] = value; }
    }
    public bool SendEmailNotification
    {
        get
        {
            if (Parameters.Contains("SendEmailNotification"))
                return (bool)Parameters["SendEmailNotification"];
            return default(bool);
        }
        set { Parameters["SendEmailNotification"] = value; }
    }
    public Guid? SourceImportId
    {
        get
        {
            if (Parameters.Contains("SourceImportId"))
                return (Guid?)Parameters["SourceImportId"];
            return default(Guid?);
        }
        set { Parameters["SourceImportId"] = value; }
    }
    public DateTime StartDateTime
    {
        get
        {
            if (Parameters.Contains("StartDateTime"))
                return (DateTime)Parameters["StartDateTime"];
            return default(DateTime);
        }
        set { Parameters["StartDateTime"] = value; }
    }
    public Guid[] ToRecipients
    {
        get
        {
            if (Parameters.Contains("ToRecipients"))
                return (Guid[])Parameters["ToRecipients"];
            return default(Guid[]);
        }
        set { Parameters["ToRecipients"] = value; }
    }
    public BulkDeleteRequest()
    {
        this.ResponseType = new BulkDeleteResponse();
        this.RequestName = "BulkDelete";
    }
    internal override string GetRequestBody()
    {
        Parameters["CCRecipients"] = CCRecipients;
        Parameters["JobName"] = JobName;
        Parameters["QuerySet"] = QuerySet;
        Parameters["RecurrencePattern"] = RecurrencePattern;
        Parameters["SendEmailNotification"] = SendEmailNotification;
        Parameters["SourceImportId"] = SourceImportId;
        Parameters["StartDateTime"] = StartDateTime;
        Parameters["ToRecipients"] = ToRecipients;
        return GetSoapBody();
    }
}