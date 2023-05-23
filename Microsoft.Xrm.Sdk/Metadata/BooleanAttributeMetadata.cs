using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata;

public sealed class BooleanAttributeMetadata : AttributeMetadata
{
    public bool? DefaultValue { get; set; }
    public string FormulaDefinition { get; set; }
    public BooleanOptionSetMetadata OptionSet { get; set; }
    public int? SourceTypeMask { get; set; }
    public BooleanAttributeMetadata() : this(null) { }
    public BooleanAttributeMetadata(string schemaName, BooleanOptionSetMetadata optionSet = null)
        : base(AttributeTypeCode.Boolean, schemaName)
    {
        this.OptionSet = optionSet;
    }
    internal new string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(base.ToValueXml());
        sb.Append(Util.ObjectToXml(DefaultValue, "h:DefaultValue", true));
        sb.Append(Util.ObjectToXml(FormulaDefinition, "h:FormulaDefinition", true));
        sb.Append(Util.ObjectToXml(OptionSet, "h:OptionSet", true));
        sb.Append(Util.ObjectToXml(SourceTypeMask, "h:SourceTypeMask", true));
        return sb.ToString();
    }
    static internal new BooleanAttributeMetadata LoadFromXml(XElement item)
    {
        BooleanAttributeMetadata booleanAttributeMetadata = new BooleanAttributeMetadata();
        AttributeMetadata.LoadFromXml(item, booleanAttributeMetadata);
        booleanAttributeMetadata.DefaultValue = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "DefaultValue"));
        booleanAttributeMetadata.FormulaDefinition = Util.LoadFromXml<string>(item.Element(Util.ns.h + "FormulaDefinition"));
        booleanAttributeMetadata.OptionSet = BooleanOptionSetMetadata.LoadFromXml(item.Element(Util.ns.h + "OptionSet"));
        booleanAttributeMetadata.SourceTypeMask = Util.LoadFromXml<int?>(item.Element(Util.ns.h + "SourceTypeMask"));
        return booleanAttributeMetadata;
    }
}