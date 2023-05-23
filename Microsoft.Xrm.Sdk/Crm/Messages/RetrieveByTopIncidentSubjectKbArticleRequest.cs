using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveByTopIncidentSubjectKbArticleRequest : OrganizationRequest
{
    public Guid SubjectId
    {
        get
        {
            if (Parameters.Contains("SubjectId"))
                return (Guid)Parameters["SubjectId"];
            return default(Guid);
        }
        set { Parameters["SubjectId"] = value; }
    }
    public RetrieveByTopIncidentSubjectKbArticleRequest()
    {
        this.ResponseType = new RetrieveByTopIncidentSubjectKbArticleResponse();
        this.RequestName = "RetrieveByTopIncidentSubjectKbArticle";
    }
    internal override string GetRequestBody()
    {
        Parameters["SubjectId"] = SubjectId;
        return GetSoapBody();
    }
}