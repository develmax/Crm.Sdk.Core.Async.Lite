using System;
using System.Text;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class RequiredResource
{
    public Guid ResourceId { get; set; }
    public Guid ResourceSpecId { get; set; }
    internal string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(Util.ObjectToXml(ResourceId, "g:ResourceId", true));
        sb.Append(Util.ObjectToXml(ResourceSpecId, "g:ResourceSpecId", true));
        return sb.ToString();
    }
}