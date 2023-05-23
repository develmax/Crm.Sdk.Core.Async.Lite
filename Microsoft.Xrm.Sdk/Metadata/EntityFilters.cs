namespace Microsoft.Xrm.Sdk.Metadata;

public enum EntityFilters
{
    Default = 1,
    Entity = 1,
    Attributes = 2,
    Privileges = 4,
    Relationships = 8,
    All = 15
}