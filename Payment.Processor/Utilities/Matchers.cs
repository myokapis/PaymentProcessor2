using System.Text.RegularExpressions;

namespace Payment.Processor.Utilities
{
    public static partial class Matchers
    {
        [GeneratedRegex(@"^\d+\b")]
        public static partial Regex AddressMatcher();
    }
}
