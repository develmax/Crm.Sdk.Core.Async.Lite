using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Utility;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Microsoft.Xrm.Sdk.Metadata
{
    public sealed class AssociatedMenuConfiguration
    {
        public AssociatedMenuBehavior? Behavior { get; set; }
        public AssociatedMenuGroup? Group { get; set; }
        public Label Label { get; set; }
        public int? Order { get; set; }
        internal string ToValueXml()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Util.ObjectToXml(Behavior, "h:Behavior", true));
            sb.Append(Util.ObjectToXml(Group, "h:Group", true));
            sb.Append(Util.ObjectToXml(Label, "h:Label", true));
            sb.Append(Util.ObjectToXml(Order, "h:Order", true));
            return sb.ToString();
        }
        static internal AssociatedMenuConfiguration LoadFromXml(XElement item)
        {
            if (item.Elements().Count() == 0)
                return new AssociatedMenuConfiguration();
            AssociatedMenuConfiguration associatedMenuConfiguration = new AssociatedMenuConfiguration()
            {
                Behavior = Util.LoadFromXml<AssociatedMenuBehavior?>(item.Element(Util.ns.h + "Behavior")),
                Group = Util.LoadFromXml<AssociatedMenuGroup?>(item.Element(Util.ns.h + "Group")),
                Label = Label.LoadFromXml(item.Element(Util.ns.h + "Label")),
                Order = Util.LoadFromXml<int?>(item.Element(Util.ns.h + "Order"))
            };
            return associatedMenuConfiguration;
        }
    }
}