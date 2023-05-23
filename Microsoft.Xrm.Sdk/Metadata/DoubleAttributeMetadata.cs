using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata;

public sealed class DoubleAttributeMetadata : AttributeMetadata
{
    public const int MaxSupportedPrecision = 5;
    public const int MinSupportedPrecision = 0;
    public const double MaxSupportedValue = 100000000000;
    public const double MinSupportedValue = -100000000000;
    public ImeMode? ImeMode { get; set; }
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
    public DoubleAttributeMetadata() : this(null) { }
    public DoubleAttributeMetadata(string schemaName)
        : base(AttributeTypeCode.Double, schemaName) { }
    internal new string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(base.ToValueXml());
        sb.Append(Util.ObjectToXml(ImeMode, "h:ImeMode", true));
        sb.Append(Util.ObjectToXml(MaxValue, "h:MaxValue", true));
        sb.Append(Util.ObjectToXml(MinValue, "h:MinValue", true));
        sb.Append(Util.ObjectToXml(Precision, "h:Precision", true));
        return sb.ToString();
    }
    static internal new DoubleAttributeMetadata LoadFromXml(XElement item)
    {
        DoubleAttributeMetadata doubleAttributeMetadata = new DoubleAttributeMetadata();
        AttributeMetadata.LoadFromXml(item, doubleAttributeMetadata);
        doubleAttributeMetadata.ImeMode = Util.LoadFromXml<ImeMode?>(item.Element(Util.ns.h + "ImeMode"));
        doubleAttributeMetadata.MaxValue = Util.LoadFromXml<double?>(item.Element(Util.ns.h + "MaxValue"));
        doubleAttributeMetadata.MinValue = Util.LoadFromXml<double?>(item.Element(Util.ns.h + "MinValue"));
        doubleAttributeMetadata.Precision = Util.LoadFromXml<int?>(item.Element(Util.ns.h + "Precision"));
        return doubleAttributeMetadata;
    }
}