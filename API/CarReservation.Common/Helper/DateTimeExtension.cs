using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Common.Helper
{
    public static class DateTimeExtension
    {
        public static string GetISOStandardDateTime(this DateTime? value)
        {
            if (value.HasValue)
            {
                return value.Value.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            }
            else
            {
                return string.Empty;
            }
        }

        public static string GetISOStandardDateTime(this DateTime value)
        {
            return value.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
        }

        public static DateTime ConvertToISOStandardDateTime(this DateTime obj, string value)
        {
            DateTime date = new DateTime();
            if (DateTime.TryParse(value, out date))
            {
                return date.ToUniversalTime();
            }
            return DateTime.MinValue;
        }

        public static DateTime? ConvertToISOStandardDateTime(this DateTime? obj, string value)
        {
            DateTime date = new DateTime();
            if (DateTime.TryParse(value, out date))
            {
                return date.ToUniversalTime();
            }
            return null;
        }

        public static string GetDateTimeStringFormat(this DateTime value)
        {
            return value.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }

        static IEnumerable<DateTime> AllDatesBetween(DateTime start, DateTime end)
        {
            for (var day = start.Date; day <= end; day = day.AddDays(1))
                yield return day;
        }
    }
}
