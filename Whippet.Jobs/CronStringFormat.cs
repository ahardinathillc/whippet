using System;

namespace Athi.Whippet.Jobs
{
    /// <summary>
    /// Specifies the cron format to use when parsing the expression.
    /// </summary>
    public enum CronStringFormat
    {
        /// <summary>
        /// Defined as "MINUTES HOURS DAYS MONTHS DAYS-OF-WEEK"
        /// </summary>
        Default,
        /// <summary>
        /// Defined as "MINUTES HOURS DAYS MONTHS DAYS-OF-WEEK YEARS"
        /// </summary>
        WithYears,
        /// <summary>
        /// Defined as "SECONDS MINUTES HOURS DAYS MONTHS DAYS-OF-WEEK"
        /// </summary>
        WithSeconds,
        /// <summary>
        /// Defined as "SECONDS MINUTES HOURS DAYS MONTHS DAYS-OF-WEEK YEARS"
        /// </summary>
        WithSecondsAndYears
    }
}

