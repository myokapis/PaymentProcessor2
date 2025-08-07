namespace Payment.Messages.Attributes.Serialization
{
    /// <summary>
    /// Describes properties to control serialization.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class SerializationAttribute : Attribute, ISerializationAttribute
    {
        /// <summary>
        /// Constructs an instance of the serialization attribute.
        /// </summary>
        public SerializationAttribute()
        {
        }

        /// <summary>
        /// Forces a field terminator to be written even when no data is present in the field.
        /// </summary>
        public bool AlwaysTerminate { get; init; } = true;

        /// <summary>
        /// Indicates if the field contains sensitive data that should be masked.
        /// </summary>
        public bool Masked { get; init; } = false;

        /// <summary>
        /// Gets or sets the character to be used when masking field data.
        /// </summary>
        public char MaskChar { get; init; } = '*';

        /// <summary>
        /// Gets or sets the character to be written when terminating a field.
        /// </summary>
        public string? Terminator { get; init; }
    }
}
