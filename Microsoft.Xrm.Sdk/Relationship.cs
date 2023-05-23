using System;
using System.Text;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk;

public sealed class Relationship
{
    public EntityRole? PrimaryEntityRole { get; set; }
    public string SchemaName { get; set; }
    public Relationship()
    {
    }
    public Relationship(string schemaName)
    {
        if (!String.IsNullOrEmpty(schemaName))
            this.SchemaName = schemaName;
    }
    internal string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(Util.ObjectToXml(PrimaryEntityRole, "a:PrimaryEntityRole", true));
        sb.Append(Util.ObjectToXml(SchemaName, "a:SchemaName", true));
        return sb.ToString();
    }
}