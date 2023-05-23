using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RemoveSubstituteProductRequest : OrganizationRequest
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
    public Guid SubstituteId
    {
        get
        {
            if (Parameters.Contains("SubstituteId"))
                return (Guid)Parameters["SubstituteId"];
            return default(Guid);
        }
        set { Parameters["SubstituteId"] = value; }
    }
    public RemoveSubstituteProductRequest()
    {
        this.ResponseType = new RemoveSubstituteProductResponse();
        this.RequestName = "RemoveSubstituteProduct";
    }
    internal override string GetRequestBody()
    {
        Parameters["ProductId"] = ProductId;
        Parameters["SubstituteId"] = SubstituteId;
        return GetSoapBody();
    }
}