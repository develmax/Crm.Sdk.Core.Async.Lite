using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class UpdateUserSettingsSystemUserRequest : OrganizationRequest
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
    public Entity Settings
    {
        get
        {
            if (Parameters.Contains("Settings"))
                return (Entity)Parameters["Settings"];
            return default(Entity);
        }
        set { Parameters["Settings"] = value; }
    }
    public UpdateUserSettingsSystemUserRequest()
    {
        this.ResponseType = new UpdateUserSettingsSystemUserResponse();
        this.RequestName = "UpdateUserSettingsSystemUser";
    }
    internal override string GetRequestBody()
    {
        Parameters["UserId"] = UserId;
        Parameters["Settings"] = Settings;
        return GetSoapBody();
    }
}