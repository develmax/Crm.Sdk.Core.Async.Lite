using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class BulkDetectDuplicatesRequest : OrganizationRequest
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
    public QueryBase Query
    {
        get
        {
            if (Parameters.Contains("Query"))
                return (QueryBase)Parameters["Query"];
            return default(QueryBase);
        }
        set { Parameters["Query"] = value; }
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
    public DateTime RecurrenceStartTime
    {
        get
        {
            if (Parameters.Contains("RecurrenceStartTime"))
                return (DateTime)Parameters["RecurrenceStartTime"];
            return default(DateTime);
        }
        set { Parameters["RecurrenceStartTime"] = value; }
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
    public Guid TemplateId
    {
        get
        {
            if (Parameters.Contains("TemplateId"))
                return (Guid)Parameters["TemplateId"];
            return default(Guid);
        }
        set { Parameters["TemplateId"] = value; }
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
    public BulkDetectDuplicatesRequest()
    {
        this.ResponseType = new BulkDetectDuplicatesResponse();
        this.RequestName = "BulkDetectDuplicates";
    }
    internal override string GetRequestBody()
    {
        Parameters["CCRecipients"] = CCRecipients;
        Parameters["JobName"] = JobName;
        Parameters["Query"] = Query;
        Parameters["RecurrencePattern"] = RecurrencePattern;
        Parameters["RecurrenceStartTime"] = RecurrenceStartTime;
        Parameters["SendEmailNotification"] = SendEmailNotification;
        Parameters["TemplateId"] = TemplateId;
        Parameters["ToRecipients"] = ToRecipients;
        return GetSoapBody();
    }
}