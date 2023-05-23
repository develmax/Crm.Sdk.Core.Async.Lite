using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata;

public sealed class MemoAttributeMetadata : AttributeMetadata
{
    public const int MaxSupportedLength = 1048576;
    public const int MinSupportedLength = 1;
    public StringFormat? Format { get; set; }
    public ImeMode? ImeMode { get; set; }
    private int? _maxLength;
    public int? MaxLength
    {
        get { return _maxLength; }
        set
        {
            if (value < MinSupportedLength || value > MaxSupportedLength)
                // Should throw error?
                return;
            _maxLength = value;
        }
    }
    public MemoAttributeMetadata() : this(null) { }
    public MemoAttributeMetadata(string schemaName)
        : base(AttributeTypeCode.Memo, schemaName) { }
    internal new string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(base.ToValueXml());
        sb.Append(Util.ObjectToXml(Format, "h:Format", true));
        sb.Append(Util.ObjectToXml(ImeMode, "h:ImeMode", true));
        sb.Append(Util.ObjectToXml(MaxLength, "h:MaxLength", true));
        return sb.ToString();
    }
    static internal new MemoAttributeMetadata LoadFromXml(XElement item)
    {
        MemoAttributeMetadata memoAttributeMetadata = new MemoAttributeMetadata();
        AttributeMetadata.LoadFromXml(item, memoAttributeMetadata);
        memoAttributeMetadata.Format = Util.LoadFromXml<StringFormat?>(item.Element(Util.ns.h + "Format"));
        memoAttributeMetadata.ImeMode = Util.LoadFromXml<ImeMode?>(item.Element(Util.ns.h + "ImeMode"));
        memoAttributeMetadata.MaxLength = Util.LoadFromXml<int?>(item.Element(Util.ns.h + "MaxLength"));
        return memoAttributeMetadata;
    }
}