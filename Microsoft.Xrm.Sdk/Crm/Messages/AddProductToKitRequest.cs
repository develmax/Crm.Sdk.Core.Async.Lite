using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class AddProductToKitRequest : OrganizationRequest
{
    public Guid KitId
    {
        get
        {
            if (Parameters.Contains("KitId"))
                return (Guid)Parameters["KitId"];
            return default(Guid);
        }
        set { Parameters["KitId"] = value; }
    }
    public Guid ProductId
    {
        get
        {
            if (Parameters.Contains("ProductId"))
                return (Guid)Parameters["ProductId"];
            return default(Guid);
        }
        set { Parameters["ProductId"] = value; }
    }
    public AddProductToKitRequest()
    {
        this.ResponseType = new AddProductToKitResponse();
        this.RequestName = "AddProductToKit";
    }
    internal override string GetRequestBody()
    {
        Parameters["KitId"] = KitId;
        Parameters["ProductId"] = ProductId;
        return GetSoapBody();
    }
}