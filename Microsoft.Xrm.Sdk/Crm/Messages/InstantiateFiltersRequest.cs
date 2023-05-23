using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class InstantiateFiltersRequest : OrganizationRequest
{
    public EntityReferenceCollection TemplateCollection
    {
        get
        {
            if (Parameters.Contains("TemplateCollection"))
                return (EntityReferenceCollection)Parameters["TemplateCollection"];
            return default(EntityReferenceCollection);
        }
        set { Parameters["TemplateCollection"] = value; }
    }
    public Guid UserId
    {
        get
        {
            if (Parameters.Contains("UserId"))
                return (Guid)Parameters["UserId"];
            return default(Guid);
        }
        set { Parameters["UserId"] = value; }
    }
    public InstantiateFiltersRequest()
    {
        this.ResponseType = new InstantiateFiltersResponse();
        this.RequestName = "InstantiateFilters";
    }
    internal override string GetRequestBody()
    {
        Parameters["TemplateCollection"] = TemplateCollection;
        Parameters["UserId"] = UserId;
        return GetSoapBody();
    }
}