using System;

namespace McKabue.Extentions.Utility
{
    public static class TimeSpanExtensions
    {
        public static int GetYears(this TimeSpan timespan)
        {
            return (int)(timespan / TimeSpan.FromDays(365));
        }
        public static int GetMonths(this TimeSpan timespan)
        {
            return (int)(timespan / TimeSpan.FromDays(30));
        }
    }
}