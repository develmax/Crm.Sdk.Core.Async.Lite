using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Query;

public sealed class LinkEntity
{
    public ColumnSet Columns { get; set; }
    public string EntityAlias { get; set; }
    public JoinOperator JoinOperator { get; set; }
    public FilterExpression LinkCriteria { get; set; }
    public DataCollection<LinkEntity> LinkEntities { get; set; }
    public string LinkFromAttributeName { get; set; }
    public string LinkFromEntityName { get; set; }
    public string LinkToAttributeName { get; set; }
    public string LinkToEntityName { get; set; }
    public LinkEntity()
    {
        Columns = new ColumnSet();
        LinkCriteria = new FilterExpression();
        LinkEntities = new DataCollection<LinkEntity>();
    }
    internal string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(Util.ObjectToXml(Columns, "a:Columns", true));
        sb.Append(Util.ObjectToXml(EntityAlias, "a:EntityAlias", true));
        sb.Append(Util.ObjectToXml(JoinOperator, "a:JoinOperator", true));
        sb.Append(Util.ObjectToXml(LinkCriteria, "a:LinkCriteria", true));
        sb.Append(Util.ObjectToXml(LinkEntities.ToArray(), "a:LinkEntities", true));
        sb.Append(Util.ObjectToXml(LinkFromAttributeName, "a:LinkFromAttributeName", true));
        sb.Append(Util.ObjectToXml(LinkFromEntityName, "a:LinkFromEntityName", true));
        sb.Append(Util.ObjectToXml(LinkToAttributeName, "a:LinkToAttributeName", true));
        sb.Append(Util.ObjectToXml(LinkToEntityName, "a:LinkToEntityName", true));
        return sb.ToString();
    }
    static internal LinkEntity LoadFromXml(XElement item)
    {
        LinkEntity linkEntity = new LinkEntity()
        {
            Columns = ColumnSet.LoadFromXml(item.Element(Util.ns.a + "Columns")),
            EntityAlias = Util.LoadFromXml<string>(item.Element(Util.ns.a + "EntityAlias")),
            JoinOperator = Util.LoadFromXml<JoinOperator>(item.Element(Util.ns.a + "JoinOperator")),
            LinkCriteria = FilterExpression.LoadFromXml(item.Element(Util.ns.a + "LinkCriteria")),
            LinkFromAttributeName = Util.LoadFromXml<string>(item.Element(Util.ns.a + "LinkFromAttributeName")),
            LinkFromEntityName = Util.LoadFromXml<string>(item.Element(Util.ns.a + "LinkFromEntityName")),
            LinkToAttributeName = Util.LoadFromXml<string>(item.Element(Util.ns.a + "LinkToAttributeName")),
            LinkToEntityName = Util.LoadFromXml<string>(item.Element(Util.ns.a + "LinkToEntityName")),
        };
        foreach (XElement childLinkEntity in item.Element(Util.ns.a + "LinkEntities").Elements(Util.ns.a + "LinkEntity"))
        {
            linkEntity.LinkEntities.Add(LinkEntity.LoadFromXml(childLinkEntity));
        }
        return linkEntity;
    }
}