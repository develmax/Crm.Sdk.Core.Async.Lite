using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class PublishDuplicateRuleRequest : OrganizationRequest
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
    public PublishDuplicateRuleRequest()
    {
        this.ResponseType = new PublishDuplicateRuleResponse();
        this.RequestName = "PublishDuplicateRule";
    }
    internal override string GetRequestBody()
    {
        Parameters["DuplicateRuleId"] = DuplicateRuleId;
        return GetSoapBody();
    }
}