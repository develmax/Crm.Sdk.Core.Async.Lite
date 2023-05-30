using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class CancelSalesOrderRequest : OrganizationRequest
{
    public Entity OrderClose
    {
        get
        {
            if (Parameters.Contains("OrderClose"))
                return (Entity)Parameters["OrderClose"];
            return default(Entity);
        }
        set { Parameters["OrderClose"] = value; }
    }
    public OptionSetValue Status
    {
        get
        {
            if (Parameters.Contains("Status"))
                return (OptionSetValue)Parameters["Status"];
            return default(OptionSetValue);
        }
        set { Parameters["Status"] = value; }
    }
    public CancelSalesOrderRequest()
    {
        this.ResponseType = new CancelSalesOrderResponse();
        this.RequestName = "CancelSalesOrder";
    }
    internal override string GetRequestBody()
    {
        Parameters["OrderClose"] = OrderClose;
        Parameters["Status"] = Status;
        return GetSoapBody();
    }
}