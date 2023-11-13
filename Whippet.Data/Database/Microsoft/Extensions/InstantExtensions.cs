using System;
using NodaTime;

namespace Athi.Whippet.Data.Database.Microsoft.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="Instant"/> objects. This class cannot be inherited.
    /// </summary>
    public static class InstantExtensions
    {
        /// <summary>
        /// Converts an <see cref="Instant"/> UTC value to a SQL Server value.
        /// </summary>
        /// <param name="instant"><see cref="Instant"/> value to convert.</param>
        /// <returns>SQL Server UTC date value in yyyy-MM-dd format.</returns>
        public static string ToSqlServerUtcDate(this Instant instant)
        {
            return instant.ToDateTimeUtc().ToString("yyyy-MM-dd");
        }
    }
}
