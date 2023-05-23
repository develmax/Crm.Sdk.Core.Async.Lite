using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RolePrivilegeAuditDetail : AuditDetail
{
    public DataCollection<Guid> InvalidNewPrivileges { get; set; }
    public RolePrivilege[] NewRolePrivileges { get; set; }
    public RolePrivilege[] OldRolePrivileges { get; set; }
    public RolePrivilegeAuditDetail()
    {
        InvalidNewPrivileges = new DataCollection<Guid>();
        NewRolePrivileges = new List<RolePrivilege>().ToArray();
        OldRolePrivileges = new List<RolePrivilege>().ToArray();
    }
    static internal new RolePrivilegeAuditDetail LoadFromXml(XElement item)
    {
        RolePrivilegeAuditDetail rolePrivilegeAuditDetail = new RolePrivilegeAuditDetail();
        AuditDetail.LoadFromXml(item, rolePrivilegeAuditDetail);
        foreach (var value in item.Elements(Util.ns.g + "InvalidNewPrivileges"))
        {
            if (value.Value == "")
                continue;
            rolePrivilegeAuditDetail.InvalidNewPrivileges.Add(Util.LoadFromXml<Guid>(value));
        }
        List<RolePrivilege> newRolePrivileges = new List<RolePrivilege>();
        foreach (var value in item.Elements(Util.ns.g + "NewRolePrivileges").Elements(Util.ns.g + "RolePrivilege"))
        {
            if (value.Elements().Count() == 0)
                continue;
            newRolePrivileges.Add(RolePrivilege.LoadFromXml(value));
        }
        rolePrivilegeAuditDetail.NewRolePrivileges = newRolePrivileges.ToArray();
        List<RolePrivilege> oldRolePrivileges = new List<RolePrivilege>();
        foreach (var value in item.Elements(Util.ns.g + "OldRolePrivileges").Elements(Util.ns.g + "RolePrivilege"))
        {
            if (value.Elements().Count() == 0)
                continue;
            oldRolePrivileges.Add(RolePrivilege.LoadFromXml(value));
        }
        rolePrivilegeAuditDetail.OldRolePrivileges = oldRolePrivileges.ToArray();
        return rolePrivilegeAuditDetail;
    }
}