using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Metadata.Query;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata;

public abstract class MetadataBase
{
    public bool? HasChanged { get; set; }
    public Guid? MetadataId { get; set; }
    // As there is no suitable place for this, I put inside EntityMetadata
    static internal string GetDeletedMetadataFiltersAsString(DeletedMetadataFilters enumValue)
    {
        List<string> valueArray = new List<string>();
        string returnValue = "None";

        if (enumValue.HasFlag(DeletedMetadataFilters.Entity) || enumValue.HasFlag(DeletedMetadataFilters.All))
        {
            valueArray.Add("Entity");
        }
        if (enumValue.HasFlag(DeletedMetadataFilters.Attribute) || enumValue.HasFlag(DeletedMetadataFilters.All))
        {
            valueArray.Add("Attribute");
        }
        if (enumValue.HasFlag(DeletedMetadataFilters.Relationship) || enumValue.HasFlag(DeletedMetadataFilters.All))
        {
            valueArray.Add("Relationship");
        }
        if (enumValue.HasFlag(DeletedMetadataFilters.Label) || enumValue.HasFlag(DeletedMetadataFilters.All))
        {
            valueArray.Add("Label");
        }
        if (enumValue.HasFlag(DeletedMetadataFilters.OptionSet) || enumValue.HasFlag(DeletedMetadataFilters.All))
        {
            valueArray.Add("OptionSet");
        }
        returnValue = String.Join(" ", valueArray.ToArray());

        return returnValue;
    }
    internal string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(Util.ObjectToXml(HasChanged, "h:HasChanged", true));
        sb.Append(Util.ObjectToXml(MetadataId, "h:MetadataId", true));
        return sb.ToString();
    }
    static internal void LoadFromXml(XElement item, MetadataBase meta)
    {
        if (item.Elements().Count() == 0)
            return;
        meta.HasChanged = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "HasChanged"));
        meta.MetadataId = Util.LoadFromXml<Guid?>(item.Element(Util.ns.h + "MetadataId"));
    }
}