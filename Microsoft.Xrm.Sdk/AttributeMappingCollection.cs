using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk;

public sealed class AttributeMappingCollection : DataCollection<AttributeMapping>
{
    public AttributeMappingCollection() { }
    public AttributeMappingCollection(IList<AttributeMapping> list)
    {
        this.AddRange(list);
    }
    static internal AttributeMappingCollection LoadFromXml(XElement item)
    {
        AttributeMappingCollection attributeMappingCollection = new AttributeMappingCollection();
        foreach (var attributeMapping in item.Elements(Util.ns.a + "AttributeMapping"))
        {
            attributeMappingCollection.Add(AttributeMapping.LoadFromXml(attributeMapping));
        }
        return attributeMappingCollection;
    }
}