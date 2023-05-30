using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class SearchByKeywordsKbArticleRequest : OrganizationRequest
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
    public SearchByKeywordsKbArticleRequest()
    {
        this.ResponseType = new SearchByKeywordsKbArticleResponse();
        this.RequestName = "SearchByKeywordsKbArticle";
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