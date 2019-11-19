using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Common_C_Sharp_Utility_Methods
{
    public static class Strings
    {
        public static bool HasValue(this string val) => !string.IsNullOrEmpty(val) && !string.IsNullOrWhiteSpace(val);

        public static bool IsEmpty(this string val) => !HasValue(val);

        public static byte[] ToBytes(this string value, Encoding encoding = null)
        {
            if (value.HasValue())
            {
                return (encoding ?? Encoding.UTF8)?.GetBytes(value) ?? new byte[] { };
            }

            return new byte[] { };
        }

        public static string Join(this string separator, params string[] value)
        {
            return string.Join(separator, value);
        }

        public static string Join(this IEnumerable<string> value, string separator)
        {
            return string.Join(separator, value);
        }

        /// <summary>
        /// https://gingter.org/2018/07/10/how-to-correctly-normalize-strings-and-how-to-compare-them-in-net/
        /// https://docs.microsoft.com/en-us/dotnet/standard/base-types/best-practices-strings#recommendations-for-string-usage
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string CustomNormalize(this string value)
        {
            if (value.IsEmpty()) return null;

            return value.Trim().Normalize().ToUpperInvariant().RemoveDiacritics();
        }

        /// <summary>
        /// https://stackoverflow.com/a/249126/3563013
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string RemoveDiacritics(this string value)
        {
            string normalizedString = value.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalizedString)
            {
                UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}