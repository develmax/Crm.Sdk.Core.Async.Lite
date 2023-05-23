using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk;

public sealed class AttributePrivilegeCollection : DataCollection<AttributePrivilege>
{
    public AttributePrivilegeCollection() { }
    public AttributePrivilegeCollection(IList<AttributePrivilege> list)
    {
        this.AddRange(list);
    }
    static internal AttributePrivilegeCollection LoadFromXml(XElement item)
    {
        AttributePrivilegeCollection attributePrivilegeCollection = new AttributePrivilegeCollection();
        foreach (var attributePrivilege in item.Elements(Util.ns.a + "AttributePrivilege"))
        {
            attributePrivilegeCollection.Add(AttributePrivilege.LoadFromXml(attributePrivilege));
        }
        return attributePrivilegeCollection;
    }
}