using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class InstantiateTemplateRequest : OrganizationRequest
{
    public Guid ObjectId
    {
        get
        {
            if (Parameters.Contains("ObjectId"))
                return (Guid)Parameters["ObjectId"];
            return default(Guid);
        }
        set { Parameters["ObjectId"] = value; }
    }
    public Guid TemplateId
    {
        get
        {
            if (Parameters.Contains("TemplateId"))
                return (Guid)Parameters["TemplateId"];
            return default(Guid);
        }
        set { Parameters["TemplateId"] = value; }
    }
    public string ObjectType
    {
        get
        {
            if (Parameters.Contains("ObjectType"))
                return (string)Parameters["ObjectType"];
            return default(string);
        }
        set { Parameters["ObjectType"] = value; }
    }
    public InstantiateTemplateRequest()
    {
        this.ResponseType = new InstantiateTemplateResponse();
        this.RequestName = "InstantiateTemplate";
    }
    internal override string GetRequestBody()
    {
        Parameters["ObjectId"] = ObjectId;
        Parameters["TemplateId"] = TemplateId;
        Parameters["ObjectType"] = ObjectType;
        return GetSoapBody();
    }
}