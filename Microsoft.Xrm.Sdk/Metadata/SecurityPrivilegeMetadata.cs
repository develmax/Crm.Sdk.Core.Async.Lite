using System;
using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata;

public sealed class SecurityPrivilegeMetadata
{
    public bool CanBeBasic { get; set; }
    public bool CanBeDeep { get; set; }
    public bool CanBeGlobal { get; set; }
    public bool CanBeLocal { get; set; }
    public string Name { get; set; }
    public Guid PrivilegeId { get; set; }
    public PrivilegeType PrivilegeType { get; set; }
    internal string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(Util.ObjectToXml(CanBeBasic, "h:CanBeBasic", true));
        sb.Append(Util.ObjectToXml(CanBeDeep, "h:CanBeDeep", true));
        sb.Append(Util.ObjectToXml(CanBeGlobal, "h:CanBeGlobal", true));
        sb.Append(Util.ObjectToXml(CanBeLocal, "h:CanBeLocal", true));
        sb.Append(Util.ObjectToXml(Name, "h:Name", true));
        sb.Append(Util.ObjectToXml(PrivilegeId, "h:PrivilegeId", true));
        sb.Append(Util.ObjectToXml(PrivilegeType, "h:PrivilegeType", true));
        return sb.ToString();
    }
    static internal SecurityPrivilegeMetadata LoadFromXml(XElement item)
    {
        SecurityPrivilegeMetadata securityPrivilegeMetadata = new SecurityPrivilegeMetadata()
        {
            CanBeBasic = Util.LoadFromXml<bool>(item.Element(Util.ns.h + "CanBeBasic")),
            CanBeDeep = Util.LoadFromXml<bool>(item.Element(Util.ns.h + "CanBeDeep")),
            CanBeGlobal = Util.LoadFromXml<bool>(item.Element(Util.ns.h + "CanBeGlobal")),
            CanBeLocal = Util.LoadFromXml<bool>(item.Element(Util.ns.h + "CanBeLocal")),
            Name = Util.LoadFromXml<string>(item.Element(Util.ns.h + "Name")),
            PrivilegeId = Util.LoadFromXml<Guid>(item.Element(Util.ns.h + "PrivilegeId")),
            PrivilegeType = Util.LoadFromXml<PrivilegeType>(item.Element(Util.ns.h + "PrivilegeType"))
        };
        return securityPrivilegeMetadata;
    }
}