using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class RetrieveRecordWallRequest : OrganizationRequest
{
    public EntityReference Entity
    {
        get
        {
            if (Parameters.Contains("Entity"))
                return (EntityReference)Parameters["Entity"];
            return default(EntityReference);
        }
        set { Parameters["Entity"] = value; }
    }
    public int PageNumber
    {
        get
        {
            if (Parameters.Contains("PageNumber"))
                return (int)Parameters["PageNumber"];
            return default(int);
        }
        set { Parameters["PageNumber"] = value; }
    }
    public int PageSize
    {
        get
        {
            if (Parameters.Contains("PageSize"))
                return (int)Parameters["PageSize"];
            return default(int);
        }
        set { Parameters["PageSize"] = value; }
    }
    public int CommentsPerPost
    {
        get
        {
            if (Parameters.Contains("CommentsPerPost"))
                return (int)Parameters["CommentsPerPost"];
            return default(int);
        }
        set { Parameters["CommentsPerPost"] = value; }
    }
    public DateTime StartDate
    {
        get
        {
            if (Parameters.Contains("StartDate"))
                return (DateTime)Parameters["StartDate"];
            return default(DateTime);
        }
        set { Parameters["StartDate"] = value; }
    }
    public DateTime EndDate
    {
        get
        {
            if (Parameters.Contains("EndDate"))
                return (DateTime)Parameters["EndDate"];
            return default(DateTime);
        }
        set { Parameters["EndDate"] = value; }
    }
    public OptionSetValue Type
    {
        get
        {
            if (Parameters.Contains("Type"))
                return (OptionSetValue)Parameters["Type"];
            return default(OptionSetValue);
        }
        set { Parameters["Type"] = value; }
    }
    public OptionSetValue Source
    {
        get
        {
            if (Parameters.Contains("Source"))
                return (OptionSetValue)Parameters["Source"];
            return default(OptionSetValue);
        }
        set { Parameters["Source"] = value; }
    }
    public RetrieveRecordWallRequest()
    {
        this.ResponseType = new RetrieveRecordWallResponse();
        this.RequestName = "RetrieveRecordWall";
    }
    internal override string GetRequestBody()
    {
        Parameters["Entity"] = Entity;
        Parameters["PageNumber"] = PageNumber;
        Parameters["PageSize"] = PageSize;
        Parameters["CommentsPerPost"] = CommentsPerPost;
        Parameters["StartDate"] = StartDate;
        Parameters["EndDate"] = EndDate;
        Parameters["Type"] = Type;
        Parameters["Source"] = Source;
        return GetSoapBody();
    }
}