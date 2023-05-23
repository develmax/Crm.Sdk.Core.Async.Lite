namespace Microsoft.Xrm.Sdk.Messages;

public sealed class RetrieveAllOptionSetsRequest : OrganizationRequest
{
    public bool RetrieveAsIfPublished
    {
        get
        {
            if (Parameters.Contains("RetrieveAsIfPublished"))
                return (bool)Parameters["RetrieveAsIfPublished"];
            return default(bool);
        }
        set { Parameters["RetrieveAsIfPublished"] = value; }
    }
    public RetrieveAllOptionSetsRequest()
    {
        this.ResponseType = new RetrieveAllOptionSetsResponse();
        this.RequestName = "RetrieveAllOptionSets";
    }
    internal override string GetRequestBody()
    {
        Parameters["RetrieveAsIfPublished"] = RetrieveAsIfPublished;
        return GetSoapBody();
    }
}