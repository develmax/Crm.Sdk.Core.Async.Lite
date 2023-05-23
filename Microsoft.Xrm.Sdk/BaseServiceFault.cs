using System;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk;

public abstract class BaseServiceFault : Exception
{
    public int ErrorCode { get; set; }
    public ErrorDetailCollection ErrorDetails { get; set; }
    public new string Message { get; set; }
    public DateTime Timestamp { get; set; }
    static internal void LoadFromXml(XElement item, BaseServiceFault fault)
    {
        if (item.Elements().Count() == 0)
            return;
        fault.ErrorCode = Util.LoadFromXml<int>(item.Element(Util.ns.a + "ErrorCode"));
        fault.ErrorDetails = ErrorDetailCollection.LoadFromXml(item.Element(Util.ns.a + "ErrorDetails"));
        fault.Message = Util.LoadFromXml<string>(item.Element(Util.ns.a + "Message"));
        fault.Timestamp = Util.LoadFromXml<DateTime>(item.Element(Util.ns.a + "Timestamp"));
    }
}