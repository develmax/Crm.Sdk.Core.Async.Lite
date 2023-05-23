using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk.Query;

public sealed class OrderExpression
{
    public string AttributeName { get; set; }
    public OrderType OrderType { get; set; }
    public OrderExpression() { }
    public OrderExpression(string attributeName, OrderType orderType)
    {
        this.AttributeName = attributeName;
        this.OrderType = orderType;
    }
    internal string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(Util.ObjectToXml(AttributeName, "a:AttributeName", true));
        sb.Append(Util.ObjectToXml(OrderType, "a:OrderType", true));
        return sb.ToString();
    }
    static internal OrderExpression LoadFromXml(XElement item)
    {
        OrderExpression orderExpression = new OrderExpression()
        {
            AttributeName = Util.LoadFromXml<string>(item.Element(Util.ns.a + "AttributeName")),
            OrderType = Util.LoadFromXml<OrderType>(item.Element(Util.ns.a + "OrderType"))
        };
        return orderExpression;
    }
}