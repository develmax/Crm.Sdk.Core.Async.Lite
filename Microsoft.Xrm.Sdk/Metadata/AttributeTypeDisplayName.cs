using System;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Metadata;

public sealed class AttributeTypeDisplayName : ConstantsBase<string>
{
    public static readonly AttributeTypeDisplayName BigIntType;
    public static readonly AttributeTypeDisplayName CustomerType;
    public static readonly AttributeTypeDisplayName BooleanType;
    public static readonly AttributeTypeDisplayName CalendarRulesType;
    public static readonly AttributeTypeDisplayName CustomType;
    public static readonly AttributeTypeDisplayName DateTimeType;
    public static readonly AttributeTypeDisplayName DecimalType;
    public static readonly AttributeTypeDisplayName DoubleType;
    public static readonly AttributeTypeDisplayName EntityNameType;
    public static readonly AttributeTypeDisplayName ImageType;
    public static readonly AttributeTypeDisplayName IntegerType;
    public static readonly AttributeTypeDisplayName LookupType;
    public static readonly AttributeTypeDisplayName ManagedPropertyType;
    public static readonly AttributeTypeDisplayName MemoType;
    public static readonly AttributeTypeDisplayName MoneyType;
    public static readonly AttributeTypeDisplayName OwnerType;
    public static readonly AttributeTypeDisplayName PartyListType;
    public static readonly AttributeTypeDisplayName PicklistType;
    public static readonly AttributeTypeDisplayName StateType;
    public static readonly AttributeTypeDisplayName StatusType;
    public static readonly AttributeTypeDisplayName StringType;
    public static readonly AttributeTypeDisplayName UniqueidentifierType;
    public static readonly AttributeTypeDisplayName VirtualType;
    public AttributeTypeDisplayName() { }
    static AttributeTypeDisplayName()
    {
        AttributeTypeDisplayName.BooleanType = Add<AttributeTypeDisplayName>("BooleanType");
        AttributeTypeDisplayName.CustomerType = Add<AttributeTypeDisplayName>("CustomerType");
        AttributeTypeDisplayName.DateTimeType = Add<AttributeTypeDisplayName>("DateTimeType");
        AttributeTypeDisplayName.DecimalType = Add<AttributeTypeDisplayName>("DecimalType");
        AttributeTypeDisplayName.DoubleType = Add<AttributeTypeDisplayName>("DoubleType");
        AttributeTypeDisplayName.IntegerType = Add<AttributeTypeDisplayName>("IntegerType");
        AttributeTypeDisplayName.LookupType = Add<AttributeTypeDisplayName>("LookupType");
        AttributeTypeDisplayName.MemoType = Add<AttributeTypeDisplayName>("MemoType");
        AttributeTypeDisplayName.MoneyType = Add<AttributeTypeDisplayName>("MoneyType");
        AttributeTypeDisplayName.OwnerType = Add<AttributeTypeDisplayName>("OwnerType");
        AttributeTypeDisplayName.PartyListType = Add<AttributeTypeDisplayName>("PartyListType");
        AttributeTypeDisplayName.PicklistType = Add<AttributeTypeDisplayName>("PicklistType");
        AttributeTypeDisplayName.StateType = Add<AttributeTypeDisplayName>("StateType");
        AttributeTypeDisplayName.StatusType = Add<AttributeTypeDisplayName>("StatusType");
        AttributeTypeDisplayName.StringType = Add<AttributeTypeDisplayName>("StringType");
        AttributeTypeDisplayName.UniqueidentifierType = Add<AttributeTypeDisplayName>("UniqueidentifierType");
        AttributeTypeDisplayName.CalendarRulesType = Add<AttributeTypeDisplayName>("CalendarRulesType");
        AttributeTypeDisplayName.VirtualType = Add<AttributeTypeDisplayName>("VirtualType");
        AttributeTypeDisplayName.BigIntType = Add<AttributeTypeDisplayName>("BigIntType");
        AttributeTypeDisplayName.ManagedPropertyType = Add<AttributeTypeDisplayName>("ManagedPropertyType");
        AttributeTypeDisplayName.EntityNameType = Add<AttributeTypeDisplayName>("EntityNameType");
        AttributeTypeDisplayName.ImageType = Add<AttributeTypeDisplayName>("ImageType");
    }
    protected override bool ValueExistsInList(String value)
    {
        return ValidValues.Contains(value, StringComparer.OrdinalIgnoreCase);
    }
    internal string ToValueXml()
    {
        return Util.ObjectToXml(Value, "k:Value", true);
    }
    static internal AttributeTypeDisplayName LoadFromXml(XElement item)
    {
        AttributeTypeDisplayName attributeTypeDisplayName = new AttributeTypeDisplayName();
        if (item.Elements().Count() == 0)
            return attributeTypeDisplayName;

        attributeTypeDisplayName.Value = Util.LoadFromXml<string>(item.Element(Util.ns.k + "Value"));
        return attributeTypeDisplayName;
    }
}