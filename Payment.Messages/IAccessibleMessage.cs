using System.Text.Json.Serialization;

namespace Payment.Messages
{
    /// <summary>
    /// Describes properties on a class.
    /// </summary>
    public interface IAccessibleMessage
    {
        /// <summary>
        /// The number of public properties described. 
        /// </summary>
        [JsonIgnore]
        int FieldCount { get; }

        /// <summary>
        /// Metadata about each of the described properties.
        /// </summary>
        [JsonIgnore]
        IEnumerable<FieldDefinition> FieldDefinitions { get; }
    }

    /// <summary>
    /// Describes properties on a class.
    /// </summary>
    /// <typeparam name="T">The type of the class for which properties are described.</typeparam>
    public interface IAccessibleMessage<T> : IAccessibleMessage
    {
    }
}
