using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class MergeRequest : OrganizationRequest
{
    public bool PerformParentingChecks
    {
        get
        {
            if (Parameters.Contains("PerformParentingChecks"))
                return (bool)Parameters["PerformParentingChecks"];
            return default(bool);
        }
        set { Parameters["PerformParentingChecks"] = value; }
    }
    public Guid SubordinateId
    {
        get
        {
            if (Parameters.Contains("SubordinateId"))
                return (Guid)Parameters["SubordinateId"];
            return default(Guid);
        }
        set { Parameters["SubordinateId"] = value; }
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
    public Entity UpdateContent
    {
        get
        {
            if (Parameters.Contains("UpdateContent"))
                return (Entity)Parameters["UpdateContent"];
            return default(Entity);
        }
        set { Parameters["UpdateContent"] = value; }
    }
    public MergeRequest()
    {
        this.ResponseType = new MergeResponse();
        this.RequestName = "Merge";
    }
    internal override string GetRequestBody()
    {
        Parameters["PerformParentingChecks"] = PerformParentingChecks;
        Parameters["SubordinateId"] = SubordinateId;
        Parameters["Target"] = Target;
        Parameters["UpdateContent"] = UpdateContent;
        return GetSoapBody();
    }
}