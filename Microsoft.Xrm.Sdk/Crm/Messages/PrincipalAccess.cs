using System;
using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class PrincipalAccess
{
    public AccessRights AccessMask { get; set; }
    private EntityReference _principal;
    public EntityReference Principal
    {
        get
        {
            return _principal;
        }
        set
        {
            if (value.LogicalName != "systemuser" && value.LogicalName != "team")
            {
                throw new Exception("Only system user or team is allowed as Principal");
            }
            _principal = value;
        }
    }
    internal string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(Util.ObjectToXml(AccessMask, "g:AccessMask", true));
        sb.Append(Util.ObjectToXml(Principal, "g:Principal", true));
        return sb.ToString();
    }
    static internal PrincipalAccess LoadFromXml(XElement item)
    {
        PrincipalAccess principalAccess = new PrincipalAccess()
        {
            Principal = EntityReference.LoadFromXml(item.Element(Util.ns.g + "Principal")),
            AccessMask = Util.GetAccessRightsFromString(item.Element(Util.ns.g + "AccessMask").Value)
        };
        return principalAccess;
    }
}