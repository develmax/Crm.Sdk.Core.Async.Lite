using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RenewContractRequest : OrganizationRequest
{
    public Guid ContractId
    {
        get
        {
            if (Parameters.Contains("ContractId"))
                return (Guid)Parameters["ContractId"];
            return default(Guid);
        }
        set { Parameters["ContractId"] = value; }
    }
    public bool IncludeCanceledLines
    {
        get
        {
            if (Parameters.Contains("IncludeCanceledLines"))
                return (bool)Parameters["IncludeCanceledLines"];
            return default(bool);
        }
        set { Parameters["IncludeCanceledLines"] = value; }
    }
    public int Status
    {
        get
        {
            if (Parameters.Contains("Status"))
                return (int)Parameters["Status"];
            return default(int);
        }
        set { Parameters["Status"] = value; }
    }
    public RenewContractRequest()
    {
        this.ResponseType = new RenewContractResponse();
        this.RequestName = "RenewContract";
    }
    internal override string GetRequestBody()
    {
        Parameters["ContractId"] = ContractId;
        Parameters["IncludeCanceledLines"] = IncludeCanceledLines;
        Parameters["Status"] = Status;
        return GetSoapBody();
    }
}