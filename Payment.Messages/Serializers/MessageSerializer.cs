using System.Text;
using Payment.Messages.Attributes.Format;
using Payment.Messages.Serializers.Formatters;

namespace Payment.Messages.Serializers
{
    public abstract class MessageSerializer : IMessageSerializer
    {
        protected readonly IFormatter formatter;

        public MessageSerializer(IFormatter formatter)
        {
            this.formatter = formatter;
        }

        public virtual string SerializeMessage(IAccessibleMessage? message, bool isMasked = false)
        {
            throw new NotImplementedException();
        }

        public virtual void SerializeMessage(IAccessibleMessage? message, StringBuilder builder, bool isMasked = false)
        {
            throw new NotImplementedException();
        }

        #region protected methods

        /// <summary>
        /// Returns a FieldValue object for a given field in the field collection.
        /// </summary>
        /// <param name="field">The </param>
        /// <returns>A FieldValue object containing the field's data and relevant metadata.</returns>
        protected virtual FieldContent ExtractContent(IAccessibleMessage message, FieldDefinition field)
        {
            return new FieldContent()
            {
                FieldName = field.PropertyInfo.Name,
                FormatAttribute = field.FormatAttribute,
                SerializationAttribute = field.SerializationAttribute,
                Value = field.PropertyInfo.GetValue(message)
            };
        }

        protected virtual string FormatField(FieldContent fieldContent, bool isMasked)
        {
            var formattedValue = FormattedFieldValue(fieldContent);
            var workingValue = isMasked ? MaskValue(formattedValue, fieldContent) : formattedValue;
            return JustifyValue(workingValue, fieldContent);
        }

        protected virtual string FormattedFieldValue(FieldContent fieldContent)
        {
            var value = fieldContent.Value;
            if (value == null) return "";

            return formatter.FormatValue(value, fieldContent.FormatAttribute);
        }

        protected virtual string JustifyValue(string value, FieldContent fieldContent)
        {
            var format = fieldContent.FormatAttribute;
            if (format == null) return value;

            if (format.Justify == Enums.Justify.None || format.PaddedLength == 0)
            {
                if (format.MaxLength == 0 || value.Length <= format.MaxLength) return value;
                return value.Substring(0, format.MaxLength);
            }

            if (format.Justify == Enums.Justify.Left)
                return value.PadRight(format.PaddedLength, format.PaddingChar);

            return value.PadLeft(format.PaddedLength, format.PaddingChar);
        }

        protected virtual string MaskValue(string value, FieldContent fieldContent)
        {
            var format = fieldContent.SerializationAttribute;
            if (format == null) return value;

            return new string(format.MaskChar, value.Length);
        }

        #endregion
    }
}
