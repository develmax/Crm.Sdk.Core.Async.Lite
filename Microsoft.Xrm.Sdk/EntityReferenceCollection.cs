using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk;

public sealed class EntityReferenceCollection : DataCollection<EntityReference>
{
    internal string ToValueXml()
    {
        return Util.ObjectToXml(this.ToArray(), "a:EntityReference", true);
    }
    static internal EntityReferenceCollection LoadFromXml(XElement item)
    {
        EntityReferenceCollection entityReferenceCollection = new EntityReferenceCollection();
        foreach (var entityReference in item.Elements(Util.ns.a + "EntityReference"))
        {
            entityReferenceCollection.Add(EntityReference.LoadFromXml(entityReference));
        }
        return entityReferenceCollection;
    }
}