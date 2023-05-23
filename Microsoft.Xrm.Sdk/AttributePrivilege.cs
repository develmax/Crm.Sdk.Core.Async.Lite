using System;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk;

public sealed class AttributePrivilege
{
    public Guid AttributeId { get; set; }
    public int CanCreate { get; set; }
    public int CanRead { get; set; }
    public int CanUpdate { get; set; }
    public AttributePrivilege() { }
    public AttributePrivilege(Guid attributeId, int canCreate, int canRead, int canUpdate)
    {
        AttributeId = attributeId;
        CanCreate = canCreate;
        CanRead = canRead;
        CanUpdate = canUpdate;
    }
    static internal AttributePrivilege LoadFromXml(XElement item)
    {
        AttributePrivilege attributePrivilege = new AttributePrivilege()
        {
            AttributeId = Util.LoadFromXml<Guid>(item.Element(Util.ns.a + "AttributeId")),
            CanCreate = Util.LoadFromXml<int>(item.Element(Util.ns.a + "CanCreate")),
            CanRead = Util.LoadFromXml<int>(item.Element(Util.ns.a + "CanRead")),
            CanUpdate = Util.LoadFromXml<int>(item.Element(Util.ns.a + "CanUpdate"))
        };
        return attributePrivilege;
    }
}