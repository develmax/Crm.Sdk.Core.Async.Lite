using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata;

public sealed class BigIntAttributeMetadata : AttributeMetadata
{
    public const long MaxSupportedValue = 9223372036854775807;
    public const long MinSupportedValue = -9223372036854775808;
    private long? _maxValue;
    public long? MaxValue
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
    private long? _minValue;
    public long? MinValue
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
    public BigIntAttributeMetadata() : this(null) { }
    public BigIntAttributeMetadata(string schemaName)
        : base(AttributeTypeCode.BigInt, schemaName) { }
    internal new string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(base.ToValueXml());
        sb.Append(Util.ObjectToXml(MaxValue, "h:MaxValue", true));
        sb.Append(Util.ObjectToXml(MinValue, "h:MinValue", true));
        return sb.ToString();
    }
    static internal new BigIntAttributeMetadata LoadFromXml(XElement item)
    {
        BigIntAttributeMetadata bigIntAttributeMetadata = new BigIntAttributeMetadata();
        AttributeMetadata.LoadFromXml(item, bigIntAttributeMetadata);
        bigIntAttributeMetadata.MaxValue = Util.LoadFromXml<long?>(item.Element(Util.ns.h + "MaxValue"));
        bigIntAttributeMetadata.MinValue = Util.LoadFromXml<long?>(item.Element(Util.ns.h + "MinValue"));
        return bigIntAttributeMetadata;
    }
}