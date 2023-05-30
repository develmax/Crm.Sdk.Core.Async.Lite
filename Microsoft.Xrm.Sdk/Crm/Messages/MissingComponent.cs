using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class MissingComponent
{
    public ComponentDetail DependentComponent { get; set; }
    public ComponentDetail RequiredComponent { get; set; }
    static internal MissingComponent LoadFromXml(XElement item)
    {
        MissingComponent missingComponent = new MissingComponent()
        {
            DependentComponent = ComponentDetail.LoadFromXml(item.Element(Util.ns.a + "DependentComponent")),
            RequiredComponent = ComponentDetail.LoadFromXml(item.Element(Util.ns.a + "RequiredComponent")),
        };
        return missingComponent;
    }
}