namespace Microsoft.Xrm.Sdk.Metadata;

public sealed class StatusOptionMetadata : OptionMetadata
{
    public int? State { get; set; }
    public StatusOptionMetadata() { }
    public StatusOptionMetadata(int value, int? state)
    {
        this.Value = value;
        this.State = state;
    }
}