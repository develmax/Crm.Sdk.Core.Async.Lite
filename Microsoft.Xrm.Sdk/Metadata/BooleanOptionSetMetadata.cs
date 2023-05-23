using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata;

public sealed class BooleanOptionSetMetadata : OptionSetMetadataBase
{
    public OptionMetadata FalseOption { get; set; }
    public OptionMetadata TrueOption { get; set; }
    public BooleanOptionSetMetadata() { }
    public BooleanOptionSetMetadata(OptionMetadata trueOption, OptionMetadata falseOption)
    {
        this.FalseOption = falseOption;
        this.TrueOption = trueOption;
    }
    internal new string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(base.ToValueXml());
        sb.Append(Util.ObjectToXml(FalseOption, "h:FalseOption", true));
        sb.Append(Util.ObjectToXml(TrueOption, "h:TrueOption", true));
        return sb.ToString();
    }
    static internal new BooleanOptionSetMetadata LoadFromXml(XElement item)
    {
        BooleanOptionSetMetadata booleanOptionSetMetadata = new BooleanOptionSetMetadata();
        BooleanOptionSetMetadata.LoadFromXml(item, booleanOptionSetMetadata);
        return booleanOptionSetMetadata;
    }
    static internal void LoadFromXml(XElement item, BooleanOptionSetMetadata meta)
    {
        if (item.Elements().Count() == 0)
            return;
        OptionSetMetadataBase.LoadFromXml(item, meta);
        meta.FalseOption = OptionMetadata.LoadFromXml(item.Element(Util.ns.h + "FalseOption"));
        meta.TrueOption = OptionMetadata.LoadFromXml(item.Element(Util.ns.h + "TrueOption"));
    }
}