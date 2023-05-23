using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class CancelContractRequest : OrganizationRequest
{
    public DateTime CancelDate
    {
        get
        {
            if (Parameters.Contains("CancelDate"))
                return (DateTime)Parameters["CancelDate"];
            return default(DateTime);
        }
        set { Parameters["CancelDate"] = value; }
    }
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
    public CancelContractRequest()
    {
        this.ResponseType = new CancelContractResponse();
        this.RequestName = "CancelContract";
    }
    internal override string GetRequestBody()
    {
        Parameters["CancelDate"] = CancelDate;
        Parameters["ContractId"] = ContractId;
        Parameters["Status"] = Status;
        return GetSoapBody();
    }
}