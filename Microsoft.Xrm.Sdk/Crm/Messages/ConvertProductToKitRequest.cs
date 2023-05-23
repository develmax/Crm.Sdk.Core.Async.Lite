using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class ConvertProductToKitRequest : OrganizationRequest
{
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
    public ConvertProductToKitRequest()
    {
        this.ResponseType = new ConvertProductToKitResponse();
        this.RequestName = "ConvertProductToKit";
    }
    internal override string GetRequestBody()
    {
        Parameters["ProductId"] = ProductId;
        return GetSoapBody();
    }
}