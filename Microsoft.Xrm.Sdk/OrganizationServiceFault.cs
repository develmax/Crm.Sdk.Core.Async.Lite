using System.Linq;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk;

public sealed class OrganizationServiceFault : BaseServiceFault
{
    public OrganizationServiceFault InnerFault { get; set; }
    public string TraceText { get; set; }
    static internal OrganizationServiceFault LoadFromXml(XElement item)
    {
        if (item.Elements().Count() == 0)
            return null;
        OrganizationServiceFault organizationServiceFault = new OrganizationServiceFault()
        {
            TraceText = Util.LoadFromXml<string>(item.Element(Util.ns.a + "TraceText")),
            InnerFault = OrganizationServiceFault.LoadFromXml(item.Element(Util.ns.a + "InnerFault"))
        };
        BaseServiceFault.LoadFromXml(item, organizationServiceFault);
        return organizationServiceFault;
    }
}