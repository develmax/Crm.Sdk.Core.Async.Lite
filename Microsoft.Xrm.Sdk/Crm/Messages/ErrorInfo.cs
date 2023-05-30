using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class ErrorInfo
{
    public string ErrorCode { get; set; }
    public ResourceInfo[] ResourceList { get; set; }
    public ErrorInfo()
    {
        ResourceList = new List<ResourceInfo>().ToArray();

    }
    static internal ErrorInfo LoadFromXml(XElement item)
    {
        List<ResourceInfo> list = new List<ResourceInfo>();
        foreach (var resourceList in item.Element(Util.ns.g + "ResourceList").Elements())
        {
            list.Add(ResourceInfo.LoadFromXml(resourceList));
        }
        ErrorInfo errorInfo = new ErrorInfo()
        {
            ErrorCode = item.Element(Util.ns.g + "ErrorCode").Value,
            ResourceList = list.ToArray()
        };
        return errorInfo;
    }
}