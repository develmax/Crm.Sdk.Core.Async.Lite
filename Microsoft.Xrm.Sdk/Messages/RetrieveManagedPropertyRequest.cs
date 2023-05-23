using System;

namespace Microsoft.Xrm.Sdk.Messages;

public sealed class RetrieveManagedPropertyRequest : OrganizationRequest
{
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
    public RetrieveManagedPropertyRequest()
    {
        this.ResponseType = new RetrieveManagedPropertyResponse();
        this.RequestName = "RetrieveManagedProperty";
    }
    internal override string GetRequestBody()
    {
        Parameters["LogicalName"] = LogicalName;
        Parameters["MetadataId"] = MetadataId;
        return GetSoapBody();
    }
}