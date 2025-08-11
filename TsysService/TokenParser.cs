using System.Text.RegularExpressions;

namespace TsysService
{
    /// <summary>
    /// Partial class to support a generated token parser.
    /// </summary>
    public static partial class TokenParser
    {
        /// <summary>
        /// Generated token parser regex definition.
        /// </summary>
        /// <returns>A generated token parser regex.</returns>
        [GeneratedRegex(@"^ch_[0-9A-F]{8}-(?:[0-9A-F]{4}-){3}[0-9A-F]{12}$", RegexOptions.IgnoreCase)]
        private static partial Regex TokenRegex();

        /// <summary>
        /// Parses a token from a string.
        /// </summary>
        /// <param name="message">The string from which to parse the token.</param>
        /// <returns>A token or null if no match was found.</returns>
        public static string? ParseToken(string message)
        {
            var match = TokenRegex().Match(message);

            return match.Success ? match.Value : null;
        }
    }
}
