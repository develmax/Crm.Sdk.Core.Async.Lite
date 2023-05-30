using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class RetrieveSubsidiaryTeamsBusinessUnitRequest : OrganizationRequest
{
    public Guid EntityId
    {
        get
        {
            if (Parameters.Contains("EntityId"))
                return (Guid)Parameters["EntityId"];
            return default(Guid);
        }
        set { Parameters["EntityId"] = value; }
    }
    public ColumnSet ColumnSet
    {
        get
        {
            if (Parameters.Contains("ColumnSet"))
                return (ColumnSet)Parameters["ColumnSet"];
            return default(ColumnSet);
        }
        set { Parameters["ColumnSet"] = value; }
    }
    public RetrieveSubsidiaryTeamsBusinessUnitRequest()
    {
        this.ResponseType = new RetrieveSubsidiaryTeamsBusinessUnitResponse();
        this.RequestName = "RetrieveSubsidiaryTeamsBusinessUnit";
    }
    internal override string GetRequestBody()
    {
        Parameters["EntityId"] = EntityId;
        Parameters["ColumnSet"] = ColumnSet;
        return GetSoapBody();
    }
}