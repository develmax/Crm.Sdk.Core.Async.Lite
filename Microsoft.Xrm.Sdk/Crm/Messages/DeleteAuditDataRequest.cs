using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class DeleteAuditDataRequest : OrganizationRequest
{
    public DateTime EndDate
    {
        get
        {
            if (Parameters.Contains("EndDate"))
                return (DateTime)Parameters["EndDate"];
            return default(DateTime);
        }
        set { Parameters["EndDate"] = value; }
    }
    public DeleteAuditDataRequest()
    {
        this.ResponseType = new DeleteAuditDataResponse();
        this.RequestName = "DeleteAuditData";
    }
    internal override string GetRequestBody()
    {
        Parameters["EndDate"] = EndDate;
        return GetSoapBody();
    }
}