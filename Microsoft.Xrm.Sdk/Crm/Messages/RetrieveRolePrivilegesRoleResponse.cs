using System.Collections.Generic;
using System.Net.Http;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveRolePrivilegesRoleResponse : OrganizationResponse
{
    public RolePrivilege[] RolePrivileges { get; set; }
    internal override void StoreResult(HttpResponseMessage httpResponse)
    {
        // Convert to XDocument
        XDocument xdoc = XDocument.Parse(httpResponse.Content.ReadAsStringAsync().Result, LoadOptions.None);
        // Obtain Values from result.
        foreach (var result in xdoc.Descendants(Util.ns.a + "Results").Elements(Util.ns.a + "KeyValuePairOfstringanyType"))
        {
            if (result.Element(Util.ns.b + "key").Value == "RolePrivileges")
            {
                List<RolePrivilege> list = new List<RolePrivilege>();
                foreach (var item in result.Element(Util.ns.b + "value").Elements(Util.ns.g + "RolePrivilege"))
                {
                    list.Add(RolePrivilege.LoadFromXml(item));
                }
                this.RolePrivileges = list.ToArray();
            }
        }
    }
}