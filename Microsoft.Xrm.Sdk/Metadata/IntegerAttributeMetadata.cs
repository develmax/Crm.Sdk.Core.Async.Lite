using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata;

public sealed class IntegerAttributeMetadata : AttributeMetadata
{
    public const int MaxSupportedValue = 2147483647;
    public const int MinSupportedValue = -2147483648;
    public IntegerFormat? Format { get; set; }
    public string FormulaDefinition { get; set; }
    private int? _maxValue;
    public int? MaxValue
    {
        get { return _maxValue; }
        set
        {
            if (value < MinSupportedValue || value > MaxSupportedValue)
                // Should throw error?
                return;
            if (_minValue != null && value < _minValue)
                return;
            _maxValue = value;
        }
    }
    private int? _minValue;
    public int? MinValue
    {
        get { return _minValue; }
        set
        {
            if (value < MinSupportedValue || value > MaxSupportedValue)
                // Should throw error?
                return;
            if (_maxValue != null && value > _maxValue)
                return;
            _minValue = value;
        }
    }
    public int? SourceTypeMask { get; set; }
    public IntegerAttributeMetadata() : this(null) { }
    public IntegerAttributeMetadata(string schemaName)
        : base(AttributeTypeCode.Integer, schemaName) { }
    internal new string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(base.ToValueXml());
        sb.Append(Util.ObjectToXml(Format, "h:Format", true));
        sb.Append(Util.ObjectToXml(FormulaDefinition, "h:FormulaDefinition", true));
        sb.Append(Util.ObjectToXml(MaxValue, "h:MaxValue", true));
        sb.Append(Util.ObjectToXml(MinValue, "h:MinValue", true));
        sb.Append(Util.ObjectToXml(SourceTypeMask, "h:SourceTypeMask", true));
        return sb.ToString();
    }
    static internal new IntegerAttributeMetadata LoadFromXml(XElement item)
    {
        IntegerAttributeMetadata integerAttributeMetadata = new IntegerAttributeMetadata();
        AttributeMetadata.LoadFromXml(item, integerAttributeMetadata);
        integerAttributeMetadata.Format = Util.LoadFromXml<IntegerFormat?>(item.Element(Util.ns.h + "Format"));
        integerAttributeMetadata.FormulaDefinition = Util.LoadFromXml<string>(item.Element(Util.ns.h + "FormulaDefinition"));
        integerAttributeMetadata.MaxValue = Util.LoadFromXml<int?>(item.Element(Util.ns.h + "MaxValue"));
        integerAttributeMetadata.MinValue = Util.LoadFromXml<int?>(item.Element(Util.ns.h + "MinValue"));
        integerAttributeMetadata.SourceTypeMask = Util.LoadFromXml<int?>(item.Element(Util.ns.h + "SourceTypeMask"));
        return integerAttributeMetadata;
    }
}