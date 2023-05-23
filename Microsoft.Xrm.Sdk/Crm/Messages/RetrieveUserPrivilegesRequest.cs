using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveUserPrivilegesRequest : OrganizationRequest
{
    public Guid UserId
    {
        get
        {
            if (Parameters.Contains("UserId"))
                return (Guid)Parameters["UserId"];
            return default(Guid);
        }
        set { Parameters["UserId"] = value; }
    }
    public RetrieveUserPrivilegesRequest()
    {
        this.ResponseType = new RetrieveUserPrivilegesResponse();
        this.RequestName = "RetrieveUserPrivileges";
    }
    internal override string GetRequestBody()
    {
        Parameters["UserId"] = UserId;
        return GetSoapBody();
    }
}