using System.Text;
using FluentAssertions;
using Payment.Messages.Attributes.Format;
using Payment.Messages.Attributes.Serialization;
using Payment.Messages.Enums;
using Payment.Messages.Serializers;
using Tests.Payment.Messages.Helpers;
//using StringFormatAttribute = Payment.Messages.Attributes.Format.StringFormatAttribute;

namespace Tests.Payment.Messages.Serializers
{
    public class MessageSerializerTests
    {
        [Fact]
        public void SerializeMessage()
        {
            var formatter = TestHelpers.MockFormatter();
            var serializer = new TestMessageSerializer(formatter.Object);
            var message = new TestParentMessage();

            Assert.Throws<NotImplementedException>(() => serializer.SerializeMessage(message));
        }

        [Fact]
        public void SerializeMessage_WithBuilder()
        {
            var formatter = TestHelpers.MockFormatter();
            var serializer = new TestMessageSerializer(formatter.Object);
            var message = new TestParentMessage();
            var builder = new StringBuilder();

            Assert.Throws<NotImplementedException>(() => serializer.SerializeMessage(message, builder));
        }

        #region test protected methods

        [Fact]
        public void FormatField_Masked()
        {
            var formatter = TestHelpers.MockFormatter();
            var serializer = new TestMessageSerializer(formatter.Object);

            var fieldContent = new FieldContent()
            {
                FieldName = "Field1",
                FormatAttribute = null,
                SerializationAttribute = null,
                Value = "Able was I ere I saw Elba"
            };

            var result = serializer.ExposeFormatField(fieldContent, true);
            result.Should().Be("Able was I ere I saw Elba");
        }

        [Fact]
        public void JustifyValue_Left()
        {
            var formatter = TestHelpers.MockFormatter();
            var serializer = new TestMessageSerializer(formatter.Object);
            var stringValue = "Able was I ere I saw Elba";

            var fieldContent = new FieldContent()
            {
                FieldName = "Field1",
                FormatAttribute = new StringFormatAttribute()
                {
                    Justify = Justify.Left,
                    PaddedLength = 30,
                    PaddingChar = '*'
                },
                SerializationAttribute = null,
                Value = stringValue
            };

            var result = serializer.ExposeJustifyValue(stringValue, fieldContent);
            result.Should().Be("Able was I ere I saw Elba*****");
        }

        [Fact]
        public void JustifyValue_None()
        {
            var formatter = TestHelpers.MockFormatter();
            var serializer = new TestMessageSerializer(formatter.Object);
            var stringValue = "Able was I ere I saw Elba";

            var fieldContent = new FieldContent()
            {
                FieldName = "Field1",
                FormatAttribute = new StringFormatAttribute()
                {
                    Justify = Justify.None,
                    PaddedLength = 30,
                    PaddingChar = '*'
                },
                SerializationAttribute = null,
                Value = stringValue
            };

            var result = serializer.ExposeJustifyValue(stringValue, fieldContent);
            result.Should().Be(stringValue);
        }

        [Fact]
        public void JustifyValue_None_ShortValue()
        {
            var formatter = TestHelpers.MockFormatter();
            var serializer = new TestMessageSerializer(formatter.Object);
            var stringValue = "Able was I ere I saw Elba";

            var fieldContent = new FieldContent()
            {
                FieldName = "Field1",
                FormatAttribute = new StringFormatAttribute()
                {
                    Justify = Justify.None,
                    MaxLength = 30,
                    PaddedLength = 30,
                    PaddingChar = '*'
                },
                SerializationAttribute = null,
                Value = stringValue
            };

            var result = serializer.ExposeJustifyValue(stringValue, fieldContent);
            result.Should().Be(stringValue);
        }

        [Fact]
        public void JustifyValue_None_Truncate()
        {
            var formatter = TestHelpers.MockFormatter();
            var serializer = new TestMessageSerializer(formatter.Object);
            var stringValue = "Able was I ere I saw Elba";

            var fieldContent = new FieldContent()
            {
                FieldName = "Field1",
                FormatAttribute = new StringFormatAttribute()
                {
                    Justify = Justify.None,
                    MaxLength = 10,
                    PaddedLength = 10,
                    PaddingChar = '*'
                },
                SerializationAttribute = null,
                Value = stringValue
            };

            var result = serializer.ExposeJustifyValue(stringValue, fieldContent);
            result.Should().Be("Able was I");
        }

        [Fact]
        public void JustifyValue_None_ZeroMaxLength()
        {
            var formatter = TestHelpers.MockFormatter();
            var serializer = new TestMessageSerializer(formatter.Object);
            var stringValue = "Able was I ere I saw Elba";

            var fieldContent = new FieldContent()
            {
                FieldName = "Field1",
                FormatAttribute = new StringFormatAttribute()
                {
                    Justify = Justify.None,
                    MaxLength = 0,
                    PaddedLength = 30,
                    PaddingChar = '*'
                },
                SerializationAttribute = null,
                Value = stringValue
            };

            var result = serializer.ExposeJustifyValue(stringValue, fieldContent);
            result.Should().Be(stringValue);
        }

        [Fact]
        public void JustifyValue_Right()
        {
            var formatter = TestHelpers.MockFormatter();
            var serializer = new TestMessageSerializer(formatter.Object);
            var stringValue = "Able was I ere I saw Elba";

            var fieldContent = new FieldContent()
            {
                FieldName = "Field1",
                FormatAttribute = new StringFormatAttribute()
                {
                    Justify = Justify.Right,
                    PaddedLength = 30,
                    PaddingChar = '*'
                },
                SerializationAttribute = null,
                Value = stringValue
            };

            var result = serializer.ExposeJustifyValue(stringValue, fieldContent);
            result.Should().Be("*****Able was I ere I saw Elba");
        }

        [Fact]
        public void JustifyValue_ZeroPaddedLength()
        {
            var formatter = TestHelpers.MockFormatter();
            var serializer = new TestMessageSerializer(formatter.Object);
            var stringValue = "Able was I ere I saw Elba";

            var fieldContent = new FieldContent()
            {
                FieldName = "Field1",
                FormatAttribute = new StringFormatAttribute()
                {
                    Justify = Justify.Left,
                    PaddedLength = 0,
                    PaddingChar = '*'
                },
                SerializationAttribute = null,
                Value = stringValue
            };

            var result = serializer.ExposeJustifyValue(stringValue, fieldContent);
            result.Should().Be(stringValue);
        }

        [Fact]
        public void MaskValue()
        {
            var formatter = TestHelpers.MockFormatter();
            var serializer = new TestMessageSerializer(formatter.Object);
            var stringValue = "Able was I ere I saw Elba";

            var fieldContent = new FieldContent()
            {
                FieldName = "Field1",
                FormatAttribute = null,
                SerializationAttribute = new SerializationAttribute()
                {
                     Masked = true,
                     MaskChar = '+'
                },
                Value = stringValue
            };

            var result = serializer.ExposeMaskValue(stringValue, fieldContent);
            result.Should().Be(new string('+', stringValue.Length));
        }

        #endregion
    }
}
