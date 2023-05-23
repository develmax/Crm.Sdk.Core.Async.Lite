using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk;

public sealed class LocalizedLabelCollection : DataCollection<LocalizedLabel>
{
    public LocalizedLabelCollection() { }
    public LocalizedLabelCollection(IList<LocalizedLabel> list)
    {
        this.AddRange(list);
    }
    internal string ToValueXml()
    {
        return Util.ObjectToXml(this.ToArray(), "a:LocalizedLabel", true);
    }
    static internal LocalizedLabelCollection LoadFromXml(XElement item)
    {
        LocalizedLabelCollection LocalizedLabelCollection = new LocalizedLabelCollection();
        foreach (var localizedLabel in item.Elements(Util.ns.a + "LocalizedLabel"))
        {
            LocalizedLabelCollection.Add(LocalizedLabel.LoadFromXml(localizedLabel));
        }
        return LocalizedLabelCollection;
    }
}