namespace Microsoft.Xrm.Sdk.Messages;

public sealed class GetValidReferencingEntitiesRequest : OrganizationRequest
{
    public string ReferencedEntityName
    {
        get
        {
            if (Parameters.Contains("ReferencedEntityName"))
                return (string)Parameters["ReferencedEntityName"];
            return default(string);
        }
        set { Parameters["ReferencedEntityName"] = value; }
    }
    public GetValidReferencingEntitiesRequest()
    {
        this.ResponseType = new GetValidReferencingEntitiesResponse();
        this.RequestName = "GetValidReferencingEntities";
    }
    internal override string GetRequestBody()
    {
        Parameters["ReferencedEntityName"] = ReferencedEntityName;
        return GetSoapBody();
    }
}