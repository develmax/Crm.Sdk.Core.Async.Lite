using System;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Query;

public sealed class FilterExpression
{
    public DataCollection<ConditionExpression> Conditions { get; set; }
    public LogicalOperator FilterOperator { get; set; }
    public DataCollection<FilterExpression> Filters { get; set; }
    public bool IsQuickFindFilter { get; set; }
    public FilterExpression()
    {
        this.Conditions = new DataCollection<ConditionExpression>();
        this.Filters = new DataCollection<FilterExpression>();
    }
    public FilterExpression(LogicalOperator filterOperator)
        : this()
    {
        this.FilterOperator = filterOperator;
    }
    public void AddCondition(ConditionExpression ConditionExpression)
    {
        this.Conditions.Add(ConditionExpression);
    }
    public void AddCondition(string attributeName, ConditionOperator conditionOperator, params Object[] values)
    {
        if (values.Count() == 0)
            this.Conditions.Add(new ConditionExpression(attributeName, conditionOperator));
        else
            this.Conditions.Add(new ConditionExpression(attributeName, conditionOperator, values));
    }
    public void AddCondition(string entityName, string attributeName, ConditionOperator conditionOperator, params Object[] values)
    {
        this.Conditions.Add(new ConditionExpression(entityName, attributeName, conditionOperator, values));
    }
    public void AddFilter(FilterExpression childFilter)
    {
        this.Filters.Add(childFilter);
    }
    public FilterExpression AddFilter(LogicalOperator logicalOperator)
    {
        FilterExpression filterExpression = new FilterExpression()
        {
            FilterOperator = logicalOperator
        };
        this.Filters.Add(filterExpression);
        return filterExpression;
    }
    internal string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(Util.ObjectToXml(Conditions.ToArray(), "a:Conditions", true));
        sb.Append(Util.ObjectToXml(FilterOperator, "a:FilterOperator", true));
        sb.Append(Util.ObjectToXml(Filters.ToArray(), "a:Filters", true));
        sb.Append(Util.ObjectToXml(IsQuickFindFilter, "a:IsQuickFindFilter", true));
        return sb.ToString();
    }
    static internal FilterExpression LoadFromXml(XElement item)
    {
        FilterExpression filterExpression = new FilterExpression()
        {
            FilterOperator = Util.LoadFromXml<LogicalOperator>(item.Element(Util.ns.a + "FilterOperator"))
        };
        foreach (XElement condition in item.Element(Util.ns.a + "Conditions").Elements(Util.ns.a + "ConditionExpression"))
        {
            filterExpression.Conditions.Add(ConditionExpression.LoadFromXml(condition));
        }
        foreach (XElement filter in item.Element(Util.ns.a + "Filters").Elements(Util.ns.a + "FilterExpression"))
        {
            filterExpression.Filters.Add(FilterExpression.LoadFromXml(filter));
        }
        if (item.Element(Util.ns.a + "IsQuickFindFilter") != null)
            filterExpression.IsQuickFindFilter = Util.LoadFromXml<bool>(item.Element(Util.ns.a + "IsQuickFindFilter"));
        return filterExpression;
    }
}