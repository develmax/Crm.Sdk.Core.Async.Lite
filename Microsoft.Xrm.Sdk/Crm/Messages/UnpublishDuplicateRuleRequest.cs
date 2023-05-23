using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class UnpublishDuplicateRuleRequest : OrganizationRequest
{
    public Guid DuplicateRuleId
    {
        get
        {
            if (Parameters.Contains("DuplicateRuleId"))
                return (Guid)Parameters["DuplicateRuleId"];
            return default(Guid);
        }
        set { Parameters["DuplicateRuleId"] = value; }
    }
    public UnpublishDuplicateRuleRequest()
    {
        this.ResponseType = new UnpublishDuplicateRuleResponse();
        this.RequestName = "UnpublishDuplicateRule";
    }
    internal override string GetRequestBody()
    {
        Parameters["DuplicateRuleId"] = DuplicateRuleId;
        return GetSoapBody();
    }
}