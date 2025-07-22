using System.Text;

namespace Payment.Messages.Serializers
{
    public interface IMessageSerializer
    {
        string SerializeMessage(IAccessibleMessage? message, bool isMasked = false);
        void SerializeMessage(IAccessibleMessage? message, StringBuilder builder, bool isMasked = false);
    }
}
