using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class RetrieveDependentComponentsRequest : OrganizationRequest
{
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
    public RetrieveDependentComponentsRequest()
    {
        this.ResponseType = new RetrieveDependentComponentsResponse();
        this.RequestName = "RetrieveDependentComponents";
    }
    internal override string GetRequestBody()
    {
        Parameters["ComponentType"] = ComponentType;
        Parameters["ObjectId"] = ObjectId;
        return GetSoapBody();
    }
}