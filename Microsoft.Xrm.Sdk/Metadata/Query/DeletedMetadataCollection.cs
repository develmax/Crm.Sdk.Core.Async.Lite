using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata.Query;

public sealed class DeletedMetadataCollection : Dictionary<DeletedMetadataFilters, DataCollection<Guid>>
{
    static internal DeletedMetadataCollection LoadFromXml(XElement doc)
    {
        DeletedMetadataCollection deletedMetadataCollection = new DeletedMetadataCollection();
        foreach (var item in doc.Elements(Util.ns.j + "KeyValuePairOfDeletedMetadataFiltersArrayOfguidPlUv_PKtF"))
        {
            DataCollection<Guid> value = new DataCollection<Guid>();
            foreach (var guid in item.Element(Util.ns.b + "value").Elements(Util.ns.f + "guid"))
            {
                value.Add(Util.LoadFromXml<Guid>(guid));
            }
            deletedMetadataCollection.Add(Util.LoadFromXml<DeletedMetadataFilters>(item.Element(Util.ns.b + "key")), value);
        }
        return deletedMetadataCollection;
    }
}