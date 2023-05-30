using System;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class ValidationResult
{
    public Guid ActivityId { get; set; }
    public TraceInfo TraceInfo { get; set; }
    public bool ValidationSuccess { get; set; }
    static internal ValidationResult LoadFromXml(XElement item)
    {
        ValidationResult validationResult = new ValidationResult()
        {
            ActivityId = Util.LoadFromXml<Guid>(item.Element(Util.ns.g + "ActivityId")),
            TraceInfo = TraceInfo.LoadFromXml(item.Element(Util.ns.g + "TraceInfo")),
            ValidationSuccess = Util.LoadFromXml<bool>(item.Element(Util.ns.g + "ValidationSuccess"))
        };
        return validationResult;
    }
}