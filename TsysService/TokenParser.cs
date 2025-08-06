using System.Text.RegularExpressions;

namespace TsysService
{
    public static partial class TokenParser
    {
        [GeneratedRegex(@"^ch_[0-9A-F]{8}-(?:[0-9A-F]{4}-){3}[0-9A-F]{12}$", RegexOptions.IgnoreCase)]
        private static partial Regex TokenRegex();

        public static string? ParseToken(string message)
        {
            var match = TokenRegex().Match(message);

            return match.Success ? match.Value : null;
        }
    }
}
