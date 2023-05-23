using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class TraceInfo
{
    public ErrorInfo[] ErrorInfoList { get; set; }
    public TraceInfo()
    {
        ErrorInfoList = new List<ErrorInfo>().ToArray();
    }
    static internal TraceInfo LoadFromXml(XElement item)
    {
        TraceInfo traceInfo = new TraceInfo();
        List<ErrorInfo> list = new List<ErrorInfo>();
        foreach (var errorInfo in item.Element(Util.ns.g + "ErrorInfoList").Elements())
        {
            list.Add(ErrorInfo.LoadFromXml(errorInfo));
        }

        traceInfo.ErrorInfoList = list.ToArray();
        return traceInfo;
    }
}