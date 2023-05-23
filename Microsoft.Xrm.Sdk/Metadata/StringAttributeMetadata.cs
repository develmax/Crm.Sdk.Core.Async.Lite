using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata;

public sealed class StringAttributeMetadata : AttributeMetadata
{
    public const int MaxSupportedLength = 4000;
    public const int MinSupportedLength = 1;
    public StringFormat? Format { get; set; }
    public StringFormatName FormatName { get; set; }
    public string FormulaDefinition { get; set; }
    public ImeMode? ImeMode { get; set; }
    public bool? IsLocalizable { get; set; }
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
    public int? SourceTypeMask { get; set; }
    public string YomiOf { get; set; }
    public StringAttributeMetadata() : this(null) { }
    public StringAttributeMetadata(string schemaName)
        : base(AttributeTypeCode.String, schemaName) { }
    internal new string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(base.ToValueXml());
        sb.Append(Util.ObjectToXml(Format, "h:Format", true));
        sb.Append(Util.ObjectToXml(FormatName, "h:FormatName", true));
        sb.Append(Util.ObjectToXml(FormulaDefinition, "h:FormulaDefinition", true));
        sb.Append(Util.ObjectToXml(ImeMode, "h:ImeMode", true));
        sb.Append(Util.ObjectToXml(IsLocalizable, "h:IsLocalizable", true));
        sb.Append(Util.ObjectToXml(MaxLength, "h:MaxLength", true));
        sb.Append(Util.ObjectToXml(SourceTypeMask, "h:SourceTypeMask", true));
        sb.Append(Util.ObjectToXml(YomiOf, "h:YomiOf", true));
        return sb.ToString();
    }
    static internal new StringAttributeMetadata LoadFromXml(XElement item)
    {
        StringAttributeMetadata stringAttributeMetadata = new StringAttributeMetadata();
        AttributeMetadata.LoadFromXml(item, stringAttributeMetadata);
        stringAttributeMetadata.Format = Util.LoadFromXml<StringFormat?>(item.Element(Util.ns.h + "Format"));
        stringAttributeMetadata.FormatName = StringFormatName.LoadFromXml(item.Element(Util.ns.h + "FormatName"));
        stringAttributeMetadata.FormulaDefinition = Util.LoadFromXml<string>(item.Element(Util.ns.h + "FormulaDefinition"));
        stringAttributeMetadata.ImeMode = Util.LoadFromXml<ImeMode?>(item.Element(Util.ns.h + "ImeMode"));
        stringAttributeMetadata.IsLocalizable = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "IsLocalizable"));
        stringAttributeMetadata.MaxLength = Util.LoadFromXml<int?>(item.Element(Util.ns.h + "MaxLength"));
        stringAttributeMetadata.SourceTypeMask = Util.LoadFromXml<int?>(item.Element(Util.ns.h + "SourceTypeMask"));
        stringAttributeMetadata.YomiOf = Util.LoadFromXml<string>(item.Element(Util.ns.h + "YomiOf"));
        return stringAttributeMetadata;
    }
}