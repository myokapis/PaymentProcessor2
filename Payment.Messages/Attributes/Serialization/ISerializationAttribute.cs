namespace Payment.Messages.Attributes.Serialization
{
    /// <summary>
    /// Describes properties to control serialization.
    /// </summary>
    public interface ISerializationAttribute
    {
        /// <summary>
        /// Forces a field terminator to be written even when no data is present in the field.
        /// </summary>
        bool AlwaysTerminate { get; init; }

        /// <summary>
        /// Indicates if the field contains sensitive data that should be masked.
        /// </summary>
        bool Masked { get; init; }

        /// <summary>
        /// Gets or sets the character to be used when masking field data.
        /// </summary>
        char MaskChar { get; init; }

        /// <summary>
        /// Gets or sets the character to be written when terminating a field.
        /// </summary>
        string? Terminator { get; init; }
    }
}
