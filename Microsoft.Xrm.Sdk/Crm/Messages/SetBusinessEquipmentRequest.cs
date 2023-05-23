using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class SetBusinessEquipmentRequest : OrganizationRequest
{
    public Guid BusinessUnitId
    {
        get
        {
            if (Parameters.Contains("BusinessUnitId"))
                return (Guid)Parameters["BusinessUnitId"];
            return default(Guid);
        }
        set { Parameters["BusinessUnitId"] = value; }
    }
    public Guid EquipmentId
    {
        get
        {
            if (Parameters.Contains("EquipmentId"))
                return (Guid)Parameters["EquipmentId"];
            return default(Guid);
        }
        set { Parameters["EquipmentId"] = value; }
    }
    public SetBusinessEquipmentRequest()
    {
        this.ResponseType = new SetBusinessEquipmentResponse();
        this.RequestName = "SetBusinessEquipment";
    }
    internal override string GetRequestBody()
    {
        Parameters["BusinessUnitId"] = BusinessUnitId;
        Parameters["EquipmentId"] = EquipmentId;
        return GetSoapBody();
    }
}