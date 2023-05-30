using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class ConvertSalesOrderToInvoiceRequest : OrganizationRequest
{
    public Guid SalesOrderId
    {
        get
        {
            if (Parameters.Contains("SalesOrderId"))
                return (Guid)Parameters["SalesOrderId"];
            return default(Guid);
        }
        set { Parameters["SalesOrderId"] = value; }
    }
    public ColumnSet ColumnSet
    {
        get
        {
            if (Parameters.Contains("ColumnSet"))
                return (ColumnSet)Parameters["ColumnSet"];
            return default(ColumnSet);
        }
        set { Parameters["ColumnSet"] = value; }
    }
    public ConvertSalesOrderToInvoiceRequest()
    {
        this.ResponseType = new ConvertSalesOrderToInvoiceResponse();
        this.RequestName = "ConvertSalesOrderToInvoice";
    }
    internal override string GetRequestBody()
    {
        Parameters["SalesOrderId"] = SalesOrderId;
        Parameters["ColumnSet"] = ColumnSet;
        return GetSoapBody();
    }
}