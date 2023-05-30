using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class TransformImportRequest : OrganizationRequest
{
    public Guid ImportId
    {
        get
        {
            if (Parameters.Contains("ImportId"))
                return (Guid)Parameters["ImportId"];
            return default(Guid);
        }
        set { Parameters["ImportId"] = value; }
    }
    public TransformImportRequest()
    {
        this.ResponseType = new TransformImportResponse();
        this.RequestName = "TransformImport";
    }
    internal override string GetRequestBody()
    {
        Parameters["ImportId"] = ImportId;
        return GetSoapBody();
    }
}