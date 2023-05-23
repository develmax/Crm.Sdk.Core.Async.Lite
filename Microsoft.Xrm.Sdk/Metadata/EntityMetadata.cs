using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata;

public sealed class EntityMetadata : MetadataBase
{
    #region members
    public int? ActivityTypeMask { get; set; }
    public AttributeMetadata[] Attributes { get; set; }
    public bool? AutoCreateAccessTeams { get; set; }
    public bool? AutoRouteToOwnerQueue { get; set; }
    public BooleanManagedProperty CanBeInManyToMany { get; set; }
    public BooleanManagedProperty CanBePrimaryEntityInRelationship { get; set; }
    public BooleanManagedProperty CanBeRelatedEntityInRelationship { get; set; }
    public BooleanManagedProperty CanCreateAttributes { get; set; }
    public BooleanManagedProperty CanCreateCharts { get; set; }
    public BooleanManagedProperty CanCreateForms { get; set; }
    public BooleanManagedProperty CanCreateViews { get; set; }
    public BooleanManagedProperty CanModifyAdditionalSettings { get; set; }
    public bool? CanTriggerWorkflow { get; set; }
    public Label Description { get; set; }
    public Label DisplayCollectionName { get; set; }
    public Label DisplayName { get; set; }
    public string IconLargeName { get; set; }
    public string IconMediumName { get; set; }
    public string IconSmallName { get; set; }
    public string IntroducedVersion { get; set; }
    public bool? IsActivity { get; set; }
    public bool? IsActivityParty { get; set; }
    public bool? IsAIRUpdated { get; set; }
    public BooleanManagedProperty IsAuditEnabled { get; set; }
    public bool? IsAvailableOffline { get; set; }
    public bool? IsBusinessProcessEnabled { get; set; }
    public bool? IsChildEntity { get; set; }
    public BooleanManagedProperty IsConnectionsEnabled { get; set; }
    public bool? IsCustomEntity { get; set; }
    public BooleanManagedProperty IsCustomizable { get; set; }
    public bool? IsDocumentManagementEnabled { get; set; }
    public BooleanManagedProperty IsDuplicateDetectionEnabled { get; set; }
    public bool? IsEnabledForCharts { get; set; }
    public bool? IsEnabledForTrace { get; set; }
    public bool? IsImportable { get; set; }
    public bool? IsIntersect { get; set; }
    public BooleanManagedProperty IsMailMergeEnabled { get; set; }
    public bool? IsManaged { get; set; }
    public BooleanManagedProperty IsMappable { get; set; }
    public bool? IsQuickCreateEnabled { get; set; }
    public bool? IsReadingPaneEnabled { get; set; }
    public BooleanManagedProperty IsReadOnlyInMobileClient { get; set; }
    public BooleanManagedProperty IsRenameable { get; set; }
    public bool? IsValidForAdvancedFind { get; set; }
    public BooleanManagedProperty IsValidForQueue { get; set; }
    public BooleanManagedProperty IsVisibleInMobile { get; set; }
    public BooleanManagedProperty IsVisibleInMobileClient { get; set; }
    public string LogicalName { get; set; }
    public ManyToManyRelationshipMetadata[] ManyToManyRelationships { get; set; }
    public OneToManyRelationshipMetadata[] ManyToOneRelationships { get; set; }
    public int? ObjectTypeCode { get; set; }
    public OneToManyRelationshipMetadata[] OneToManyRelationships { get; set; }
    public OwnershipTypes? OwnershipType { get; set; }
    public string PrimaryIdAttribute { get; set; }
    public string PrimaryImageAttribute { get; set; }
    public string PrimaryNameAttribute { get; set; }
    public SecurityPrivilegeMetadata[] Privileges { get; set; }
    public string RecurrenceBaseEntityLogicalName { get; set; }
    public string ReportViewName { get; set; }
    public string SchemaName { get; set; }
    #endregion members
    public EntityMetadata()
    {
        Attributes = new List<AttributeMetadata>().ToArray();
        ManyToManyRelationships = new List<ManyToManyRelationshipMetadata>().ToArray();
        ManyToOneRelationships = new List<OneToManyRelationshipMetadata>().ToArray();
        OneToManyRelationships = new List<OneToManyRelationshipMetadata>().ToArray();
        Privileges = new List<SecurityPrivilegeMetadata>().ToArray();
    }
    internal new string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(base.ToValueXml());
        sb.Append(Util.ObjectToXml(ActivityTypeMask, "h:ActivityTypeMask", true));
        if (this.Attributes == null)
            sb.Append("<h:Attributes i:nil='true'/>");
        else
        {
            sb.Append("<h:Attributes>");
            foreach (AttributeMetadata Attribute in Attributes)
            {
                sb.Append(Attribute.ToXml(Attribute, "h:AttributeMetadata"));
            }
            sb.Append("</h:Attributes>");
        }
        sb.Append(Util.ObjectToXml(AutoCreateAccessTeams, "h:AutoCreateAccessTeams", true));
        sb.Append(Util.ObjectToXml(AutoRouteToOwnerQueue, "h:AutoRouteToOwnerQueue", true));
        sb.Append(Util.ObjectToXml(CanBeInManyToMany, "h:CanBeInManyToMany", true));
        sb.Append(Util.ObjectToXml(CanBePrimaryEntityInRelationship, "h:CanBePrimaryEntityInRelationship", true));
        sb.Append(Util.ObjectToXml(CanBeRelatedEntityInRelationship, "h:CanBeRelatedEntityInRelationship", true));
        sb.Append(Util.ObjectToXml(CanCreateAttributes, "h:CanCreateAttributes", true));
        sb.Append(Util.ObjectToXml(CanCreateCharts, "h:CanCreateCharts", true));
        sb.Append(Util.ObjectToXml(CanCreateForms, "h:CanCreateForms", true));
        sb.Append(Util.ObjectToXml(CanCreateViews, "h:CanCreateViews", true));
        sb.Append(Util.ObjectToXml(CanModifyAdditionalSettings, "h:CanModifyAdditionalSettings", true));
        sb.Append(Util.ObjectToXml(CanTriggerWorkflow, "h:CanTriggerWorkflow", true));
        sb.Append(Util.ObjectToXml(Description, "h:Description", true));
        sb.Append(Util.ObjectToXml(DisplayCollectionName, "h:DisplayCollectionName", true));
        sb.Append(Util.ObjectToXml(DisplayName, "h:DisplayName", true));
        sb.Append(Util.ObjectToXml(IconLargeName, "h:IconLargeName", true));
        sb.Append(Util.ObjectToXml(IconMediumName, "h:IconMediumName", true));
        sb.Append(Util.ObjectToXml(IconSmallName, "h:IconSmallName", true));
        sb.Append(Util.ObjectToXml(IsAIRUpdated, "h:IsAIRUpdated", true));
        sb.Append(Util.ObjectToXml(IsActivity, "h:IsActivity", true));
        sb.Append(Util.ObjectToXml(IsActivityParty, "h:IsActivityParty", true));
        sb.Append(Util.ObjectToXml(IsAuditEnabled, "h:IsAuditEnabled", true));
        sb.Append(Util.ObjectToXml(IsAvailableOffline, "h:IsAvailableOffline", true));
        sb.Append(Util.ObjectToXml(IsBusinessProcessEnabled, "h:IsBusinessProcessEnabled", true));
        sb.Append(Util.ObjectToXml(IsChildEntity, "h:IsChildEntity", true));
        sb.Append(Util.ObjectToXml(IsConnectionsEnabled, "h:IsConnectionsEnabled", true));
        sb.Append(Util.ObjectToXml(IsCustomEntity, "h:IsCustomEntity", true));
        sb.Append(Util.ObjectToXml(IsCustomizable, "h:IsCustomizable", true));
        sb.Append(Util.ObjectToXml(IsDocumentManagementEnabled, "h:IsDocumentManagementEnabled", true));
        sb.Append(Util.ObjectToXml(IsDuplicateDetectionEnabled, "h:IsDuplicateDetectionEnabled", true));
        sb.Append(Util.ObjectToXml(IsEnabledForCharts, "h:IsEnabledForCharts", true));
        sb.Append(Util.ObjectToXml(IsEnabledForTrace, "h:IsEnabledForTrace", true));
        sb.Append(Util.ObjectToXml(IsImportable, "h:IsImportable", true));
        sb.Append(Util.ObjectToXml(IsIntersect, "h:IsIntersect", true));
        sb.Append(Util.ObjectToXml(IsMailMergeEnabled, "h:IsMailMergeEnabled", true));
        sb.Append(Util.ObjectToXml(IsManaged, "h:IsManaged", true));
        sb.Append(Util.ObjectToXml(IsMappable, "h:IsMappable", true));
        sb.Append(Util.ObjectToXml(IsQuickCreateEnabled, "h:IsQuickCreateEnabled", true));
        sb.Append(Util.ObjectToXml(IsReadOnlyInMobileClient, "h:IsReadOnlyInMobileClient", true));
        sb.Append(Util.ObjectToXml(IsReadingPaneEnabled, "h:IsReadingPaneEnabled", true));
        sb.Append(Util.ObjectToXml(IsRenameable, "h:IsRenameable", true));
        sb.Append(Util.ObjectToXml(IsValidForAdvancedFind, "h:IsValidForAdvancedFind", true));
        sb.Append(Util.ObjectToXml(IsValidForQueue, "h:IsValidForQueue", true));
        sb.Append(Util.ObjectToXml(IsVisibleInMobile, "h:IsVisibleInMobile", true));
        sb.Append(Util.ObjectToXml(IsVisibleInMobileClient, "h:IsVisibleInMobileClient", true));
        sb.Append(Util.ObjectToXml(LogicalName, "h:LogicalName", true));
        sb.Append(Util.ObjectToXml(ManyToManyRelationships, "h:ManyToManyRelationships", true));
        sb.Append(Util.ObjectToXml(ManyToManyRelationships, "h:ManyToOneRelationships", true));
        sb.Append(Util.ObjectToXml(ObjectTypeCode, "h:ObjectTypeCode", true));
        sb.Append(Util.ObjectToXml(ManyToManyRelationships, "h:OneToManyRelationships", true));
        sb.Append(Util.ObjectToXml(OwnershipType, "h:OwnershipType", true));
        sb.Append(Util.ObjectToXml(PrimaryIdAttribute, "h:PrimaryIdAttribute", true));
        sb.Append(Util.ObjectToXml(PrimaryNameAttribute, "h:PrimaryNameAttribute", true));
        sb.Append(Util.ObjectToXml(Privileges, "h:Privileges", true));
        sb.Append(Util.ObjectToXml(RecurrenceBaseEntityLogicalName, "h:RecurrenceBaseEntityLogicalName", true));
        sb.Append(Util.ObjectToXml(ReportViewName, "h:ReportViewName", true));
        sb.Append(Util.ObjectToXml(SchemaName, "h:SchemaName", true));
        sb.Append(Util.ObjectToXml(PrimaryImageAttribute, "h:PrimaryImageAttribute", true));
        sb.Append(Util.ObjectToXml(IntroducedVersion, "h:IntroducedVersion", true));
        return sb.ToString();
    }
    static internal EntityMetadata LoadFromXml(XElement item)
    {
        List<AttributeMetadata> attributeMetadataList = new List<AttributeMetadata>();
        foreach (var attributeMetadatas in item.Elements(Util.ns.h + "Attributes"))
        {
            foreach (var attributeMetadata in attributeMetadatas.Elements(Util.ns.h + "AttributeMetadata"))
            {
                attributeMetadataList.Add(AttributeMetadata.LoadFromXml(attributeMetadata));
            }
        }
        List<ManyToManyRelationshipMetadata> manyToManyRelationshipMetadataList = new List<ManyToManyRelationshipMetadata>();
        foreach (var manyToManyRelationships in item.Elements(Util.ns.h + "ManyToManyRelationships"))
        {
            foreach (var manyToManyRelationship in manyToManyRelationships.Elements(Util.ns.h + "ManyToManyRelationshipMetadata"))
            {
                manyToManyRelationshipMetadataList.Add(ManyToManyRelationshipMetadata.LoadFromXml(manyToManyRelationship));
            }
        }
        List<OneToManyRelationshipMetadata> manyToOneRelationshipMetadataList = new List<OneToManyRelationshipMetadata>();
        foreach (var manyToOneRelationships in item.Elements(Util.ns.h + "ManyToOneRelationships"))
        {
            foreach (var oneToManyRelationshipMetadata in manyToOneRelationships.Elements(Util.ns.h + "OneToManyRelationshipMetadata"))
            {
                manyToOneRelationshipMetadataList.Add(OneToManyRelationshipMetadata.LoadFromXml(oneToManyRelationshipMetadata));
            }
        }
        List<OneToManyRelationshipMetadata> oneToManyRelationshipMetadataList = new List<OneToManyRelationshipMetadata>();
        foreach (var manyToOneRelationships in item.Elements(Util.ns.h + "OneToManyRelationships"))
        {
            foreach (var oneToManyRelationshipMetadata in manyToOneRelationships.Elements(Util.ns.h + "OneToManyRelationshipMetadata"))
            {
                oneToManyRelationshipMetadataList.Add(OneToManyRelationshipMetadata.LoadFromXml(oneToManyRelationshipMetadata));
            }
        }
        List<SecurityPrivilegeMetadata> securityPrivilegeMetadataList = new List<SecurityPrivilegeMetadata>();
        foreach (var securityPrivilegeMetadatas in item.Elements(Util.ns.h + "Privileges"))
        {
            foreach (var securityPrivilegeMetadata in securityPrivilegeMetadatas.Elements(Util.ns.h + "SecurityPrivilegeMetadata"))
            {
                securityPrivilegeMetadataList.Add(SecurityPrivilegeMetadata.LoadFromXml(securityPrivilegeMetadata));
            }
        }
        EntityMetadata entityMetadata = new EntityMetadata()
        {
            Attributes = attributeMetadataList.ToArray(),
            ActivityTypeMask = Util.LoadFromXml<int?>(item.Element(Util.ns.h + "ActivityTypeMask")),
            AutoCreateAccessTeams = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "AutoCreateAccessTeams")),
            AutoRouteToOwnerQueue = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "AutoRouteToOwnerQueue")),
            CanBeInManyToMany = BooleanManagedProperty.LoadFromXml(item.Element(Util.ns.h + "CanBeInManyToMany")),
            CanBePrimaryEntityInRelationship = BooleanManagedProperty.LoadFromXml(item.Element(Util.ns.h + "CanBePrimaryEntityInRelationship")),
            CanBeRelatedEntityInRelationship = BooleanManagedProperty.LoadFromXml(item.Element(Util.ns.h + "CanBeRelatedEntityInRelationship")),
            CanCreateAttributes = BooleanManagedProperty.LoadFromXml(item.Element(Util.ns.h + "CanCreateAttributes")),
            CanCreateCharts = BooleanManagedProperty.LoadFromXml(item.Element(Util.ns.h + "CanCreateCharts")),
            CanCreateForms = BooleanManagedProperty.LoadFromXml(item.Element(Util.ns.h + "CanCreateForms")),
            CanCreateViews = BooleanManagedProperty.LoadFromXml(item.Element(Util.ns.h + "CanCreateViews")),
            CanModifyAdditionalSettings = BooleanManagedProperty.LoadFromXml(item.Element(Util.ns.h + "CanModifyAdditionalSettings")),
            CanTriggerWorkflow = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "CanTriggerWorkflow")),
            Description = Label.LoadFromXml(item.Element(Util.ns.h + "Description")),
            DisplayCollectionName = Label.LoadFromXml(item.Element(Util.ns.h + "DisplayCollectionName")),
            DisplayName = Label.LoadFromXml(item.Element(Util.ns.h + "DisplayName")),
            IconLargeName = Util.LoadFromXml<string>(item.Element(Util.ns.h + "IconLargeName")),
            IconMediumName = Util.LoadFromXml<string>(item.Element(Util.ns.h + "IconMediumName")),
            IconSmallName = Util.LoadFromXml<string>(item.Element(Util.ns.h + "IconSmallName")),
            IntroducedVersion = Util.LoadFromXml<string>(item.Element(Util.ns.h + "IntroducedVersion")),
            IsActivity = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "IsActivity")),
            IsActivityParty = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "IsActivityParty")),
            IsAIRUpdated = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "IsAIRUpdated")),
            IsAuditEnabled = BooleanManagedProperty.LoadFromXml(item.Element(Util.ns.h + "IsAuditEnabled")),
            IsAvailableOffline = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "IsAvailableOffline")),
            IsBusinessProcessEnabled = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "IsBusinessProcessEnabled")),
            IsChildEntity = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "IsChildEntity")),
            IsConnectionsEnabled = BooleanManagedProperty.LoadFromXml(item.Element(Util.ns.h + "IsConnectionsEnabled")),
            IsCustomEntity = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "IsCustomEntity")),
            IsCustomizable = BooleanManagedProperty.LoadFromXml(item.Element(Util.ns.h + "IsCustomizable")),
            IsDocumentManagementEnabled = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "IsDocumentManagementEnabled")),
            IsDuplicateDetectionEnabled = BooleanManagedProperty.LoadFromXml(item.Element(Util.ns.h + "IsDuplicateDetectionEnabled")),
            IsEnabledForCharts = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "IsEnabledForCharts")),
            IsEnabledForTrace = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "IsEnabledForTrace")),
            IsImportable = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "IsImportable")),
            IsIntersect = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "IsIntersect")),
            IsMailMergeEnabled = BooleanManagedProperty.LoadFromXml(item.Element(Util.ns.h + "IsMailMergeEnabled")),
            IsManaged = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "IsManaged")),
            IsMappable = BooleanManagedProperty.LoadFromXml(item.Element(Util.ns.h + "IsMappable")),
            IsQuickCreateEnabled = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "IsQuickCreateEnabled")),
            IsReadingPaneEnabled = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "IsReadingPaneEnabled")),
            IsReadOnlyInMobileClient = BooleanManagedProperty.LoadFromXml(item.Element(Util.ns.h + "IsReadOnlyInMobileClient")),
            IsRenameable = BooleanManagedProperty.LoadFromXml(item.Element(Util.ns.h + "IsRenameable")),
            IsValidForAdvancedFind = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "IsValidForAdvancedFind")),
            IsValidForQueue = BooleanManagedProperty.LoadFromXml(item.Element(Util.ns.h + "IsValidForQueue")),
            IsVisibleInMobile = BooleanManagedProperty.LoadFromXml(item.Element(Util.ns.h + "IsVisibleInMobile")),
            IsVisibleInMobileClient = BooleanManagedProperty.LoadFromXml(item.Element(Util.ns.h + "IsVisibleInMobileClient")),
            LogicalName = Util.LoadFromXml<string>(item.Element(Util.ns.h + "LogicalName")),
            ManyToManyRelationships = manyToManyRelationshipMetadataList.ToArray(),
            ManyToOneRelationships = manyToOneRelationshipMetadataList.ToArray(),
            ObjectTypeCode = Util.LoadFromXml<int?>(item.Element(Util.ns.h + "ObjectTypeCode")),
            OneToManyRelationships = oneToManyRelationshipMetadataList.ToArray(),
            OwnershipType = Util.LoadFromXml<OwnershipTypes?>(item.Element(Util.ns.h + "OwnershipType")),
            PrimaryIdAttribute = Util.LoadFromXml<string>(item.Element(Util.ns.h + "PrimaryIdAttribute")),
            PrimaryImageAttribute = Util.LoadFromXml<string>(item.Element(Util.ns.h + "PrimaryImageAttribute")),
            PrimaryNameAttribute = Util.LoadFromXml<string>(item.Element(Util.ns.h + "PrimaryNameAttribute")),
            Privileges = securityPrivilegeMetadataList.ToArray(),
            RecurrenceBaseEntityLogicalName = Util.LoadFromXml<string>(item.Element(Util.ns.h + "RecurrenceBaseEntityLogicalName")),
            ReportViewName = Util.LoadFromXml<string>(item.Element(Util.ns.h + "ReportViewName")),
            SchemaName = Util.LoadFromXml<string>(item.Element(Util.ns.h + "SchemaName")),
        };
        MetadataBase.LoadFromXml(item, entityMetadata);
        return entityMetadata;
    }
}