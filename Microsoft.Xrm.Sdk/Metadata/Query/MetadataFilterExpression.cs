using System.Text;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata.Query;

public sealed class MetadataFilterExpression
{
    public DataCollection<MetadataConditionExpression> Conditions { get; set; }
    public LogicalOperator FilterOperator { get; set; }
    public DataCollection<MetadataFilterExpression> Filters { get; set; }
    public MetadataFilterExpression()
    {
        Conditions = new DataCollection<MetadataConditionExpression>();
        Filters = new DataCollection<MetadataFilterExpression>();
    }
    public MetadataFilterExpression(LogicalOperator filterOperator)
        : this()
    {
        this.FilterOperator = filterOperator;
    }
    internal string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(Util.ObjectToXml(Conditions.ToArray(), "j:Conditions", true));
        sb.Append(Util.ObjectToXml(FilterOperator, "j:FilterOperator", true));
        sb.Append(Util.ObjectToXml(Filters.ToArray(), "j:Filters", true));
        return sb.ToString();
    }
}