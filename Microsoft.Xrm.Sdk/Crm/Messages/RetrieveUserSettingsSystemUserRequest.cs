using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveUserSettingsSystemUserRequest : OrganizationRequest
{
    public ColumnSet ColumnSet
    {
        get
        {
            if (Parameters.Contains("ColumnSet"))
                return (ColumnSet)Parameters["ColumnSet"];
            return default(ColumnSet);
        }
        set { Parameters["ColumnSet"] = value; }
    }
    public Guid EntityId
    {
        get
        {
            if (Parameters.Contains("EntityId"))
                return (Guid)Parameters["EntityId"];
            return default(Guid);
        }
        set { Parameters["EntityId"] = value; }
    }
    public RetrieveUserSettingsSystemUserRequest()
    {
        this.ResponseType = new RetrieveUserSettingsSystemUserResponse();
        this.RequestName = "RetrieveUserSettingsSystemUser";
    }
    internal override string GetRequestBody()
    {
        Parameters["ColumnSet"] = ColumnSet;
        Parameters["EntityId"] = EntityId;
        return GetSoapBody();
    }
}