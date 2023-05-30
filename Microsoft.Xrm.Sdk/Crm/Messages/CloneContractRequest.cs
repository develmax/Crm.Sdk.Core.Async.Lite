using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class CloneContractRequest : OrganizationRequest
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
    public CloneContractRequest()
    {
        this.ResponseType = new CloneContractResponse();
        this.RequestName = "CloneContract";
    }
    internal override string GetRequestBody()
    {
        Parameters["ContractId"] = ContractId;
        Parameters["IncludeCanceledLines"] = IncludeCanceledLines;
        return GetSoapBody();
    }
}