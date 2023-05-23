using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class CopySystemFormRequest : OrganizationRequest
{
    public Guid SourceId
    {
        get
        {
            if (Parameters.Contains("SourceId"))
                return (Guid)Parameters["SourceId"];
            return default(Guid);
        }
        set { Parameters["SourceId"] = value; }
    }
    public Entity Target
    {
        get
        {
            if (Parameters.Contains("Target"))
                return (Entity)Parameters["Target"];
            return default(Entity);
        }
        set { Parameters["Target"] = value; }
    }
    public CopySystemFormRequest()
    {
        this.ResponseType = new CopySystemFormResponse();
        this.RequestName = "CopySystemForm";
    }
    internal override string GetRequestBody()
    {
        Parameters["SourceId"] = SourceId;
        Parameters["Target"] = Target;
        return GetSoapBody();
    }
}