using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class ExportMappingsImportMapRequest : OrganizationRequest
{
    public bool ExportIds
    {
        get
        {
            if (Parameters.Contains("ExportIds"))
                return (bool)Parameters["ExportIds"];
            return default(bool);
        }
        set { Parameters["ExportIds"] = value; }
    }
    public Guid ImportMapId
    {
        get
        {
            if (Parameters.Contains("ImportMapId"))
                return (Guid)Parameters["ImportMapId"];
            return default(Guid);
        }
        set { Parameters["ImportMapId"] = value; }
    }
    public ExportMappingsImportMapRequest()
    {
        this.ResponseType = new ExportMappingsImportMapResponse();
        this.RequestName = "ExportMappingsImportMap";
    }
    internal override string GetRequestBody()
    {
        Parameters["ExportIds"] = ExportIds;
        Parameters["ImportMapId"] = ImportMapId;
        return GetSoapBody();
    }
}