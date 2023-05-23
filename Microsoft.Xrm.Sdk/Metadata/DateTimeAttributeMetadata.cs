using System;
using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata;

public sealed class DateTimeAttributeMetadata : AttributeMetadata
{
    public DateTimeFormat? Format { get; set; }
    public string FormulaDefinition { get; set; }
    public ImeMode? ImeMode { get; set; }
    public static DateTime MaxSupportedValue { get; set; }
    public static DateTime MinSupportedValue { get; set; }
    public int? SourceTypeMask { get; set; }
    public DateTimeAttributeMetadata() : this(null, null) { }
    public DateTimeAttributeMetadata(DateTimeFormat? format) : this(format, null) { }
    public DateTimeAttributeMetadata(DateTimeFormat? format, string schemaName)
        : base(AttributeTypeCode.DateTime, schemaName)
    {
        this.Format = format;
    }
    internal new string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(base.ToValueXml());
        sb.Append(Util.ObjectToXml(Format, "h:Format", true));
        sb.Append(Util.ObjectToXml(FormulaDefinition, "h:FormulaDefinition", true));
        sb.Append(Util.ObjectToXml(ImeMode, "h:ImeMode", true));
        sb.Append(Util.ObjectToXml(MaxSupportedValue, "h:MaxSupportedValue", true));
        sb.Append(Util.ObjectToXml(MinSupportedValue, "h:MinSupportedValue", true));
        sb.Append(Util.ObjectToXml(SourceTypeMask, "h:SourceTypeMask", true));
        return sb.ToString();
    }
    static internal new DateTimeAttributeMetadata LoadFromXml(XElement item)
    {
        DateTimeAttributeMetadata dateTimeAttributeMetadata = new DateTimeAttributeMetadata();
        AttributeMetadata.LoadFromXml(item, dateTimeAttributeMetadata);
        dateTimeAttributeMetadata.Format = Util.LoadFromXml<DateTimeFormat?>(item.Element(Util.ns.h + "Format"));
        dateTimeAttributeMetadata.FormulaDefinition = Util.LoadFromXml<string>(item.Element(Util.ns.h + "FormulaDefinition"));
        dateTimeAttributeMetadata.ImeMode = Util.LoadFromXml<ImeMode?>(item.Element(Util.ns.h + "ImeMode"));
        if (item.Element(Util.ns.h + "MaxSupportedValue") != null)
            DateTimeAttributeMetadata.MaxSupportedValue = Util.LoadFromXml<DateTime>(item.Element(Util.ns.h + "MaxSupportedValue"));
        if (item.Element(Util.ns.h + "MinSupportedValue") != null)
            DateTimeAttributeMetadata.MinSupportedValue = Util.LoadFromXml<DateTime>(item.Element(Util.ns.h + "MinSupportedValue"));
        dateTimeAttributeMetadata.SourceTypeMask = Util.LoadFromXml<int?>(item.Element(Util.ns.h + "SourceTypeMask"));
        return dateTimeAttributeMetadata;
    }
}