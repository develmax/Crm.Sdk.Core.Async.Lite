using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class SendBulkMailRequest : OrganizationRequest
{
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
    public Guid RegardingId
    {
        get
        {
            if (Parameters.Contains("RegardingId"))
                return (Guid)Parameters["RegardingId"];
            return default(Guid);
        }
        set { Parameters["RegardingId"] = value; }
    }
    public string RegardingType
    {
        get
        {
            if (Parameters.Contains("RegardingType"))
                return (string)Parameters["RegardingType"];
            return default(string);
        }
        set { Parameters["RegardingType"] = value; }
    }
    public EntityReference Sender
    {
        get
        {
            if (Parameters.Contains("Sender"))
                return (EntityReference)Parameters["Sender"];
            return default(EntityReference);
        }
        set { Parameters["Sender"] = value; }
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
    public SendBulkMailRequest()
    {
        this.ResponseType = new SendBulkMailResponse();
        this.RequestName = "SendBulkMail";
    }
    internal override string GetRequestBody()
    {
        Parameters["Query"] = Query;
        Parameters["RegardingId"] = RegardingId;
        Parameters["RegardingType"] = RegardingType;
        Parameters["Sender"] = Sender;
        Parameters["TemplateId"] = TemplateId;
        return GetSoapBody();
    }
}