using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class RetrieveByTopIncidentProductKbArticleRequest : OrganizationRequest
{
    public Guid ProductId
    {
        get
        {
            if (Parameters.Contains("ProductId"))
                return (Guid)Parameters["ProductId"];
            return default(Guid);
        }
        set { Parameters["ProductId"] = value; }
    }
    public RetrieveByTopIncidentProductKbArticleRequest()
    {
        this.ResponseType = new RetrieveByTopIncidentProductKbArticleResponse();
        this.RequestName = "RetrieveByTopIncidentProductKbArticle";
    }
    internal override string GetRequestBody()
    {
        Parameters["ProductId"] = ProductId;
        return GetSoapBody();
    }
}