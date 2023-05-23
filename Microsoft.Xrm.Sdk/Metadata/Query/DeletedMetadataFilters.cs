namespace Microsoft.Xrm.Sdk.Metadata.Query;

public enum DeletedMetadataFilters
{
    Default = 1,
    Entity = 1,
    Attribute = 2,
    Relationship = 4,
    Label = 8,
    OptionSet = 16,
    All = 31,
}