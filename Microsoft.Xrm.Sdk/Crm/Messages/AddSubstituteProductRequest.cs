using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class AddSubstituteProductRequest : OrganizationRequest
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
    public AddSubstituteProductRequest()
    {
        this.ResponseType = new AddSubstituteProductResponse();
        this.RequestName = "AddSubstituteProduct";
    }
    internal override string GetRequestBody()
    {
        Parameters["ProductId"] = ProductId;
        Parameters["SubstituteId"] = SubstituteId;
        return GetSoapBody();
    }
}