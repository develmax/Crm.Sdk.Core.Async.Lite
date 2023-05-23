using System.Text;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata.Query;

public sealed class MetadataPropertiesExpression
{
    public bool AllProperties { get; set; }
    public DataCollection<string> PropertyNames { get; set; }
    public MetadataPropertiesExpression()
    {
        PropertyNames = new DataCollection<string>();
    }
    public MetadataPropertiesExpression(params string[] propertyNames)
        : this()
    {
        this.PropertyNames.AddRange(propertyNames);
    }
    internal string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(Util.ObjectToXml(AllProperties, "j:AllProperties", true));
        sb.Append(Util.ObjectToXml(PropertyNames.ToArray(), "j:PropertyNames", true));
        return sb.ToString();
    }
}