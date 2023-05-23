using Microsoft.Xrm.Sdk;

namespace Microsoft.Xrm.Sdk.Metadata.Query
{
    public sealed class AttributeQueryExpression : MetadataQueryExpression
    {
        internal new string ToValueXml()
        {
            return base.ToValueXml();
        }
    }
}