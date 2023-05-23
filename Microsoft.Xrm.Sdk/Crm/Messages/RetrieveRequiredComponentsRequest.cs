using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveRequiredComponentsRequest : OrganizationRequest
{
    public Guid ObjectId
    {
        get
        {
            if (Parameters.Contains("ObjectId"))
                return (Guid)Parameters["ObjectId"];
            return default(Guid);
        }
        set { Parameters["ObjectId"] = value; }
    }
    public int ComponentType
    {
        get
        {
            if (Parameters.Contains("ComponentType"))
                return (int)Parameters["ComponentType"];
            return default(int);
        }
        set { Parameters["ComponentType"] = value; }
    }
    public RetrieveRequiredComponentsRequest()
    {
        this.ResponseType = new RetrieveRequiredComponentsResponse();
        this.RequestName = "RetrieveRequiredComponents";
    }
    internal override string GetRequestBody()
    {
        Parameters["ObjectId"] = ObjectId;
        Parameters["ComponentType"] = ComponentType;
        return GetSoapBody();
    }
}