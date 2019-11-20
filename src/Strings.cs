using System;
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

        /// <summary>
        /// https://rosettacode.org/wiki/Levenshtein_distance#C.23
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static int LevenshteinDistance(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            for (int i = 0; i <= n; i++)
                d[i, 0] = i;
            for (int j = 0; j <= m; j++)
                d[0, j] = j;

            for (int j = 1; j <= m; j++)
                for (int i = 1; i <= n; i++)
                    if (s[i - 1] == t[j - 1])
                        d[i, j] = d[i - 1, j - 1];  //no operation
                    else
                        d[i, j] = Math.Min(Math.Min(
                            d[i - 1, j] + 1,    //a deletion
                            d[i, j - 1] + 1),   //an insertion
                            d[i - 1, j - 1] + 1 //a substitution
                            );
            return d[n, m];
        }
    }
}