using System;

namespace Microsoft.Xrm.Sdk;

public sealed class RelationshipSchemaNameAttribute : Attribute
{
    public string LogicalName { get; set; }

    public RelationshipSchemaNameAttribute(string logicalName)
    {
        if (String.IsNullOrEmpty(logicalName))
            throw new ArgumentNullException("logicalName");
        LogicalName = logicalName;
    }
}