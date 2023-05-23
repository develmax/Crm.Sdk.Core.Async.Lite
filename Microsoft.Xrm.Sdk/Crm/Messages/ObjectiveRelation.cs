using System;
using System.Text;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class ObjectiveRelation
{
    public string ObjectiveExpression { get; set; }
    public Guid ResourceSpecId { get; set; }
    internal string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(Util.ObjectToXml(ResourceSpecId, "g:ResourceSpecId", true));
        sb.Append(Util.ObjectToXml(ObjectiveExpression, "g:ObjectiveExpression", true));
        return sb.ToString();
    }
}