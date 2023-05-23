using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class ParseImportRequest : OrganizationRequest
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
    public ParseImportRequest()
    {
        this.ResponseType = new ParseImportResponse();
        this.RequestName = "ParseImport";
    }
    internal override string GetRequestBody()
    {
        Parameters["ImportId"] = ImportId;
        return GetSoapBody();
    }
}