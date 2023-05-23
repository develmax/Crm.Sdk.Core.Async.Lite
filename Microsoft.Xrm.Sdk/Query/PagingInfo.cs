using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Query;

public sealed class PagingInfo
{
    public int Count { get; set; }
    public int PageNumber { get; set; }
    public string PagingCookie { get; set; }
    public bool ReturnTotalRecordCount { get; set; }
    internal string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(Util.ObjectToXml(Count, "a:Count", true));
        sb.Append(Util.ObjectToXml(PageNumber, "a:PageNumber", true));
        sb.Append(Util.ObjectToXml(PagingCookie, "a:PagingCookie", true));
        sb.Append(Util.ObjectToXml(ReturnTotalRecordCount, "a:ReturnTotalRecordCount", true));
        return sb.ToString();
    }
    static internal PagingInfo LoadFromXml(XElement item)
    {
        PagingInfo pagingInfo = new PagingInfo()
        {
            Count = Util.LoadFromXml<int>(item.Element(Util.ns.a + "Count")),
            PageNumber = Util.LoadFromXml<int>(item.Element(Util.ns.a + "PageNumber")),
            PagingCookie = Util.LoadFromXml<string>(item.Element(Util.ns.a + "PagingCookie")),
            ReturnTotalRecordCount = Util.LoadFromXml<bool>(item.Element(Util.ns.a + "ReturnTotalRecordCount"))
        };
        return pagingInfo;
    }
}