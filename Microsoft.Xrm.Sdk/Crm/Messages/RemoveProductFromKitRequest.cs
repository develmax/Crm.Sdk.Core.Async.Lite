using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class RemoveProductFromKitRequest : OrganizationRequest
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
    public RemoveProductFromKitRequest()
    {
        this.ResponseType = new RemoveProductFromKitResponse();
        this.RequestName = "RemoveProductFromKit";
    }
    internal override string GetRequestBody()
    {
        Parameters["KitId"] = KitId;
        Parameters["ProductId"] = ProductId;
        return GetSoapBody();
    }
}