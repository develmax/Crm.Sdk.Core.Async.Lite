using System;

namespace Microsoft.Xrm.Sdk;

public sealed class AttributeLogicalNameAttribute : Attribute
{
    public string LogicalName { get; set; }

    public AttributeLogicalNameAttribute(string logicalName)
    {
        if (String.IsNullOrEmpty(logicalName))
            throw new ArgumentNullException("logicalName");
        LogicalName = logicalName;
    }
}