using System;
using System.Text;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Query;

public sealed class QueryByAttribute : QueryBase
{
    public DataCollection<string> Attributes { get; set; }
    public ColumnSet ColumnSet { get; set; }
    public string EntityName { get; set; }
    public DataCollection<OrderExpression> Orders { get; set; }
    public PagingInfo PageInfo { get; set; }
    public int? TopCount { get; set; }
    public DataCollection<Object> Values { get; set; }
    public QueryByAttribute()
    {
        Attributes = new DataCollection<string>();
        ColumnSet = new ColumnSet();
        Orders = new DataCollection<OrderExpression>();
        Values = new DataCollection<object>();
    }
    public QueryByAttribute(string entityName)
        : this()
    {
        EntityName = entityName;
    }
    public void AddAttributeValue(string attributeName, Object value)
    {
        this.Attributes.Add(attributeName);
        this.Values.Add(value);
    }
    public void AddOrder(string attributeName, OrderType orderType)
    {
        this.Orders.Add(new OrderExpression(attributeName, orderType));
    }
    internal string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(Util.ObjectToXml(Attributes.ToArray(), "a:Attributes", true));
        sb.Append(Util.ObjectToXml(ColumnSet, "a:ColumnSet", true));
        sb.Append(Util.ObjectToXml(EntityName, "a:EntityName", true));
        sb.Append(Util.ObjectToXml(Orders.ToArray(), "a:Orders", true));
        if (this.Values.Count == 0)
        {
            sb.Append("<a:Values/>");
        }
        else
        {
            sb.Append("<a:Values>");
            foreach (object item in this.Values)
            {
                sb.Append(Util.ObjectToXml(item, "f:anyType"));
            }
            sb.Append("</a:Values>");
        }
        sb.Append(Util.ObjectToXml(PageInfo, "a:PagingInfo", true));
        sb.Append(Util.ObjectToXml(TopCount, "a:TopCount", true));
        return sb.ToString();
    }
}