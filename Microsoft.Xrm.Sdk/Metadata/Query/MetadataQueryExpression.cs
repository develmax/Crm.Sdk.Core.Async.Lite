using System.Text;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata.Query;

public abstract class MetadataQueryExpression : MetadataQueryBase
{
    public MetadataFilterExpression Criteria { get; set; }
    public MetadataPropertiesExpression Properties { get; set; }
    internal string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(Util.ObjectToXml(Criteria, "j:Criteria", true));
        sb.Append(Util.ObjectToXml(Properties, "j:Properties", true));
        return sb.ToString();
    }
}