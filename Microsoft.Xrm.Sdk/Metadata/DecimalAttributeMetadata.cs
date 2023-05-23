using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata;

public sealed class DecimalAttributeMetadata : AttributeMetadata
{

    public const int MaxSupportedPrecision = 10;
    public const int MinSupportedPrecision = 0;
    public const decimal MaxSupportedValue = 100000000000;
    public const decimal MinSupportedValue = -100000000000;
    public string FormulaDefinition { get; set; }
    public ImeMode? ImeMode { get; set; }
    private decimal? _maxValue;
    public decimal? MaxValue
    {
        get { return _maxValue; }
        set
        {
            if (value < MinSupportedValue || value > MaxSupportedValue)
                // Should throw error?
                return;
            if (_minValue != null && value < _minValue)
                _maxValue = value;
        }
    }
    private decimal? _minValue;
    public decimal? MinValue
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
    private int? _precision;
    public int? Precision
    {
        get { return _precision; }
        set
        {
            if (value < MinSupportedPrecision || value > MaxSupportedPrecision)
                // Should throw error?
                return;
            _precision = value;
        }
    }
    public int? SourceTypeMask { get; set; }
    public DecimalAttributeMetadata() : this(null) { }
    public DecimalAttributeMetadata(string schemaName)
        : base(AttributeTypeCode.Decimal, schemaName) { }
    internal new string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(base.ToValueXml());
        sb.Append(Util.ObjectToXml(ImeMode, "h:FormulaDefinition", true));
        sb.Append(Util.ObjectToXml(ImeMode, "h:ImeMode", true));
        sb.Append(Util.ObjectToXml(MaxValue, "h:MaxValue", true));
        sb.Append(Util.ObjectToXml(MinValue, "h:MinValue", true));
        sb.Append(Util.ObjectToXml(Precision, "h:Precision", true));
        sb.Append(Util.ObjectToXml(SourceTypeMask, "h:SourceTypeMask", true));
        return sb.ToString();
    }
    static internal new DecimalAttributeMetadata LoadFromXml(XElement item)
    {
        DecimalAttributeMetadata decimalAttributeMetadata = new DecimalAttributeMetadata();
        AttributeMetadata.LoadFromXml(item, decimalAttributeMetadata);
        decimalAttributeMetadata.FormulaDefinition = Util.LoadFromXml<string>(item.Element(Util.ns.h + "FormulaDefinition"));
        decimalAttributeMetadata.ImeMode = Util.LoadFromXml<ImeMode?>(item.Element(Util.ns.h + "ImeMode"));
        decimalAttributeMetadata.MaxValue = Util.LoadFromXml<decimal?>(item.Element(Util.ns.h + "MaxValue"));
        decimalAttributeMetadata.MinValue = Util.LoadFromXml<decimal?>(item.Element(Util.ns.h + "MinValue"));
        decimalAttributeMetadata.Precision = Util.LoadFromXml<int?>(item.Element(Util.ns.h + "Precision"));
        decimalAttributeMetadata.SourceTypeMask = Util.LoadFromXml<int?>(item.Element(Util.ns.h + "SourceTypeMask"));
        return decimalAttributeMetadata;
    }
}