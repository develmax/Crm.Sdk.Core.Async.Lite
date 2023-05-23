namespace Microsoft.Crm.Sdk.OData;

public static class UserQueryQueryType
{
    public const int MainApplicationView = 0;
    public const int AdvancedSearch = 1;
    public const int SubGrid = 2;
    public const int QuickFindSearch = 4;
    public const int Reporting = 8;
    public const int OfflineFilters = 16;
    public const int LookupView = 64;
    public const int SMAppointmentBookView = 128;
    public const int OutlookFilters = 256;
    public const int AddressBookFilters = 512;
    public const int MainApplicationViewWithoutSubject = 1024;
    public const int SavedQueryTypeOther = 2048;
    public const int InteractiveWorkflowView = 4096;
    public const int CustomDefinedView = 16384;
}