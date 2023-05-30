using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class SetLocLabelsRequest : OrganizationRequest
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
    public string AttributeName
    {
        get
        {
            if (Parameters.Contains("AttributeName"))
                return (string)Parameters["AttributeName"];
            return default(string);
        }
        set { Parameters["AttributeName"] = value; }
    }
    public LocalizedLabel[] Labels
    {
        get
        {
            if (Parameters.Contains("Labels"))
                return (LocalizedLabel[])Parameters["Labels"];
            return default(LocalizedLabel[]);
        }
        set { Parameters["Labels"] = value; }
    }
    public SetLocLabelsRequest()
    {
        this.ResponseType = new SetLocLabelsResponse();
        this.RequestName = "SetLocLabels";
    }
    internal override string GetRequestBody()
    {
        Parameters["EntityMoniker"] = EntityMoniker;
        Parameters["AttributeName"] = AttributeName;
        Parameters["Labels"] = Labels;
        return GetSoapBody();
    }
}