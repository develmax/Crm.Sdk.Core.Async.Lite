using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata;

public sealed class EntityMetadataCollection : DataCollection<EntityMetadata>
{
    static internal EntityMetadataCollection LoadFromXml(XElement item)
    {
        EntityMetadataCollection entityMetadataCollection = new EntityMetadataCollection();
        foreach (var entity in item.Elements(Util.ns.a + "EntityMetadata"))
        {
            entityMetadataCollection.Add(EntityMetadata.LoadFromXml(entity));
        }
        return entityMetadataCollection;
    }
}