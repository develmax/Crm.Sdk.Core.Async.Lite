namespace Microsoft.Crm.Sdk.OData.Messages;

public enum AccessRights
{
    None = 0,
    ReadAccess = 1,
    WriteAccess = 2,
    AppendAccess = 4,
    AppendToAccess = 8,
    CreateAccess = 16,
    DeleteAccess = 32,
    ShareAccess = 64,
    AssignAccess = 128,
    All = 255
}