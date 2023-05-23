using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class CopyDynamicListToStaticRequest : OrganizationRequest
{
    public Guid ListId
    {
        get
        {
            if (Parameters.Contains("ListId"))
                return (Guid)Parameters["ListId"];
            return default(Guid);
        }
        set { Parameters["ListId"] = value; }
    }
    public CopyDynamicListToStaticRequest()
    {
        this.ResponseType = new CopyDynamicListToStaticResponse();
        this.RequestName = "CopyDynamicListToStatic";
    }
    internal override string GetRequestBody()
    {
        Parameters["ListId"] = ListId;
        return GetSoapBody();
    }
}