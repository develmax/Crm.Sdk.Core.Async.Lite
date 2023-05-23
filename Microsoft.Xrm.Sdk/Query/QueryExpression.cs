using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Query;

public sealed class QueryExpression : QueryBase
{
    public ColumnSet ColumnSet { get; set; }
    public FilterExpression Criteria { get; set; }
    public bool Distinct { get; set; }
    public string EntityName { get; set; }
    public DataCollection<LinkEntity> LinkEntities { get; set; }
    public bool NoLock { get; set; }
    public DataCollection<OrderExpression> Orders { get; set; }
    public PagingInfo PageInfo { get; set; }
    public int? TopCount { get; set; }
    public QueryExpression(string EntityName = null, ColumnSet columnSet = null)
    {
        ColumnSet = new ColumnSet();
        if (columnSet != null)
            this.ColumnSet = columnSet;
        this.Criteria = new FilterExpression();
        this.LinkEntities = new DataCollection<LinkEntity>();
        this.Orders = new DataCollection<OrderExpression>();
        this.PageInfo = new PagingInfo();
        this.EntityName = EntityName;
    }
    public LinkEntity AddLink(string linkToEntityName, string linkFromAttributeName,
        string linkToAttributeName)
    {
        LinkEntity linkEntity = new LinkEntity()
        {
            LinkToEntityName = linkToEntityName,
            LinkFromAttributeName = linkFromAttributeName,
            LinkToAttributeName = linkToAttributeName
        };
        this.LinkEntities.Add(linkEntity);
        return linkEntity;
    }
    public LinkEntity AddLink(string linkToEntityName, string linkFromAttributeName,
        string linkToAttributeName, JoinOperator joinOperator)
    {
        LinkEntity linkEntity = new LinkEntity()
        {
            LinkToEntityName = linkToEntityName,
            LinkFromAttributeName = linkFromAttributeName,
            LinkToAttributeName = linkToAttributeName,
            JoinOperator = joinOperator
        };
        this.LinkEntities.Add(linkEntity);
        return linkEntity;
    }
    internal string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(Util.ObjectToXml(ColumnSet, "a:ColumnSet", true));
        sb.Append(Util.ObjectToXml(Criteria, "a:Criteria", true));
        sb.Append(Util.ObjectToXml(Distinct, "a:Distinct", true));
        sb.Append(Util.ObjectToXml(EntityName, "a:EntityName", true));
        sb.Append(Util.ObjectToXml(LinkEntities.ToArray(), "a:LinkEntities", true));
        sb.Append(Util.ObjectToXml(Orders.ToArray(), "a:Orders", true));
        sb.Append(Util.ObjectToXml(PageInfo, "a:PageInfo", true));
        sb.Append(Util.ObjectToXml(NoLock, "a:NoLock", true));
        sb.Append(Util.ObjectToXml(TopCount, "a:TopCount", true));
        return sb.ToString();
    }
    static internal QueryExpression LoadFromXml(XElement item)
    {
        QueryExpression queryExpression = new QueryExpression()
        {
            ColumnSet = ColumnSet.LoadFromXml(item.Element(Util.ns.a + "ColumnSet")),
            Criteria = FilterExpression.LoadFromXml(item.Element(Util.ns.a + "Criteria")),
            Distinct = Util.LoadFromXml<bool>(item.Element(Util.ns.a + "Distinct")),
            EntityName = Util.LoadFromXml<string>(item.Element(Util.ns.a + "EntityName")),
            PageInfo = PagingInfo.LoadFromXml(item.Element(Util.ns.a + "PageInfo")),
            NoLock = Util.LoadFromXml<bool>(item.Element(Util.ns.a + "NoLock"))
        };
        foreach (XElement linkEntity in item.Element(Util.ns.a + "LinkEntities").Elements(Util.ns.a + "LinkEntity"))
        {
            queryExpression.LinkEntities.Add(LinkEntity.LoadFromXml(linkEntity));
        }
        foreach (XElement order in item.Element(Util.ns.a + "Orders").Elements(Util.ns.a + "OrderExpression"))
        {
            queryExpression.Orders.Add(OrderExpression.LoadFromXml(order));
        }
        if (item.Element(Util.ns.a + "TopCount") != null)
            queryExpression.TopCount = Util.LoadFromXml<int>(item.Element(Util.ns.a + "TopCount"));
        return queryExpression;
    }
}