using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata;

public abstract class EnumAttributeMetadata : AttributeMetadata
{
    public int? DefaultFormValue { get; set; }
    public OptionSetMetadata OptionSet { get; set; }
    public EnumAttributeMetadata() { }
    public EnumAttributeMetadata(AttributeTypeCode attributeType, string schemaName)
        : base(attributeType, schemaName) { }
    internal new string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(base.ToValueXml());
        sb.Append(Util.ObjectToXml(DefaultFormValue, "h:DefaultFormValue", true));
        sb.Append(Util.ObjectToXml(OptionSet, "h:OptionSet", true));
        return sb.ToString();
    }
    static internal void LoadFromXml(XElement item, EnumAttributeMetadata meta)
    {
        if (item.Elements().Count() == 0)
            return;
        AttributeMetadata.LoadFromXml(item, meta);
        meta.DefaultFormValue = Util.LoadFromXml<int?>(item.Element(Util.ns.h + "DefaultFormValue"));
        if (item.Element(Util.ns.h + "OptionSet").Elements().Count() > 0)
            meta.OptionSet = OptionSetMetadata.LoadFromXml(item.Element(Util.ns.h + "OptionSet"));
    }
}