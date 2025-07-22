namespace Payment.Messages.Attributes.Serialization
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class SerializationAttribute : Attribute, ISerializationAttribute
    {
        public SerializationAttribute()
        {
        }

        public bool AlwaysTerminate { get; init; } = true;
        public bool Masked { get; init; } = false;
        public char MaskChar { get; init; } = '*';
        public string? Terminator { get; init; }
    }
}
