using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata;

public sealed class LookupAttributeMetadata : AttributeMetadata
{
    public string[] Targets { get; set; }
    public LookupAttributeMetadata()
        : base(AttributeTypeCode.Lookup)
    {
        Targets = new List<string>().ToArray();
    }
    internal new string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(base.ToValueXml());
        sb.Append(Util.ObjectToXml(Targets, "d:Targets", true));
        return sb.ToString();
    }
    static internal new LookupAttributeMetadata LoadFromXml(XElement item)
    {
        LookupAttributeMetadata lookupAttributeMetadata = new LookupAttributeMetadata();
        AttributeMetadata.LoadFromXml(item, lookupAttributeMetadata);
        List<string> list = new List<string>();
        if (item.Elements(Util.ns.h + "Targets").Elements().Count() > 0)
        {
            foreach (XElement Target in item.Elements(Util.ns.h + "Targets").Elements())
            {
                list.Add(Target.Value);
            }
        }
        lookupAttributeMetadata.Targets = list.ToArray();
        return lookupAttributeMetadata;
    }
}