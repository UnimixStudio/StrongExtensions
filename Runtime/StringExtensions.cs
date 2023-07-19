using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace StrongExtensions
{
    public static class StringExtensions
    {
        /// <summary>
        ///     Eg MY_INT_VALUE => MyIntValue
        /// </summary>
        public static string ToTitleCase(this string input)
        {
            var builder = new StringBuilder();

            for (var i = 0; i < input.Length; i++)
            {
                char current = input[i];

                if (current == '_' && i + 1 < input.Length)
                {
                    char next = input[i + 1];
                    
                    if (char.IsLower(next))
                        next = char.ToUpper(next, CultureInfo.InvariantCulture);

                    builder.Append(next);
                    
                    i++;
                }
                else
                {
                    builder.Append(current);
                }
            }

            return builder.ToString();
        }

        /// <summary>
        ///     Returns whether or not the specified string is contained with this string
        /// </summary>
        public static bool Contains(this string source, string toCheck, StringComparison comparisonType) =>
            source.IndexOf(toCheck, comparisonType) >= 0;

        /// <summary>
        ///     Ex: "thisIsCamelCase" -> "This Is Camel Case"
        /// </summary>
        public static string SplitPascalCase(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            var builder = new StringBuilder(input.Length);

            builder.Append(char.IsLetter(input[0]) ? char.ToUpper(input[0]) : input[0]);

            for (var i = 1; i < input.Length; i++)
            {
                char c = input[i];

                if (char.IsUpper(c) && !char.IsUpper(input[i - 1]))
                    builder.Append(' ');

                builder.Append(c);
            }

            return builder.ToString();
        }

        /// <summary>
        ///     Returns true if this string is null, empty, or contains only whitespace.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns><c>true</c> if this string is null, empty, or contains only whitespace; otherwise, <c>false</c>.</returns>
        public static bool IsNullOrWhitespace(this string value) =>
            string.IsNullOrEmpty(value) || value.All(char.IsWhiteSpace);

        public static string AsFormat(this string format, params object[] parameters) =>
            string.Format(format, parameters);

        public static bool IsUpper(this char c) => char.IsUpper(c);

        public static bool IsLower(this char c) => char.IsLower(c);

        public static bool IsUpper(this string value) => value.SingleOrDefault().IsUpper();

        public static bool IsLower(this string c) => c.SingleOrDefault().IsLower();

        public static string ToCapitalize(this string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }

        public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);

        public static string ReplaceByRegex(this string str, string pattern, string replacement) =>
            System.Text.RegularExpressions.Regex.Replace(str, pattern, replacement);

        public static string Regex(this string str, string pattern) =>
            System.Text.RegularExpressions.Regex.Match(str, pattern).Value;
    }
}