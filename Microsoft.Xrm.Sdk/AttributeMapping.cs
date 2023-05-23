using System;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk;

public sealed class AttributeMapping
{
    public int AllowedSyncDirection { get; set; }
    public string AttributeCrmDisplayName { get; set; }
    public string AttributeCrmName { get; set; }
    public string AttributeExchangeDisplayName { get; set; }
    public string AttributeExchangeName { get; set; }
    public Guid AttributeMappingId { get; set; }
    public DataCollection<string> ComputedProperties { get; set; }
    public int DefaultSyncDirection { get; set; }
    public int EntityTypeCode { get; set; }
    public bool IsComputed { get; set; }
    public string MappingName { get; set; }
    public int SyncDirection { get; set; }
    public AttributeMapping()
    {
        ComputedProperties = new DataCollection<string>();
    }
    public AttributeMapping(Guid attributeMappingId, string mappingName, string attributeCrmName,
        string attributeExchangeName, int entityTypeCode, int syncDirection, int defaultSyncDirection,
        int allowedSyncDirection, bool isComputed, DataCollection<string> computedProperties,
        string attributeCrmDisplayName, string attributeExchangeDisplayName)
        : base()
    {
        this.AttributeMappingId = attributeMappingId;
        this.MappingName = mappingName;
        this.AttributeCrmName = attributeCrmName;
        this.AttributeExchangeDisplayName = attributeExchangeDisplayName;
        this.EntityTypeCode = entityTypeCode;
        this.SyncDirection = syncDirection;
        this.DefaultSyncDirection = defaultSyncDirection;
        this.AllowedSyncDirection = allowedSyncDirection;
        this.IsComputed = isComputed;
        this.ComputedProperties = computedProperties;
        this.AttributeCrmDisplayName = attributeCrmDisplayName;
        this.AttributeExchangeDisplayName = attributeExchangeDisplayName;
    }
    static internal AttributeMapping LoadFromXml(XElement item)
    {
        AttributeMapping attributeMapping = new AttributeMapping()
        {
            AllowedSyncDirection = Util.LoadFromXml<int>(item.Element(Util.ns.m + "AllowedSyncDirection")),
            AttributeCrmDisplayName = Util.LoadFromXml<string>(item.Element(Util.ns.m + "AttributeCrmDisplayName")),
            AttributeCrmName = Util.LoadFromXml<string>(item.Element(Util.ns.m + "AttributeCrmName")),
            AttributeExchangeDisplayName = Util.LoadFromXml<string>(item.Element(Util.ns.c + "AttributeExchangeDisplayName")),
            AttributeExchangeName = Util.LoadFromXml<string>(item.Element(Util.ns.m + "AttributeExchangeName")),
            AttributeMappingId = Util.LoadFromXml<Guid>(item.Element(Util.ns.m + "AttributeMappingId")),
            //ComputedProperties = Util.LoadFromXml<DataCollection<string>>(item.Element(Util.ns.m + "ComputedProperties")),
            DefaultSyncDirection = Util.LoadFromXml<int>(item.Element(Util.ns.m + "DefaultSyncDirection")),
            EntityTypeCode = Util.LoadFromXml<int>(item.Element(Util.ns.m + "EntityTypeCode")),
            IsComputed = Util.LoadFromXml<bool>(item.Element(Util.ns.m + "IsComputed")),
            MappingName = Util.LoadFromXml<string>(item.Element(Util.ns.m + "MappingName")),
            SyncDirection = Util.LoadFromXml<int>(item.Element(Util.ns.m + "SyncDirection"))
        };
        foreach (XElement value in item.Elements(Util.ns.m + "ComputedProperties").Elements(Util.ns.f + "string"))
        {
            attributeMapping.ComputedProperties.Add(value.Value);
        }
        return attributeMapping;
    }
}