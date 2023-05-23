using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Query;

public sealed class FetchExpression : QueryBase
{
    public string Query { get; set; }
    public FetchExpression() { }
    public FetchExpression(string Query)
    {
        this.Query = Query;
    }
    internal string ToValueXml()
    {
        return Util.ObjectToXml(Query, "a:Query", true);
    }
}