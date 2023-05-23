using System;
using System.Text;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata.Query;

public sealed class MetadataConditionExpression
{
    public MetadataConditionOperator ConditionOperator { get; set; }
    public string PropertyName { get; set; }
    public Object Value { get; set; }
    public MetadataConditionExpression() { }
    public MetadataConditionExpression(string propertyName, MetadataConditionOperator conditionOperator, Object value)
    {
        this.PropertyName = propertyName;
        this.ConditionOperator = conditionOperator;
        this.Value = value;
    }
    internal string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(Util.ObjectToXml(ConditionOperator, "j:ConditionOperator", true));
        sb.Append(Util.ObjectToXml(PropertyName, "j:PropertyName", true));
        sb.Append(Util.ObjectToXml(Value, "j:Value"));
        return sb.ToString();
    }
}