using System.Text;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata.Query;

public sealed class LabelQueryExpression : MetadataQueryBase
{
    public DataCollection<int> FilterLanguages { get; set; }
    public int? MissingLabelBehavior { get; set; }
    public LabelQueryExpression()
    {
        FilterLanguages = new DataCollection<int>();
    }
    internal string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(Util.ObjectToXml(FilterLanguages.ToArray(), "j:FilterLanguages", true));
        sb.Append(Util.ObjectToXml(MissingLabelBehavior, "j:MissingLabelBehavior", true));
        return sb.ToString();
    }
}