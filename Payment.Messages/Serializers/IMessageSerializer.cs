using System.Text;

namespace Payment.Messages.Serializers
{
    /// <summary>
    /// Describes the basic functionality of a message serializer.
    /// </summary>
    public interface IMessageSerializer
    {
        /// <summary>
        /// Serializes an accessible message to a string.
        /// </summary>
        /// <param name="message">The message to be serialized.</param>
        /// <param name="isMasked">Turns masking of sensitive data on and off.</param>
        /// <returns>A string representing the original message.</returns>
        string SerializeMessage(IAccessibleMessage? message, bool isMasked = false);

        /// <summary>
        /// Serializes an accessible message to a string.
        /// </summary>
        /// <param name="message">The message to be serialized.</param>
        /// <param name="builder">A string builder into which the serialized message is written.</param>
        /// <param name="isMasked">Turns masking of sensitive data on and off.</param>
        void SerializeMessage(IAccessibleMessage? message, StringBuilder builder, bool isMasked = false);
    }
}
