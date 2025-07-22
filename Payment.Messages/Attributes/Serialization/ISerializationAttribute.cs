namespace Payment.Messages.Attributes.Serialization
{
    public interface ISerializationAttribute
    {
        bool AlwaysTerminate { get; init; }
        bool Masked { get; init; }
        char MaskChar { get; init; }
        string? Terminator { get; init; }
    }
}
