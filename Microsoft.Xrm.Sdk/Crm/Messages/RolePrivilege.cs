using System;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class RolePrivilege
{
    public Guid BusinessUnitId { get; set; }
    public PrivilegeDepth Depth { get; set; }
    public Guid PrivilegeId { get; set; }
    public RolePrivilege()
    {
    }
    public RolePrivilege(int Depth, Guid PrivilegeId)
    {
        this.Depth = (PrivilegeDepth)Depth;
        this.PrivilegeId = PrivilegeId;
    }
    internal string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(Util.ObjectToXml(BusinessUnitId, "g:BusinessUnitId", true));
        sb.Append(Util.ObjectToXml(Depth, "g:Depth", true));
        sb.Append(Util.ObjectToXml(PrivilegeId, "g:PrivilegeId", true));
        return sb.ToString();
    }
    static public RolePrivilege LoadFromXml(XElement item)
    {
        if (item.Elements().Count() == 0)
            return null;
        RolePrivilege rolePrivilege = new RolePrivilege()
        {
            BusinessUnitId = Util.LoadFromXml<Guid>(item.Element(Util.ns.g + "BusinessUnitId")),
            Depth = Util.LoadFromXml<PrivilegeDepth>(item.Element(Util.ns.g + "Depth")),
            PrivilegeId = Util.LoadFromXml<Guid>(item.Element(Util.ns.g + "PrivilegeId"))
        };
        return rolePrivilege;
    }
}