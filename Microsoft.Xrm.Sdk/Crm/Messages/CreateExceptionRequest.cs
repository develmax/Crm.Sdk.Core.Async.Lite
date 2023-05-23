using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class CreateExceptionRequest : OrganizationRequest
{
    public bool IsDeleted
    {
        get
        {
            if (Parameters.Contains("IsDeleted"))
                return (bool)Parameters["IsDeleted"];
            return default(bool);
        }
        set { Parameters["IsDeleted"] = value; }
    }
    public DateTime OriginalStartDate
    {
        get
        {
            if (Parameters.Contains("OriginalStartDate"))
                return (DateTime)Parameters["OriginalStartDate"];
            return default(DateTime);
        }
        set { Parameters["OriginalStartDate"] = value; }
    }
    public Entity Target
    {
        get
        {
            if (Parameters.Contains("Target"))
                return (Entity)Parameters["Target"];
            return default(Entity);
        }
        set { Parameters["Target"] = value; }
    }
    public CreateExceptionRequest()
    {
        this.ResponseType = new CreateExceptionResponse();
        this.RequestName = "CreateException";
    }
    internal override string GetRequestBody()
    {
        Parameters["IsDeleted"] = IsDeleted;
        Parameters["OriginalStartDate"] = OriginalStartDate;
        Parameters["Target"] = Target;
        return GetSoapBody();
    }
}