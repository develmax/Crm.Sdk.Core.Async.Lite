using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class IsComponentCustomizableRequest : OrganizationRequest
{
    public Guid ComponentId
    {
        get
        {
            if (Parameters.Contains("ComponentId"))
                return (Guid)Parameters["ComponentId"];
            return default(Guid);
        }
        set { Parameters["ComponentId"] = value; }
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
    public IsComponentCustomizableRequest()
    {
        this.ResponseType = new IsComponentCustomizableResponse();
        this.RequestName = "IsComponentCustomizable";
    }
    internal override string GetRequestBody()
    {
        Parameters["ComponentId"] = ComponentId;
        Parameters["ComponentType"] = ComponentType;
        return GetSoapBody();
    }
}