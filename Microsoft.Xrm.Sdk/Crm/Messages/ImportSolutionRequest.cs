using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class ImportSolutionRequest : OrganizationRequest
{
    public bool ConvertToManaged
    {
        get
        {
            if (Parameters.Contains("ConvertToManaged"))
                return (bool)Parameters["ConvertToManaged"];
            return default(bool);
        }
        set { Parameters["ConvertToManaged"] = value; }
    }
    public byte[] CustomizationFile
    {
        get
        {
            if (Parameters.Contains("CustomizationFile"))
                return (byte[])Parameters["CustomizationFile"];
            return default(byte[]);
        }
        set { Parameters["CustomizationFile"] = value; }
    }
    public Guid ImportJobId
    {
        get
        {
            if (Parameters.Contains("ImportJobId"))
                return (Guid)Parameters["ImportJobId"];
            return default(Guid);
        }
        set { Parameters["ImportJobId"] = value; }
    }
    public bool OverwriteUnmanagedCustomizations
    {
        get
        {
            if (Parameters.Contains("OverwriteUnmanagedCustomizations"))
                return (bool)Parameters["OverwriteUnmanagedCustomizations"];
            return default(bool);
        }
        set { Parameters["OverwriteUnmanagedCustomizations"] = value; }
    }
    public bool PublishWorkflows
    {
        get
        {
            if (Parameters.Contains("PublishWorkflows"))
                return (bool)Parameters["PublishWorkflows"];
            return default(bool);
        }
        set { Parameters["PublishWorkflows"] = value; }
    }
    public bool SkipProductUpdateDependencies
    {
        get
        {
            if (Parameters.Contains("SkipProductUpdateDependencies"))
                return (bool)Parameters["SkipProductUpdateDependencies"];
            return default(bool);
        }
        set { Parameters["SkipProductUpdateDependencies"] = value; }
    }
    public ImportSolutionRequest()
    {
        this.ResponseType = new ImportSolutionResponse();
        this.RequestName = "ImportSolution";
    }
    internal override string GetRequestBody()
    {
        Parameters["ConvertToManaged"] = ConvertToManaged;
        Parameters["CustomizationFile"] = CustomizationFile;
        Parameters["ImportJobId"] = ImportJobId;
        Parameters["OverwriteUnmanagedCustomizations"] = OverwriteUnmanagedCustomizations;
        Parameters["PublishWorkflows"] = PublishWorkflows;
        Parameters["SkipProductUpdateDependencies"] = SkipProductUpdateDependencies;
        return GetSoapBody();
    }
}