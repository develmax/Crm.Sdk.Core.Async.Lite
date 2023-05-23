using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class ExportSolutionRequest : OrganizationRequest
{
    public bool ExportAutoNumberingSettings
    {
        get
        {
            if (Parameters.Contains("ExportAutoNumberingSettings"))
                return (bool)Parameters["ExportAutoNumberingSettings"];
            return default(bool);
        }
        set { Parameters["ExportAutoNumberingSettings"] = value; }
    }
    public bool ExportCalendarSettings
    {
        get
        {
            if (Parameters.Contains("ExportCalendarSettings"))
                return (bool)Parameters["ExportCalendarSettings"];
            return default(bool);
        }
        set { Parameters["ExportCalendarSettings"] = value; }
    }
    public bool ExportCustomizationSettings
    {
        get
        {
            if (Parameters.Contains("ExportCustomizationSettings"))
                return (bool)Parameters["ExportCustomizationSettings"];
            return default(bool);
        }
        set { Parameters["ExportCustomizationSettings"] = value; }
    }
    public bool ExportEmailTrackingSettings
    {
        get
        {
            if (Parameters.Contains("ExportEmailTrackingSettings"))
                return (bool)Parameters["ExportEmailTrackingSettings"];
            return default(bool);
        }
        set { Parameters["ExportEmailTrackingSettings"] = value; }
    }
    public bool ExportGeneralSettings
    {
        get
        {
            if (Parameters.Contains("ExportGeneralSettings"))
                return (bool)Parameters["ExportGeneralSettings"];
            return default(bool);
        }
        set { Parameters["ExportGeneralSettings"] = value; }
    }
    public bool ExportIsvConfig
    {
        get
        {
            if (Parameters.Contains("ExportIsvConfig"))
                return (bool)Parameters["ExportIsvConfig"];
            return default(bool);
        }
        set { Parameters["ExportIsvConfig"] = value; }
    }
    public bool ExportMarketingSettings
    {
        get
        {
            if (Parameters.Contains("ExportMarketingSettings"))
                return (bool)Parameters["ExportMarketingSettings"];
            return default(bool);
        }
        set { Parameters["ExportMarketingSettings"] = value; }
    }
    public bool ExportOutlookSynchronizationSettings
    {
        get
        {
            if (Parameters.Contains("ExportOutlookSynchronizationSettings"))
                return (bool)Parameters["ExportOutlookSynchronizationSettings"];
            return default(bool);
        }
        set { Parameters["ExportOutlookSynchronizationSettings"] = value; }
    }
    public bool ExportRelationshipRoles
    {
        get
        {
            if (Parameters.Contains("ExportRelationshipRoles"))
                return (bool)Parameters["ExportRelationshipRoles"];
            return default(bool);
        }
        set { Parameters["ExportRelationshipRoles"] = value; }
    }
    public bool Managed
    {
        get
        {
            if (Parameters.Contains("Managed"))
                return (bool)Parameters["Managed"];
            return default(bool);
        }
        set { Parameters["Managed"] = value; }
    }
    public string SolutionName
    {
        get
        {
            if (Parameters.Contains("SolutionName"))
                return (string)Parameters["SolutionName"];
            return default(string);
        }
        set { Parameters["SolutionName"] = value; }
    }
    public ExportSolutionRequest()
    {
        this.ResponseType = new ExportSolutionResponse();
        this.RequestName = "ExportSolution";
    }
    internal override string GetRequestBody()
    {
        Parameters["ExportAutoNumberingSettings"] = ExportAutoNumberingSettings;
        Parameters["ExportCalendarSettings"] = ExportCalendarSettings;
        Parameters["ExportCustomizationSettings"] = ExportCustomizationSettings;
        Parameters["ExportEmailTrackingSettings"] = ExportEmailTrackingSettings;
        Parameters["ExportGeneralSettings"] = ExportGeneralSettings;
        Parameters["ExportIsvConfig"] = ExportIsvConfig;
        Parameters["ExportMarketingSettings"] = ExportMarketingSettings;
        Parameters["ExportOutlookSynchronizationSettings"] = ExportOutlookSynchronizationSettings;
        Parameters["ExportRelationshipRoles"] = ExportRelationshipRoles;
        Parameters["Managed"] = Managed;
        Parameters["SolutionName"] = SolutionName;
        return GetSoapBody();
    }
}