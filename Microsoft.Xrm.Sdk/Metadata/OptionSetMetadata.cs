using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata;

public sealed class OptionSetMetadata : OptionSetMetadataBase
{
    public OptionMetadataCollection Options { get; set; }
    public OptionSetMetadata()
    {
        this.Options = new OptionMetadataCollection();
    }
    public OptionSetMetadata(OptionMetadataCollection options)
        : this()
    {
        this.Options = options;
    }
    internal new string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(base.ToValueXml());
        sb.Append(Util.ObjectToXml(Options, "h:Options", true));
        return sb.ToString();
    }
    static internal new OptionSetMetadata LoadFromXml(XElement item)
    {
        OptionSetMetadata optionSetMetadata = new OptionSetMetadata();
        OptionSetMetadata.LoadFromXml(item, optionSetMetadata);
        return optionSetMetadata;
    }
    static internal void LoadFromXml(XElement item, OptionSetMetadata meta)
    {
        if (item.Elements().Count() == 0)
            return;
        OptionSetMetadataBase.LoadFromXml(item, meta);
        meta.Options = OptionMetadataCollection.LoadFromXml(item.Element(Util.ns.h + "Options"));
    }
}