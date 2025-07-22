using System.Runtime.CompilerServices;

namespace Payment.Processor.Extensions
{
    public static class BoolExtensions
    {
        public static bool Parse(this bool defaultValue, string? value)
        {
            if (!bool.TryParse(value, out var result))
                return defaultValue;

            return result;
        }
    }
}
