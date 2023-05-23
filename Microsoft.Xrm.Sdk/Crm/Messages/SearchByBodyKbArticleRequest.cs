using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class SearchByBodyKbArticleRequest : OrganizationRequest
{
    public QueryBase QueryExpression
    {
        get
        {
            if (Parameters.Contains("QueryExpression"))
                return (QueryBase)Parameters["QueryExpression"];
            return default(QueryBase);
        }
        set { Parameters["QueryExpression"] = value; }
    }
    public string SearchText
    {
        get
        {
            if (Parameters.Contains("SearchText"))
                return (string)Parameters["SearchText"];
            return default(string);
        }
        set { Parameters["SearchText"] = value; }
    }
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
    public bool UseInflection
    {
        get
        {
            if (Parameters.Contains("UseInflection"))
                return (bool)Parameters["UseInflection"];
            return default(bool);
        }
        set { Parameters["UseInflection"] = value; }
    }
    public SearchByBodyKbArticleRequest()
    {
        this.ResponseType = new SearchByBodyKbArticleResponse();
        this.RequestName = "SearchByBodyKbArticle";
    }
    internal override string GetRequestBody()
    {
        Parameters["QueryExpression"] = QueryExpression;
        Parameters["SearchText"] = SearchText;
        Parameters["SubjectId"] = SubjectId;
        Parameters["UseInflection"] = UseInflection;
        return GetSoapBody();
    }
}