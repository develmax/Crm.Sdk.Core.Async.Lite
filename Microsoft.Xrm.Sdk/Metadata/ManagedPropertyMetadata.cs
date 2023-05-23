using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata;

public sealed class ManagedPropertyMetadata : MetadataBase
{
    public string LogicalName { get; set; }
    public Label DisplayName { get; set; }
    public Label Description { get; set; }
    public ManagedPropertyType? ManagedPropertyType { get; set; }
    public ManagedPropertyOperation? Operation { get; set; }
    public ManagedPropertyEvaluationPriority? EvaluationPriority { get; set; }
    public string EnablesAttributeName { get; set; }
    public string EnablesEntityName { get; set; }
    public int? ErrorCode { get; set; }
    public bool? IsPrivate { get; set; }
    public bool? IsGlobalForOperation { get; set; }
    public string IntroducedVersion { get; set; }
    static internal ManagedPropertyMetadata LoadFromXml(XElement item)
    {
        ManagedPropertyMetadata managedPropertyMetadata = new ManagedPropertyMetadata()
        {
            LogicalName = Util.LoadFromXml<string>(item.Element(Util.ns.h + "LogicalName")),
            DisplayName = Label.LoadFromXml(item.Element(Util.ns.h + "DisplayName")),
            Description = Label.LoadFromXml(item.Element(Util.ns.h + "Description")),
            ManagedPropertyType = Util.LoadFromXml<ManagedPropertyType>(item.Element(Util.ns.h + "ManagedPropertyType")),
            Operation = Util.LoadFromXml<ManagedPropertyOperation>(item.Element(Util.ns.h + "Operation")),
            EvaluationPriority = Util.LoadFromXml<ManagedPropertyEvaluationPriority>(item.Element(Util.ns.h + "EvaluationPriority")),
            EnablesAttributeName = Util.LoadFromXml<string>(item.Element(Util.ns.h + "EnablesAttributeName")),
            EnablesEntityName = Util.LoadFromXml<string>(item.Element(Util.ns.h + "EnablesEntityName")),
            ErrorCode = Util.LoadFromXml<int?>(item.Element(Util.ns.h + "ErrorCode")),
            IsPrivate = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "IsPrivate")),
            IsGlobalForOperation = Util.LoadFromXml<bool?>(item.Element(Util.ns.h + "IsGlobalForOperation")),
            IntroducedVersion = Util.LoadFromXml<string>(item.Element(Util.ns.h + "IntroducedVersion")),
        };
        MetadataBase.LoadFromXml(item, managedPropertyMetadata);
        return managedPropertyMetadata;
    }
}