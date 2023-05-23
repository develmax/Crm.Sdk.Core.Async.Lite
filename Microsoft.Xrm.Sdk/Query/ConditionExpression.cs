using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Query;

public sealed class ConditionExpression
{
    public string AttributeName { get; set; }
    public string EntityName { get; set; }
    public ConditionOperator Operator { get; set; }
    public DataCollection<Object> Values;
    public ConditionExpression()
    {
        Values = new DataCollection<object>();
    }
    public ConditionExpression(string attributeName, ConditionOperator conditionOperator, object value = null)
        : this()
    {
        this.AttributeName = attributeName;
        this.Operator = conditionOperator;
        if (value != null)
        {
            if (value.GetType().IsArray)
            {
                foreach (var item in (Array)value)
                {
                    Values.Add(item);
                }
            }
            else
                this.Values.Add(value);
        }
    }
    public ConditionExpression(string attributeName, ConditionOperator conditionOperator, params object[] values)
        : this()
    {
        this.AttributeName = attributeName;
        this.Operator = conditionOperator;
        foreach (var item in values)
            Values.Add(item);
    }
    public ConditionExpression(string entityName, string attributeName, ConditionOperator conditionOperator, object value = null) :
        this(attributeName, conditionOperator, value)
    {
        this.EntityName = entityName;
    }
    public ConditionExpression(string entityName, string attributeName, ConditionOperator conditionOperator, params object[] values) :
        this(attributeName, conditionOperator, values)
    {
        this.EntityName = entityName;
    }
    internal string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(Util.ObjectToXml(AttributeName, "a:AttributeName", true));
        sb.Append(Util.ObjectToXml(Operator, "a:Operator", true));
        if (this.Values.Count == 0)
            sb.Append("<a:Values/>");
        else
        {
            sb.Append("<a:Values>");
            foreach (object item in Values)
            {
                // If value is passed as List, not Array, then 
                // Need to check here only when operation is In or NotIn
                // No other possibilities???
                if (this.Operator == ConditionOperator.In || this.Operator == ConditionOperator.NotIn)
                {
                    if (item.GetType() == typeof(List<Guid>))
                    {
                        foreach (var o in (List<Guid>)item)
                        {
                            sb.Append(ValueToXml(o));
                        }
                    }
                    else if (item.GetType() == typeof(List<DateTime>))
                    {
                        foreach (var o in (List<DateTime>)item)
                        {
                            sb.Append(ValueToXml(o));
                        }
                    }
                    else if (item.GetType() == typeof(List<Decimal>))
                    {
                        foreach (var o in (List<Decimal>)item)
                        {
                            sb.Append(ValueToXml(o));
                        }
                    }
                    else if (item.GetType() == typeof(List<Double>))
                    {
                        foreach (var o in (List<Double>)item)
                        {
                            sb.Append(ValueToXml(o));
                        }
                    }
                    else if (item.GetType() == typeof(List<EntityReference>))
                    {
                        foreach (var o in (List<EntityReference>)item)
                        {
                            sb.Append(ValueToXml(o));
                        }
                    }
                    else if (item.GetType() == typeof(List<Int32>))
                    {
                        foreach (var o in (List<Int32>)item)
                        {
                            sb.Append(ValueToXml(o));
                        }
                    }
                    else if (item.GetType() == typeof(List<Int64>))
                    {
                        foreach (var o in (List<Int64>)item)
                        {
                            sb.Append(ValueToXml(o));
                        }
                    }
                    else if (item.GetType() == typeof(List<OptionSetValue>))
                    {
                        foreach (var o in (List<OptionSetValue>)item)
                        {
                            sb.Append(ValueToXml(o));
                        }
                    }
                    else if (item.GetType() == typeof(List<string>))
                    {
                        foreach (var o in (List<string>)item)
                        {
                            sb.Append(ValueToXml(o));
                        }
                    }
                    // If it is not List, then it should be single value.
                    else
                        sb.Append(ValueToXml(item));
                }
                else
                    sb.Append(ValueToXml(item));
            }
            sb.Append("</a:Values>");
        }
        sb.Append(Util.ObjectToXml(EntityName, "a:EntityName", true));
        return sb.ToString();
    }
    // As this is unique to ConditionExpression, I don't use each class's ToXml(), but do all job here.
    internal string ValueToXml(object item)
    {
        return Util.ObjectToXml(item, "f:anyType");//Attribute.AttributeValueToXml(item, "f:anyType");           
    }
    static internal ConditionExpression LoadFromXml(XElement item)
    {
        ConditionExpression conditionExpression = new ConditionExpression()
        {
            AttributeName = Util.LoadFromXml<string>(item.Element(Util.ns.a + "AttributeName")),
            EntityName = Util.LoadFromXml<string>(item.Element(Util.ns.a + "EntityName")),
            Operator = Util.LoadFromXml<ConditionOperator>(item.Element(Util.ns.a + "Operator"))
        };
        foreach (XElement value in item.Element(Util.ns.a + "Values").Elements(Util.ns.f + "anyType"))
        {
            conditionExpression.Values.Add(Util.ObjectFromXml(value));
        }
        return conditionExpression;
    }
}