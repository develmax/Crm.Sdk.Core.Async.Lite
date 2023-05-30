using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class InitializeFromRequest : OrganizationRequest
{
    public EntityReference EntityMoniker
    {
        get
        {
            if (Parameters.Contains("EntityMoniker"))
                return (EntityReference)Parameters["EntityMoniker"];
            return default(EntityReference);
        }
        set { Parameters["EntityMoniker"] = value; }
    }
    public string TargetEntityName
    {
        get
        {
            if (Parameters.Contains("TargetEntityName"))
                return (string)Parameters["TargetEntityName"];
            return default(string);
        }
        set { Parameters["TargetEntityName"] = value; }
    }
    public TargetFieldType TargetFieldType
    {
        get
        {
            if (Parameters.Contains("TargetFieldType"))
                return (TargetFieldType)Parameters["TargetFieldType"];
            return default(TargetFieldType);
        }
        set { Parameters["TargetFieldType"] = value; }
    }
    public InitializeFromRequest()
    {
        this.ResponseType = new InitializeFromResponse();
        this.RequestName = "InitializeFrom";
    }
    internal override string GetRequestBody()
    {
        Parameters["EntityMoniker"] = EntityMoniker;
        Parameters["TargetEntityName"] = TargetEntityName;
        Parameters["TargetFieldType"] = TargetFieldType;
        return GetSoapBody();
    }
}