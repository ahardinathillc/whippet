using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Type;
using NodaTime;

namespace Athi.Whippet.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="DateTime"/> objects. This class cannot be inherited.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="DateTime"/> object to an <see cref="Instant"/> object.
        /// </summary>
        /// <param name="dateTime"><see cref="DateTime"/> object.</param>
        /// <returns><see cref="Instant"/> object.</returns>
        public static Instant ToInstant(this DateTime dateTime)
        {
            if(dateTime.Kind == DateTimeKind.Local || dateTime.Kind == DateTimeKind.Unspecified)
            {
                dateTime = dateTime.ToUniversalTime();
            }

            return Instant.FromDateTimeUtc(dateTime);
        }

        /// <summary>
        /// Converts the specified nullable <see cref="DateTime>"/> object to a nullable <see cref="Instant"/> object.
        /// </summary>
        /// <param name="dateTime">Nullable <see cref="DateTime"/> object.</param>
        /// <returns>Nullable <see cref="Instant"/> object.</returns>
        public static Instant? ToInstant(this DateTime? dateTime)
        {
            Instant? value = null;

            if (dateTime.HasValue)
            {
                value = dateTime.Value.ToInstant();
            }

            return value;
        }

        /// <summary>
        /// Gets an <see cref="Instant"/> value that is a previous date/time based on the specified value(s).
        /// </summary>
        /// <param name="dateTime"><see cref="DateTime"/> object.</param>
        /// <param name="years">Number of years to look back.</param>
        /// <param name="months">Number of months to look back.</param>
        /// <param name="days">Number of days to look back.</param>
        /// <param name="hours">Number of hours to look back.</param>
        /// <param name="minutes">Number of minutes to look back.</param>
        /// <param name="seconds">Number of seconds to look back.</param>
        /// <returns><see cref="Instant"/> object.</returns>
        public static Instant Lookback(this DateTime dateTime, int years = 0, int months = 0, double days = 0, double hours = 0, double minutes = 0, double seconds = 0)
        {
            if (years > 0)
            {
                years = years * -1;
            }

            if (months > 0)
            {
                months = months * -1;
            }

            if (days > 0.00)
            {
                days = days * -1.0;
            }

            if (hours > 0.00)
            {
                hours = hours * -1.0;
            }

            if (minutes > 0.00)
            {
                minutes = minutes * -1.0;
            }

            if (seconds > 0.00)
            {
                seconds = seconds * -1.0;
            }

            dateTime = dateTime.AddYears(years);
            dateTime = dateTime.AddMonths(months);
            dateTime = dateTime.AddDays(days);
            dateTime = dateTime.AddHours(hours);
            dateTime = dateTime.AddMinutes(minutes);
            dateTime = dateTime.AddSeconds(seconds);

            return ToInstant(dateTime);
        }

        /// <summary>
        /// Gets an <see cref="Instant"/> value that is set to the first day of the previous month at midnight on the first day.
        /// </summary>
        /// <param name="dateTime"><see cref="DateTime"/> object.</param>
        /// <returns><see cref="Instant"/> object.</returns>
        public static Instant LookbackToStartOfLastMonth(this DateTime dateTime)
        {
            DateTime dt = dateTime.Lookback(months: 1).ToDateTimeUtc();
            dt = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, DateTimeKind.Utc);

            return ToInstant(dt);
        }

        /// <summary>
        /// Gets an <see cref="Instant"/> value that is set to the first day of the current month at midnight on the first day.
        /// </summary>
        /// <param name="dateTime"><see cref="DateTime"/> object.</param>
        /// <returns><see cref="Instant"/> object.</returns>
        public static Instant LookbackToStartOfMonth(this DateTime dateTime)
        {
            DateTime now = DateTime.UtcNow;
            return ToInstant(new DateTime(now.Year, now.Month, 1, 0, 0, 0, DateTimeKind.Utc));
        }

        /// <summary>
        /// Converts the given <see cref="DateTime"/> value to a timestamp value with date.
        /// </summary>
        /// <param name="dateTime"><see cref="DateTime"/> value.</param>
        /// <returns><see cref="DateTime"/> value as a timestamp.</returns>
        public static string ToTimestamp(this DateTime dateTime)
        {
            return dateTime.ToShortDateString() + " " + dateTime.ToShortTimeString();
        }

        /// <summary>
        /// Converts the given nullable <see cref="DateTime"/> value to a timestamp value with date.
        /// </summary>
        /// <param name="dateTime">Nullable <see cref="DateTime"/> value.</param>
        /// <returns><see cref="DateTime"/> value as a timestamp.</returns>
        public static string ToTimestamp(this DateTime? dateTime)
        {
            return dateTime.HasValue ? dateTime.Value.ToTimestamp() : String.Empty;
        }

        /// <summary>
        /// Converts the given <see cref="Instant"/> value to a timestamp value with date.
        /// </summary>
        /// <param name="instant"><see cref="Instant"/> value.</param>
        /// <returns><see cref="Instant"/> value as a timestamp.</returns>
        public static string ToTimestamp(this Instant instant)
        {
            return instant.ToDateTimeUtc().ToTimestamp();
        }

        /// <summary>
        /// Converts the given nullable <see cref="Instant"/> value to a timestamp value with date.
        /// </summary>
        /// <param name="instant">Nullable <see cref="Instant"/> value.</param>
        /// <returns><see cref="Instant"/> value as a timestamp.</returns>
        public static string ToTimestamp(this Instant? instant)
        {
            return instant.HasValue ? instant.Value.ToTimestamp() : String.Empty;
        }

        /// <summary>
        /// Converts the value of the current <see cref="DateTime"/> object to Coordinated Universal Time (UTC).
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime"/> object to convert.</param>
        /// <param name="preserveValue">If <see langword="true"/>, the original value of the <see cref="DateTime"/> object will be preserved and the <see cref="DateTime.Kind"/> will be set to <see cref="DateTimeKind.Utc"/>.</param>
        /// <returns>An object whose <see cref="DateTime.Kind"/> property is <see cref="DateTimeKind.Utc"/>, and whose value is the UTC equivalent to the value of the current <see cref="DateTime"/> object, or <see cref="DateTime.MaxValue"/> if the converted value is too large to be represented by a <see cref="DateTime"/> object, or <see cref="DateTime.MinValue"/> if the converted value is too small to be represented by a <see cref="DateTime"/> object.</returns>
        public static DateTime ToUniversalTime(this DateTime dateTime, bool preserveValue)
        {
            DateTime utcTime;

            if (preserveValue)
            {
                utcTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond, dateTime.Microsecond, new GregorianCalendar(GregorianCalendarTypes.Localized), DateTimeKind.Utc);
            }
            else
            {
                utcTime = dateTime.ToUniversalTime();
            }

            return utcTime;
        }
    }
}
