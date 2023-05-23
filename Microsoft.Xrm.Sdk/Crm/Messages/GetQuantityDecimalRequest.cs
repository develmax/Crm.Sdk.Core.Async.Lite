using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class GetQuantityDecimalRequest : OrganizationRequest
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
    public EntityReference Target
    {
        get
        {
            if (Parameters.Contains("Target"))
                return (EntityReference)Parameters["Target"];
            return default(EntityReference);
        }
        set { Parameters["Target"] = value; }
    }
    public Guid UoMId
    {
        get
        {
            if (Parameters.Contains("UoMId"))
                return (Guid)Parameters["UoMId"];
            return default(Guid);
        }
        set { Parameters["UoMId"] = value; }
    }

    public GetQuantityDecimalRequest()
    {
        this.ResponseType = new GetQuantityDecimalResponse();
        this.RequestName = "GetQuantityDecimal";
    }
    internal override string GetRequestBody()
    {
        Parameters["ProductId"] = ProductId;
        Parameters["Target"] = Target;
        Parameters["UoMId"] = UoMId;
        return GetSoapBody();
    }
}