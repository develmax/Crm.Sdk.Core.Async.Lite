using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class SetParentBusinessUnitRequest : OrganizationRequest
{
    public Guid BusinessUnitId
    {
        get
        {
            if (Parameters.Contains("BusinessUnitId"))
                return (Guid)Parameters["BusinessUnitId"];
            return default(Guid);
        }
        set { Parameters["BusinessUnitId"] = value; }
    }
    public Guid ParentId
    {
        get
        {
            if (Parameters.Contains("ParentId"))
                return (Guid)Parameters["ParentId"];
            return default(Guid);
        }
        set { Parameters["ParentId"] = value; }
    }
    public SetParentBusinessUnitRequest()
    {
        this.ResponseType = new SetParentBusinessUnitResponse();
        this.RequestName = "SetParentBusinessUnit";
    }
    internal override string GetRequestBody()
    {
        Parameters["BusinessUnitId"] = BusinessUnitId;
        Parameters["ParentId"] = ParentId;
        return GetSoapBody();
    }
}