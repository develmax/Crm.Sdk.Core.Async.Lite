using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata;

public sealed class OptionMetadataCollection : DataCollection<OptionMetadata>
{
    public OptionMetadataCollection() { }
    public OptionMetadataCollection(IList<OptionMetadata> list)
    {
        this.AddRange(list);
    }
    internal string ToValueXml()
    {
        return Util.ObjectToXml(this.ToArray(), "h:OptionMetadata", true);
    }
    static internal OptionMetadataCollection LoadFromXml(XElement item)
    {
        OptionMetadataCollection optionMetadataCollection = new OptionMetadataCollection();
        foreach (var optionMetadata in item.Elements(Util.ns.h + "OptionMetadata"))
        {
            optionMetadataCollection.Add(OptionMetadata.LoadFromXml(optionMetadata));
        }
        return optionMetadataCollection;
    }
}