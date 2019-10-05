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
    }
}