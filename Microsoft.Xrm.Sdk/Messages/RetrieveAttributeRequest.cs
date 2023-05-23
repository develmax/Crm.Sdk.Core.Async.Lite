using System;

namespace Microsoft.Xrm.Sdk.Messages;

public sealed class RetrieveAttributeRequest : OrganizationRequest
{
    public int ColumnNumber
    {
        get
        {
            if (Parameters.Contains("ColumnNumber"))
                return (int)Parameters["ColumnNumber"];
            return default(int);
        }
        set { Parameters["ColumnNumber"] = value; }
    }
    public string EntityLogicalName
    {
        get
        {
            if (Parameters.Contains("EntityLogicalName"))
                return (string)Parameters["EntityLogicalName"];
            return default(string);
        }
        set { Parameters["EntityLogicalName"] = value; }
    }
    public string LogicalName
    {
        get
        {
            if (Parameters.Contains("LogicalName"))
                return (string)Parameters["LogicalName"];
            return default(string);
        }
        set { Parameters["LogicalName"] = value; }
    }
    public Guid MetadataId
    {
        get
        {
            if (Parameters.Contains("MetadataId"))
                return (Guid)Parameters["MetadataId"];
            return default(Guid);
        }
        set { Parameters["MetadataId"] = value; }
    }
    public bool RetrieveAsIfPublished
    {
        get
        {
            if (Parameters.Contains("RetrieveAsIfPublished"))
                return (bool)Parameters["RetrieveAsIfPublished"];
            return default(bool);
        }
        set { Parameters["RetrieveAsIfPublished"] = value; }
    }
    public RetrieveAttributeRequest()
    {
        this.ResponseType = new RetrieveAttributeResponse();
        this.RequestName = "RetrieveAttribute";
    }
    internal override string GetRequestBody()
    {
        Parameters["ColumnNumber"] = ColumnNumber;
        Parameters["EntityLogicalName"] = EntityLogicalName;
        Parameters["LogicalName"] = LogicalName;
        Parameters["MetadataId"] = MetadataId;
        Parameters["RetrieveAsIfPublished"] = RetrieveAsIfPublished;
        return GetSoapBody();
    }
}