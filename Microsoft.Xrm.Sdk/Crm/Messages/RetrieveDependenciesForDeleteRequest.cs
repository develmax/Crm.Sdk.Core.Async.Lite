using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class RetrieveDependenciesForDeleteRequest : OrganizationRequest
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
    public RetrieveDependenciesForDeleteRequest()
    {
        this.ResponseType = new RetrieveDependenciesForDeleteResponse();
        this.RequestName = "RetrieveDependenciesForDelete";
    }
    internal override string GetRequestBody()
    {
        Parameters["ComponentType"] = ComponentType;
        Parameters["ObjectId"] = ObjectId;
        return GetSoapBody();
    }
}