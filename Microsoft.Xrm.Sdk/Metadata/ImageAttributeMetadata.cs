using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata;

public sealed class ImageAttributeMetadata : AttributeMetadata
{
    public bool? IsPrimaryImage { get; set; }
    public short? MaxHeight { get; set; }
    public short? MaxWidth { get; set; }
    public ImageAttributeMetadata() : this(null) { }
    public ImageAttributeMetadata(string schemaName)
    {
        AttributeType = AttributeTypeCode.Virtual;
        AttributeTypeName = AttributeTypeDisplayName.ImageType;
        SchemaName = schemaName;
    }
    internal new string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(base.ToValueXml());
        sb.Append(Util.ObjectToXml(IsPrimaryImage, "k:IsPrimaryImage", true));
        sb.Append(Util.ObjectToXml(MaxHeight, "k:MaxHeight", true));
        sb.Append(Util.ObjectToXml(MaxWidth, "k:MaxWidth", true));
        return sb.ToString();
    }
    static internal new ImageAttributeMetadata LoadFromXml(XElement item)
    {
        ImageAttributeMetadata imageAttributeMetadata = new ImageAttributeMetadata();
        AttributeMetadata.LoadFromXml(item, imageAttributeMetadata);
        imageAttributeMetadata.IsPrimaryImage = Util.LoadFromXml<bool?>(item.Element(Util.ns.k + "IsPrimaryImage"));
        imageAttributeMetadata.MaxHeight = Util.LoadFromXml<short?>(item.Element(Util.ns.k + "MaxHeight"));
        imageAttributeMetadata.MaxWidth = Util.LoadFromXml<short?>(item.Element(Util.ns.k + "MaxWidth"));
        return imageAttributeMetadata;
    }
}