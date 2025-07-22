using Payment.Messages.Serializers;
using Payment.Messages.Serializers.Formatters;

namespace Tests.Payment.Messages.Helpers
{
    public class TestMessageSerializer : MessageSerializer
    {
        public TestMessageSerializer(IFormatter formatter) : base(formatter)
        {
        }

        public string ExposeFormatField(FieldContent fieldContent, bool isMasked)
        {
            return FormatField(fieldContent, isMasked);
        }

        public string ExposeJustifyValue(string value, FieldContent fieldContent)
        {
            return JustifyValue(value, fieldContent);
        }

        public string ExposeMaskValue(string value, FieldContent fieldContent)
        {
            return MaskValue(value, fieldContent);
        }
    }
}
