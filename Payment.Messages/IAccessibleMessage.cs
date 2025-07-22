using System.Text.Json.Serialization;

namespace Payment.Messages
{
    public interface IAccessibleMessage
    {
        [JsonIgnore]
        int FieldCount { get; }

        [JsonIgnore]
        IEnumerable<FieldDefinition> FieldDefinitions { get; }
    }

    public interface IAccessibleMessage<T> : IAccessibleMessage
    {
    }
}
