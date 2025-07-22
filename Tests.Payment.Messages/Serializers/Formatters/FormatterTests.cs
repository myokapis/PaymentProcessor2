using FluentAssertions;
using Payment.Messages.Attributes.Format;
using Payment.Messages.Serializers.Formatters;

namespace Tests.Payment.Messages.Serializers.Formatters
{
    public class FormatterTests
    {
        [Fact]
        public void FormatValue_Char()
        {
            var formatter = new Formatter();
            IFormatAttribute? formatAttribute = null;
            object value = 'a';
            var formattedValue = formatter.FormatValue(value, formatAttribute);
            formattedValue.Should().Be("a");
        }

        [Fact]
        public void FormatValue_CharEmpty()
        {
            var formatter = new Formatter();
            IFormatAttribute? formatAttribute = null;
            object value = default(char);
            var formattedValue = formatter.FormatValue(value, formatAttribute);
            formattedValue.Should().Be("");
        }

        [Fact]
        public void FormatValue_DateTime()
        {
            var formatter = new Formatter();
            IFormatAttribute? formatAttribute = new DateFormatAttribute() { FormatString = "u" };
            object value = DateTime.Parse("2025-02-14 16:55:33");
            var formattedValue = formatter.FormatValue(value, formatAttribute);
            formattedValue.Should().Be("2025-02-14 16:55:33Z");
        }

        [Fact]
        public void FormatValue_DateTimeDefault()
        {
            var formatter = new Formatter();
            object value = DateTime.Parse("2025-02-14 16:55:33");
            var formattedValue = formatter.FormatValue(value, null);
            formattedValue.Should().Be("2025-02-14T16:55:33");
        }

        [Fact]
        public void FormatValue_Decimal()
        {
            var formatter = new Formatter();
            IFormatAttribute? formatAttribute = new DecimalFormatAttribute() { FormatString = "g4" };
            object value = 12.334m;
            var formattedValue = formatter.FormatValue(value, formatAttribute);
            formattedValue.Should().Be("12.33");
        }

        [Fact]
        public void FormatValue_DecimalDefault()
        {
            var formatter = new Formatter();
            object value = 12.334m;
            var formattedValue = formatter.FormatValue(value, null);
            formattedValue.Should().Be("12.334");
        }

        [Fact]
        public void FormatValue_Integer()
        {
            var formatter = new Formatter();
            IFormatAttribute? formatAttribute = new IntegerFormatAttribute() { FormatString = "00000000" };
            object value = 12334;
            var formattedValue = formatter.FormatValue(value, formatAttribute);
            formattedValue.Should().Be("00012334");
        }

        [Fact]
        public void FormatValue_IntegerDefault()
        {
            var formatter = new Formatter();
            object value = 12334;
            var formattedValue = formatter.FormatValue(value, null);
            formattedValue.Should().Be("12334");
        }

        [Fact]
        public void FormatValue_Object()
        {
            var formatter = new Formatter();
            IFormatAttribute? formatAttribute = null;
            object value = new TestObject();
            var formattedValue = formatter.FormatValue(value, formatAttribute);
            formattedValue.Should().Be("TestObjects are quiet.");
        }

        [Fact]
        public void FormatValue_Object_NullString()
        {
            var formatter = new Formatter();
            IFormatAttribute? formatAttribute = null;
            object value = new TestObjectNullString();
            var formattedValue = formatter.FormatValue(value, formatAttribute);
            formattedValue.Should().Be("");
        }

        [Fact]
        public void FormatValue_String()
        {
            var formatter = new Formatter();
            IFormatAttribute? formatAttribute = new StringFormatAttribute()
            {
                FormatString = "Message: {0}"
            };

            object value = "AaBbCcDdEe";
            var formattedValue = formatter.FormatValue(value, formatAttribute);
            formattedValue.Should().Be("Message: AaBbCcDdEe");
        }

        [Fact]
        public void FormatValue_StringDefault()
        {
            var formatter = new Formatter();
            object value = "AaBbCcDdEe";
            var formattedValue = formatter.FormatValue(value, null);
            formattedValue.Should().Be("AaBbCcDdEe");
        }

        [Fact]
        public void FormatValue_UnsignedInteger()
        {
            var formatter = new Formatter();
            IFormatAttribute? formatAttribute = new IntegerFormatAttribute() { FormatString = "00000000" };
            object value = 12334U;
            var formattedValue = formatter.FormatValue(value, formatAttribute);
            formattedValue.Should().Be("00012334");
        }

        [Fact]
        public void FormatValue_UnsignedIntegerDefault()
        {
            var formatter = new Formatter();
            object value = 12334U;
            var formattedValue = formatter.FormatValue(value, null);
            formattedValue.Should().Be("12334");
        }

        [Fact]
        public void FormatValue_UnsignedLong()
        {
            var formatter = new Formatter();
            IFormatAttribute? formatAttribute = new IntegerFormatAttribute() { FormatString = "00000000" };
            object value = 12334UL;
            var formattedValue = formatter.FormatValue(value, formatAttribute);
            formattedValue.Should().Be("00012334");
        }

        [Fact]
        public void FormatValue_UnsignedLongDefault()
        {
            var formatter = new Formatter();
            object value = 12334UL;
            var formattedValue = formatter.FormatValue(value, null);
            formattedValue.Should().Be("12334");
        }

        private class TestObject
        {
            public override string? ToString()
            {
                return "TestObjects are quiet.";
            }
        }

        private class TestObjectNullString
        {
            public override string? ToString()
            {
                return null;
            }
        }
    }
}
