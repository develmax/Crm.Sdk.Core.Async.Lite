using System;
using System.Text;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class ConstraintRelation
{
    public string Constraints { get; set; }
    public string ConstraintType { get; set; }
    public Guid ObjectId { get; set; }
    internal string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(Util.ObjectToXml(ObjectId, "g:ObjectId", true));
        sb.Append(Util.ObjectToXml(ConstraintType, "g:ConstraintType", true));
        sb.Append(Util.ObjectToXml(Constraints, "g:Constraints", true));
        return sb.ToString();
    }
}