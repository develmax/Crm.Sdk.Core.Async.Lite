using System.Text;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata.Query;

public sealed class EntityQueryExpression : MetadataQueryExpression
{
    public AttributeQueryExpression AttributeQuery { get; set; }
    public LabelQueryExpression LabelQuery { get; set; }
    public RelationshipQueryExpression RelationshipQuery { get; set; }
    internal new string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(base.ToValueXml());
        sb.Append(Util.ObjectToXml(AttributeQuery, "j:AttributeQuery", true));
        sb.Append(Util.ObjectToXml(LabelQuery, "j:LabelQuery", true));
        sb.Append(Util.ObjectToXml(RelationshipQuery, "j:RelationshipQuery", true));
        return sb.ToString();
    }
}