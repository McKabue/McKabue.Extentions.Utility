using System;

namespace Common_C_Sharp_Utility_Methods
{
    public static class TimeSpanExtensions
    {
        public static int GetYears(this TimeSpan timespan)
        {
            return (int)(timespan.Days / 365);
        }
        public static int GetMonths(this TimeSpan timespan)
        {
            return (int)(timespan.Days / 30);
        }
    }
}