using System.Globalization;
using Moq;
using Payment.Messages.Attributes.Format;
using Payment.Messages.Serializers.Formatters;

namespace Tests.Payment.Messages.Helpers
{
    public class TestHelpers
    {
        public static Mock<IFormatter> MockFormatter(string? stringDefault = null)
        {
            var mock = new Mock<IFormatter>();
            mock.Setup(m => m.FormatValue(It.IsAny<object>(), It.IsAny<IFormatAttribute?>()))
                .Returns<object, IFormatAttribute?>((value, formatAttribute) => FormatFunction(value, stringDefault));

            return mock;
        }

        public static string FormatFunction(object value, string? stringDefault = null)
        {
            if (value.GetType() == typeof(string))
                return stringDefault ?? value?.ToString() ?? "";

            if (value.GetType() == typeof(DateTime))
                return ((DateTime)value).ToString("s", CultureInfo.InvariantCulture);

            return value.ToString() ?? "";
        }
    }
}
