using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata;

public sealed class CascadeConfiguration
{
    public CascadeType? Assign { get; set; }
    public CascadeType? Delete { get; set; }
    public CascadeType? Merge { get; set; }
    public CascadeType? Reparent { get; set; }
    public CascadeType? Share { get; set; }
    public CascadeType? Unshare { get; set; }
    internal string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(Util.ObjectToXml(Assign, "h:Assign", true));
        sb.Append(Util.ObjectToXml(Delete, "h:Delete", true));
        sb.Append(Util.ObjectToXml(Merge, "h:Merge", true));
        sb.Append(Util.ObjectToXml(Reparent, "h:Reparent", true));
        sb.Append(Util.ObjectToXml(Share, "h:Share", true));
        sb.Append(Util.ObjectToXml(Unshare, "h:Unshare", true));
        return sb.ToString();
    }
    static internal CascadeConfiguration LoadFromXml(XElement item)
    {
        if (item.Elements().Count() == 0)
            return new CascadeConfiguration();
        CascadeConfiguration cascadeConfiguration = new CascadeConfiguration()
        {
            Assign = Util.LoadFromXml<CascadeType?>(item.Element(Util.ns.h + "Assign")),
            Delete = Util.LoadFromXml<CascadeType?>(item.Element(Util.ns.h + "Delete")),
            Merge = Util.LoadFromXml<CascadeType?>(item.Element(Util.ns.h + "Merge")),
            Reparent = Util.LoadFromXml<CascadeType?>(item.Element(Util.ns.h + "Reparent")),
            Share = Util.LoadFromXml<CascadeType?>(item.Element(Util.ns.h + "Share")),
            Unshare = Util.LoadFromXml<CascadeType?>(item.Element(Util.ns.h + "Unshare")),
        };
        return cascadeConfiguration;
    }
}