using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata;

[KnownType(typeof(BooleanAttributeMetadata))]
[KnownType(typeof(DateTimeAttributeMetadata))]
[KnownType(typeof(DecimalAttributeMetadata))]
[KnownType(typeof(DoubleAttributeMetadata))]
[KnownType(typeof(EntityNameAttributeMetadata))]
[KnownType(typeof(ImageAttributeMetadata))]
[KnownType(typeof(IntegerAttributeMetadata))]
[KnownType(typeof(BigIntAttributeMetadata))]
[KnownType(typeof(LookupAttributeMetadata))]
[KnownType(typeof(MemoAttributeMetadata))]
[KnownType(typeof(MoneyAttributeMetadata))]
[KnownType(typeof(PicklistAttributeMetadata))]
[KnownType(typeof(StateAttributeMetadata))]
[KnownType(typeof(StatusAttributeMetadata))]
[KnownType(typeof(StringAttributeMetadata))]
[KnownType(typeof(ManagedPropertyAttributeMetadata))]
public class AttributeMetadata : MetadataBase
{
    #region member
    public string AttributeOf { get; set; }
    public AttributeTypeCode? AttributeType { get; set; }
    public AttributeTypeDisplayName AttributeTypeName { get; set; }
    public bool? CanBeSecuredForCreate { get; set; }
    public bool? CanBeSecuredForRead { get; set; }
    public bool? CanBeSecuredForUpdate { get; set; }
    public BooleanManagedProperty CanModifyAdditionalSettings { get; set; }
    public int? ColumnNumber { get; set; }
    public string DeprecatedVersion { get; set; }
    public Label Description { get; set; }
    public Label DisplayName { get; set; }
    public string EntityLogicalName { get; set; }
    public string IntroducedVersion { get; set; }
    public BooleanManagedProperty IsAuditEnabled { get; set; }
    public bool? IsCustomAttribute { get; set; }
    public BooleanManagedProperty IsCustomizable { get; set; }
    public bool? IsLogical { get; set; }
    public bool? IsManaged { get; set; }
    public bool? IsPrimaryId { get; set; }
    public bool? IsPrimaryName { get; set; }
    public BooleanManagedProperty IsRenameable { get; set; }
    public bool? IsSecured { get; set; }
    public BooleanManagedProperty IsValidForAdvancedFind { get; set; }
    public bool? IsValidForCreate { get; set; }
    public bool? IsValidForRead { get; set; }
    public bool? IsValidForUpdate { get; set; }
    public Guid? LinkedAttributeId { get; set; }
    public string LogicalName { get; set; }
    public AttributeRequiredLevelManagedProperty RequiredLevel { get; set; }
    public string SchemaName { get; set; }
    public int? SourceType { get; set; }
    #endregion member
    public AttributeMetadata() { }
    protected AttributeMetadata(AttributeTypeCode attributeType)
    {
        this.AttributeType = attributeType;
        this.AttributeTypeName = GetAttributeTypeDisplayName(attributeType);
    }
    protected AttributeMetadata(AttributeTypeCode attributeType, string schemaName)
        : this(attributeType)
    {
        this.SchemaName = schemaName;
    }
    private AttributeTypeDisplayName GetAttributeTypeDisplayName(AttributeTypeCode attributeType)
    {
        switch (attributeType)
        {
            case AttributeTypeCode.Boolean:
                return AttributeTypeDisplayName.BooleanType;
            case AttributeTypeCode.Customer:
                return AttributeTypeDisplayName.CustomerType;
            case AttributeTypeCode.DateTime:
                return AttributeTypeDisplayName.DateTimeType;
            case AttributeTypeCode.Decimal:
                return AttributeTypeDisplayName.DecimalType;
            case AttributeTypeCode.Double:
                return AttributeTypeDisplayName.DoubleType;
            case AttributeTypeCode.Integer:
                return AttributeTypeDisplayName.IntegerType;
            case AttributeTypeCode.Lookup:
                return AttributeTypeDisplayName.LookupType;
            case AttributeTypeCode.Memo:
                return AttributeTypeDisplayName.MemoType;
            case AttributeTypeCode.Money:
                return AttributeTypeDisplayName.MoneyType;
            case AttributeTypeCode.Owner:
                return AttributeTypeDisplayName.OwnerType;
            case AttributeTypeCode.PartyList:
                return AttributeTypeDisplayName.PartyListType;
            case AttributeTypeCode.Picklist:
                return AttributeTypeDisplayName.PicklistType;
            case AttributeTypeCode.State:
                return AttributeTypeDisplayName.StateType;
            case AttributeTypeCode.Status:
                return AttributeTypeDisplayName.StatusType;
            case AttributeTypeCode.String:
                return AttributeTypeDisplayName.StringType;
            case AttributeTypeCode.Uniqueidentifier:
                return AttributeTypeDisplayName.UniqueidentifierType;
            case AttributeTypeCode.CalendarRules:
                return AttributeTypeDisplayName.CalendarRulesType;
            case AttributeTypeCode.Virtual:
                return AttributeTypeDisplayName.VirtualType;
            case AttributeTypeCode.BigInt:
                return AttributeTypeDisplayName.BigIntType;
            case AttributeTypeCode.ManagedProperty:
                return AttributeTypeDisplayName.ManagedPropertyType;
            case AttributeTypeCode.EntityName:
                return AttributeTypeDisplayName.EntityNameType;
        }
        return null;
    }
    internal new string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(base.ToValueXml());
        sb.Append(Util.ObjectToXml(AttributeOf, "h:AttributeOf", true));
        sb.Append(Util.ObjectToXml(AttributeType, "h:AttributeType", true));
        sb.Append(Util.ObjectToXml(CanBeSecuredForCreate, "h:CanBeSecuredForCreate", true));
        sb.Append(Util.ObjectToXml(CanBeSecuredForRead, "h:CanBeSecuredForRead", true));
        sb.Append(Util.ObjectToXml(CanBeSecuredForUpdate, "h:CanBeSecuredForUpdate", true));
        sb.Append(Util.ObjectToXml(CanModifyAdditionalSettings, "h:CanModifyAdditionalSettings", true));
        sb.Append(Util.ObjectToXml(ColumnNumber, "h:ColumnNumber", true));
        sb.Append(Util.ObjectToXml(DeprecatedVersion, "h:DeprecatedVersion", true));
        sb.Append(Util.ObjectToXml(Description, "h:Description", true));
        sb.Append(Util.ObjectToXml(DisplayName, "h:DisplayName", true));
        sb.Append(Util.ObjectToXml(EntityLogicalName, "h:EntityLogicalName", true));
        sb.Append(Util.ObjectToXml(IsAuditEnabled, "h:IsAuditEnabled", true));
        sb.Append(Util.ObjectToXml(IsCustomAttribute, "h:IsCustomAttribute", true));
        sb.Append(Util.ObjectToXml(IsCustomizable, "h:IsCustomizable", true));
        sb.Append(Util.ObjectToXml(IsLogical, "h:IsLogical", true));
        sb.Append(Util.ObjectToXml(IsManaged, "h:IsManaged", true));
        sb.Append(Util.ObjectToXml(IsPrimaryId, "h:IsPrimaryId", true));
        sb.Append(Util.ObjectToXml(IsPrimaryName, "h:IsPrimaryName", true));
        sb.Append(Util.ObjectToXml(IsRenameable, "h:IsRenameable", true));
        sb.Append(Util.ObjectToXml(IsSecured, "h:IsSecured", true));
        sb.Append(Util.ObjectToXml(IsValidForAdvancedFind, "h:IsValidForAdvancedFind", true));
        sb.Append(Util.ObjectToXml(IsValidForCreate, "h:IsValidForCreate", true));
        sb.Append(Util.ObjectToXml(IsValidForRead, "h:IsValidForRead", true));
        sb.Append(Util.ObjectToXml(IsValidForUpdate, "h:IsValidForUpdate", true));
        sb.Append(Util.ObjectToXml(LinkedAttributeId, "h:LinkedAttributeId", true));
        sb.Append(Util.ObjectToXml(LogicalName, "h:LogicalName", true));
        sb.Append(Util.ObjectToXml(RequiredLevel, "h:RequiredLevel", true));
        sb.Append(Util.ObjectToXml(SchemaName, "h:SchemaName", true));
        sb.Append(Util.ObjectToXml(SourceType, "h:SourceType", true));
        sb.Append(Util.ObjectToXml(AttributeTypeName, "h:AttributeTypeName", true));
        sb.Append(Util.ObjectToXml(IntroducedVersion, "h:IntroducedVersion", true));
        return sb.ToString();
    }
    internal string ToXml(AttributeMetadata meta, string action = null)
    {
        string s = "";
        switch (meta.GetType().Name)
        {
            case "ImageAttributeMetadata":
                s = Util.ObjectToXml((ImageAttributeMetadata)meta, action);
                break;
            case "MoneyAttributeMetadata":
                s = Util.ObjectToXml((MoneyAttributeMetadata)meta, action);
                break;
            case "PicklistAttributeMetadata":
                s = Util.ObjectToXml((PicklistAttributeMetadata)meta, action);
                break;
            case "MemoAttributeMetadata":
                s = Util.ObjectToXml((MemoAttributeMetadata)meta, action);
                break;
            case "ManagedPropertyAttributeMetadata":
                s = Util.ObjectToXml((ManagedPropertyAttributeMetadata)meta, action);
                break;
            case "BooleanAttributeMetadata":
                s = Util.ObjectToXml((BooleanAttributeMetadata)meta, action);
                break;
            case "DateTimeAttributeMetadata":
                s = Util.ObjectToXml((DateTimeAttributeMetadata)meta, action);
                break;
            case "DecimalAttributeMetadata":
                s = Util.ObjectToXml((DecimalAttributeMetadata)meta, action);
                break;
            case "DoubleAttributeMetadata":
                s = Util.ObjectToXml((DoubleAttributeMetadata)meta, action);
                break;
            case "EntityNameAttributeMetadata":
                s = Util.ObjectToXml((EntityNameAttributeMetadata)meta, action);
                break;
            case "IntegerAttributeMetadata":
                s = Util.ObjectToXml((IntegerAttributeMetadata)meta, action);
                break;
            case "BigIntAttributeMetadata":
                s = Util.ObjectToXml((BigIntAttributeMetadata)meta, action);
                break;
            case "LookupAttributeMetadata":
                s = Util.ObjectToXml((LookupAttributeMetadata)meta, action);
                break;
            case "StateAttributeMetadata":
                s = Util.ObjectToXml((StateAttributeMetadata)meta, action);
                break;
            case "StatusAttributeMetadata":
                s = Util.ObjectToXml((StatusAttributeMetadata)meta, action);
                break;
            case "StringAttributeMetadata":
                s = Util.ObjectToXml((StringAttributeMetadata)meta, action);
                break;
        }
        return s;
    }
    static internal AttributeMetadata LoadFromXml(XElement item)
    {
        AttributeMetadata attributeMetadata = new AttributeMetadata();
        string type = (item.Attribute(Util.ns.i + "type") == null) ? "AttributeMetadata" :
            item.Attribute(Util.ns.i + "type").Value.Substring(2);
        switch (type)
        {
            case "ImageAttributeMetadata":
                attributeMetadata = ImageAttributeMetadata.LoadFromXml(item);
                break;
            case "MoneyAttributeMetadata":
                attributeMetadata = MoneyAttributeMetadata.LoadFromXml(item);
                break;
            case "PicklistAttributeMetadata":
                attributeMetadata = PicklistAttributeMetadata.LoadFromXml(item);
                break;
            case "MemoAttributeMetadata":
                attributeMetadata = MemoAttributeMetadata.LoadFromXml(item);
                break;
            case "ManagedPropertyAttributeMetadata":
                attributeMetadata = ManagedPropertyAttributeMetadata.LoadFromXml(item);
                break;
            case "BooleanAttributeMetadata":
                attributeMetadata = BooleanAttributeMetadata.LoadFromXml(item);
                break;
            case "DateTimeAttributeMetadata":
                attributeMetadata = DateTimeAttributeMetadata.LoadFromXml(item);
                break;
            case "DecimalAttributeMetadata":
                attributeMetadata = DecimalAttributeMetadata.LoadFromXml(item);
                break;
            case "DoubleAttributeMetadata":
                attributeMetadata = DoubleAttributeMetadata.LoadFromXml(item);
                break;
            case "EntityNameAttributeMetadata":
                attributeMetadata = EntityNameAttributeMetadata.LoadFromXml(item);
                break;
            case "IntegerAttributeMetadata":
                attributeMetadata = IntegerAttributeMetadata.LoadFromXml(item);
                break;
            case "BigIntAttributeMetadata":
                attributeMetadata = BigIntAttributeMetadata.LoadFromXml(item);
                break;
            case "LookupAttributeMetadata":
                attributeMetadata = LookupAttributeMetadata.LoadFromXml(item);
                break;
            case "StateAttributeMetadata":
                attributeMetadata = StateAttributeMetadata.LoadFromXml(item);
                break;
            case "StatusAttributeMetadata":
                attributeMetadata = StatusAttributeMetadata.LoadFromXml(item);
                break;
            case "StringAttributeMetadata":
                attributeMetadata = StringAttributeMetadata.LoadFromXml(item);
                break;
            default:
                AttributeMetadata.LoadFromXml(item, attributeMetadata);
                break;
        }
        return attributeMetadata;
    }
    static internal void LoadFromXml(XElement item, AttributeMetadata meta)
    {
        if (item.Elements().Count() == 0)
            return;
        MetadataBase.LoadFromXml(item, meta);
        meta.AttributeOf = Util.LoadFromXml<string>(item.Element(Util.ns.h + "AttributeOf"));
        meta.AttributeTypeName = AttributeTypeDisplayName.LoadFromXml(item.Element(Util.ns.h + "AttributeTypeName"));
        meta.AttributeType = Util.LoadFromXml<AttributeTypeCode?>(item.Element(Util.ns.h + "AttributeType"));
        meta.CanBeSecuredForCreate = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "CanBeSecuredForCreate"));
        meta.CanBeSecuredForRead = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "CanBeSecuredForRead"));
        meta.CanBeSecuredForUpdate = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "CanBeSecuredForUpdate"));
        meta.CanModifyAdditionalSettings = BooleanManagedProperty.LoadFromXml(item.Element(Util.ns.h + "CanModifyAdditionalSettings"));
        meta.ColumnNumber = Util.LoadFromXml<int?>(item.Element(Util.ns.h + "ColumnNumber"));
        meta.DeprecatedVersion = Util.LoadFromXml<string>(item.Element(Util.ns.h + "DeprecatedVersion"));
        meta.Description = Label.LoadFromXml(item.Element(Util.ns.h + "Description"));
        meta.DisplayName = Label.LoadFromXml(item.Element(Util.ns.h + "DisplayName"));
        meta.EntityLogicalName = Util.LoadFromXml<string>(item.Element(Util.ns.h + "EntityLogicalName"));
        meta.IntroducedVersion = Util.LoadFromXml<string>(item.Element(Util.ns.h + "IntroducedVersion"));
        meta.IsAuditEnabled = BooleanManagedProperty.LoadFromXml(item.Element(Util.ns.h + "IsAuditEnabled"));
        meta.IsCustomAttribute = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "IsCustomAttribute"));
        meta.IsCustomizable = BooleanManagedProperty.LoadFromXml(item.Element(Util.ns.h + "IsCustomizable"));
        meta.IsLogical = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "IsLogical"));
        meta.IsManaged = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "IsManaged"));
        meta.IsPrimaryId = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "IsPrimaryId"));
        meta.IsPrimaryName = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "IsPrimaryName"));
        meta.IsRenameable = BooleanManagedProperty.LoadFromXml(item.Element(Util.ns.h + "IsRenameable"));
        meta.IsSecured = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "IsSecured"));
        meta.IsValidForAdvancedFind = BooleanManagedProperty.LoadFromXml(item.Element(Util.ns.h + "IsValidForAdvancedFind"));
        meta.IsValidForCreate = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "IsValidForCreate"));
        meta.IsValidForRead = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "IsValidForRead"));
        meta.IsValidForUpdate = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "IsValidForUpdate"));
        meta.LinkedAttributeId = Util.LoadFromXml<Guid?>(item.Element(Util.ns.h + "LinkedAttributeId"));
        meta.LogicalName = Util.LoadFromXml<string>(item.Element(Util.ns.h + "LogicalName"));
        meta.RequiredLevel = AttributeRequiredLevelManagedProperty.LoadFromXml(item.Element(Util.ns.h + "RequiredLevel"));
        meta.SchemaName = Util.LoadFromXml<string>(item.Element(Util.ns.h + "SchemaName"));
        meta.SourceType = Util.LoadFromXml<int?>(item.Element(Util.ns.h + "SourceType"));
    }
}