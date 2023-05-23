using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata;

public sealed class MoneyAttributeMetadata : AttributeMetadata
{
    public const int MaxSupportedPrecision = 4;
    public const int MinSupportedPrecision = 0;
    public const double MaxSupportedValue = 922337000000000;
    public const double MinSupportedValue = -922337000000000;
    public string CalculationOf { get; set; }
    public string FormulaDefinition { get; set; }
    public ImeMode? ImeMode { get; set; }
    public bool? IsBaseCurrency { get; set; }
    private double? _maxValue;
    public double? MaxValue
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
    private double? _minValue;
    public double? MinValue
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
    public int? PrecisionSource { get; set; }
    public int? SourceTypeMask { get; set; }

    public MoneyAttributeMetadata() : this(null) { }
    public MoneyAttributeMetadata(string schemaName)
        : base(AttributeTypeCode.Money, schemaName) { }
    internal new string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(base.ToValueXml());
        sb.Append(Util.ObjectToXml(CalculationOf, "h:CalculationOf", true));
        sb.Append(Util.ObjectToXml(FormulaDefinition, "h:FormulaDefinition", true));
        sb.Append(Util.ObjectToXml(ImeMode, "h:ImeMode", true));
        sb.Append(Util.ObjectToXml(IsBaseCurrency, "h:IsBaseCurrency", true));
        sb.Append(Util.ObjectToXml(MaxValue, "h:MaxValue", true));
        sb.Append(Util.ObjectToXml(MinValue, "h:MinValue", true));
        sb.Append(Util.ObjectToXml(Precision, "h:Precision", true));
        sb.Append(Util.ObjectToXml(PrecisionSource, "h:PrecisionSource", true));
        sb.Append(Util.ObjectToXml(SourceTypeMask, "h:SourceTypeMask", true));
        return sb.ToString();
    }
    static internal new MoneyAttributeMetadata LoadFromXml(XElement item)
    {
        MoneyAttributeMetadata moneyAttributeMetadata = new MoneyAttributeMetadata();
        AttributeMetadata.LoadFromXml(item, moneyAttributeMetadata);
        moneyAttributeMetadata.FormulaDefinition = Util.LoadFromXml<string>(item.Element(Util.ns.h + "FormulaDefinition"));
        moneyAttributeMetadata.ImeMode = Util.LoadFromXml<ImeMode?>(item.Element(Util.ns.h + "ImeMode"));
        moneyAttributeMetadata.IsBaseCurrency = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "IsBaseCurrency"));
        moneyAttributeMetadata.MaxValue = Util.LoadFromXml<double?>(item.Element(Util.ns.h + "MaxValue"));
        moneyAttributeMetadata.MinValue = Util.LoadFromXml<double?>(item.Element(Util.ns.h + "MinValue"));
        moneyAttributeMetadata.Precision = Util.LoadFromXml<int?>(item.Element(Util.ns.h + "Precision"));
        moneyAttributeMetadata.PrecisionSource = Util.LoadFromXml<int?>(item.Element(Util.ns.h + "PrecisionSource"));
        moneyAttributeMetadata.SourceTypeMask = Util.LoadFromXml<int?>(item.Element(Util.ns.h + "SourceTypeMask"));
        return moneyAttributeMetadata;
    }
}