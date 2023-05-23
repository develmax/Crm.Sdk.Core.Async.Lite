using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveFilteredFormsRequest : OrganizationRequest
{
    public string EntityLogicalName
    {
        get
        {
            if (Parameters.Contains("EntityLogicalName"))
                return (string)Parameters["EntityLogicalName"];
            return default(string);
        }
        set { Parameters["EntityLogicalName"] = value; }
    }
    public OptionSetValue FormType
    {
        get
        {
            if (Parameters.Contains("FormType"))
                return (OptionSetValue)Parameters["FormType"];
            return default(OptionSetValue);
        }
        set { Parameters["FormType"] = value; }
    }
    public Guid SystemUserId
    {
        get
        {
            if (Parameters.Contains("SystemUserId"))
                return (Guid)Parameters["SystemUserId"];
            return default(Guid);
        }
        set { Parameters["SystemUserId"] = value; }
    }
    public RetrieveFilteredFormsRequest()
    {
        this.ResponseType = new RetrieveFilteredFormsResponse();
        this.RequestName = "RetrieveFilteredForms";
    }
    internal override string GetRequestBody()
    {
        Parameters["EntityLogicalName"] = EntityLogicalName;
        Parameters["FormType"] = FormType;
        Parameters["SystemUserId"] = SystemUserId;
        return GetSoapBody();
    }
}