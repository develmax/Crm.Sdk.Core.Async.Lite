using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveLocLabelsRequest : OrganizationRequest
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
    public bool IncludeUnpublished
    {
        get
        {
            if (Parameters.Contains("IncludeUnpublished"))
                return (bool)Parameters["IncludeUnpublished"];
            return default(bool);
        }
        set { Parameters["IncludeUnpublished"] = value; }
    }
    public RetrieveLocLabelsRequest()
    {
        this.ResponseType = new RetrieveLocLabelsResponse();
        this.RequestName = "RetrieveLocLabels";
    }
    internal override string GetRequestBody()
    {
        Parameters["EntityMoniker"] = EntityMoniker;
        Parameters["AttributeName"] = AttributeName;
        Parameters["IncludeUnpublished"] = IncludeUnpublished;
        return GetSoapBody();
    }
}