namespace Microsoft.Xrm.Sdk.Messages;

public sealed class GetValidReferencedEntitiesRequest : OrganizationRequest
{
    public string ReferencingEntityName
    {
        get
        {
            if (Parameters.Contains("ReferencingEntityName"))
                return (string)Parameters["ReferencingEntityName"];
            return default(string);
        }
        set { Parameters["ReferencingEntityName"] = value; }
    }
    public GetValidReferencedEntitiesRequest()
    {
        this.ResponseType = new GetValidReferencedEntitiesResponse();
        this.RequestName = "GetValidReferencedEntities";
    }
    internal override string GetRequestBody()
    {
        Parameters["ReferencingEntityName"] = ReferencingEntityName;
        return GetSoapBody();
    }
}