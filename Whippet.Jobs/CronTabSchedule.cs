using System;
using System.Text;
using NCrontab.Advanced.Exceptions;
using NCronTabSchedule = NCrontab.Advanced.CrontabSchedule;
using NCronStringFormat = NCrontab.Advanced.Enumerations.CronStringFormat;
using Athi.Whippet.Extensions.Text;

namespace Athi.Whippet.Jobs
{
    /// <summary>
    /// Represents a crontab scheudle. This class cannot be inherited.
    /// </summary>
    public sealed class CronTabSchedule : NCronTabSchedule, IEqualityComparer<NCronTabSchedule>, IWhippetCloneable
    {
        /// <summary>
        /// Maximum length of a cron statement.
        /// </summary>
        internal const int MAX_CRON_LENGTH = 999;

        /// <summary>
        /// Specifies the cron format to use when parsing an expression.
        /// </summary>
        public new CronStringFormat Format
        {
            get
            {
                return Enum.Parse<CronStringFormat>(Convert.ToString(base.Format));     // has to match NCrontab.Advanced.Enumerations.CronStringFormat values
            }
            set
            {
                base.Format = Enum.Parse<NCronStringFormat>(Convert.ToString(value));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CronTabSchedule"/> class with no arguments.
        /// </summary>
        public CronTabSchedule()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CronTabSchedule"/> class with the specified expression and format.
        /// </summary>
        /// <param name="expression">Cron expression to parse.</param>
        /// <param name="format">Cron string format to use.</param>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="CrontabException" />
        public CronTabSchedule(string expression, CronStringFormat format = CronStringFormat.Default)
            : this()
        {
            NCronTabSchedule schedule = Parse(expression, Enum.Parse<NCronStringFormat>(Convert.ToString(format)));
            Filters = schedule.Filters;
            base.Format = schedule.Format;
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRange minute, CronRange hour, CronRange dayOfMonth, CronRange monthOfYear, CronRange dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRange minute, CronRange hour, CronRange dayOfMonth, CronRange monthOfYear, CronRange dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRangeCollection minute, CronRange hour, CronRange dayOfMonth, CronRange monthOfYear, CronRange dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRangeCollection minute, CronRange hour, CronRange dayOfMonth, CronRange monthOfYear, CronRange dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRange minute, CronRangeCollection hour, CronRange dayOfMonth, CronRange monthOfYear, CronRange dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRange minute, CronRangeCollection hour, CronRange dayOfMonth, CronRange monthOfYear, CronRange dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRangeCollection minute, CronRangeCollection hour, CronRange dayOfMonth, CronRange monthOfYear, CronRange dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRange minute, CronRange hour, CronRangeCollection dayOfMonth, CronRange monthOfYear, CronRange dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRange minute, CronRange hour, CronRangeCollection dayOfMonth, CronRange monthOfYear, CronRange dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRange minute, CronRangeCollection hour, CronRangeCollection dayOfMonth, CronRange monthOfYear, CronRange dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRange minute, CronRangeCollection hour, CronRangeCollection dayOfMonth, CronRange monthOfYear, CronRange dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRangeCollection minute, CronRangeCollection hour, CronRangeCollection dayOfMonth, CronRange monthOfYear, CronRange dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRangeCollection minute, CronRangeCollection hour, CronRangeCollection dayOfMonth, CronRange monthOfYear, CronRange dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRange minute, CronRange hour, CronRange dayOfMonth, CronRangeCollection monthOfYear, CronRange dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRange minute, CronRange hour, CronRange dayOfMonth, CronRangeCollection monthOfYear, CronRange dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRangeCollection minute, CronRange hour, CronRange dayOfMonth, CronRangeCollection monthOfYear, CronRange dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRangeCollection minute, CronRange hour, CronRange dayOfMonth, CronRangeCollection monthOfYear, CronRange dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRange minute, CronRangeCollection hour, CronRange dayOfMonth, CronRangeCollection monthOfYear, CronRange dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRange minute, CronRangeCollection hour, CronRange dayOfMonth, CronRangeCollection monthOfYear, CronRange dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRangeCollection minute, CronRangeCollection hour, CronRange dayOfMonth, CronRangeCollection monthOfYear, CronRange dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRangeCollection minute, CronRangeCollection hour, CronRange dayOfMonth, CronRangeCollection monthOfYear, CronRange dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRange minute, CronRange hour, CronRangeCollection dayOfMonth, CronRangeCollection monthOfYear, CronRange dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRange minute, CronRange hour, CronRangeCollection dayOfMonth, CronRangeCollection monthOfYear, CronRange dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRangeCollection minute, CronRange hour, CronRangeCollection dayOfMonth, CronRangeCollection monthOfYear, CronRange dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRangeCollection minute, CronRange hour, CronRangeCollection dayOfMonth, CronRangeCollection monthOfYear, CronRange dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRange minute, CronRangeCollection hour, CronRangeCollection dayOfMonth, CronRangeCollection monthOfYear, CronRange dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRange minute, CronRangeCollection hour, CronRangeCollection dayOfMonth, CronRangeCollection monthOfYear, CronRange dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRangeCollection minute, CronRangeCollection hour, CronRangeCollection dayOfMonth, CronRangeCollection monthOfYear, CronRange dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRangeCollection minute, CronRangeCollection hour, CronRangeCollection dayOfMonth, CronRangeCollection monthOfYear, CronRange dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRange minute, CronRange hour, CronRange dayOfMonth, CronRange monthOfYear, CronRangeCollection dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRange minute, CronRange hour, CronRange dayOfMonth, CronRange monthOfYear, CronRangeCollection dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRangeCollection minute, CronRange hour, CronRange dayOfMonth, CronRange monthOfYear, CronRangeCollection dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRangeCollection minute, CronRange hour, CronRange dayOfMonth, CronRange monthOfYear, CronRangeCollection dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRange minute, CronRangeCollection hour, CronRange dayOfMonth, CronRange monthOfYear, CronRangeCollection dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRange minute, CronRangeCollection hour, CronRange dayOfMonth, CronRange monthOfYear, CronRangeCollection dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRangeCollection minute, CronRangeCollection hour, CronRange dayOfMonth, CronRange monthOfYear, CronRangeCollection dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRangeCollection minute, CronRangeCollection hour, CronRange dayOfMonth, CronRange monthOfYear, CronRangeCollection dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRange minute, CronRange hour, CronRangeCollection dayOfMonth, CronRange monthOfYear, CronRangeCollection dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRange minute, CronRange hour, CronRangeCollection dayOfMonth, CronRange monthOfYear, CronRangeCollection dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRangeCollection minute, CronRange hour, CronRangeCollection dayOfMonth, CronRange monthOfYear, CronRangeCollection dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRangeCollection minute, CronRange hour, CronRangeCollection dayOfMonth, CronRange monthOfYear, CronRangeCollection dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRange minute, CronRangeCollection hour, CronRangeCollection dayOfMonth, CronRange monthOfYear, CronRangeCollection dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRange minute, CronRangeCollection hour, CronRangeCollection dayOfMonth, CronRange monthOfYear, CronRangeCollection dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRangeCollection minute, CronRangeCollection hour, CronRangeCollection dayOfMonth, CronRange monthOfYear, CronRangeCollection dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRangeCollection minute, CronRangeCollection hour, CronRangeCollection dayOfMonth, CronRange monthOfYear, CronRangeCollection dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRange minute, CronRange hour, CronRange dayOfMonth, CronRangeCollection monthOfYear, CronRangeCollection dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRange minute, CronRange hour, CronRange dayOfMonth, CronRangeCollection monthOfYear, CronRangeCollection dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRangeCollection minute, CronRange hour, CronRange dayOfMonth, CronRangeCollection monthOfYear, CronRangeCollection dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRangeCollection minute, CronRange hour, CronRange dayOfMonth, CronRangeCollection monthOfYear, CronRangeCollection dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRange minute, CronRangeCollection hour, CronRange dayOfMonth, CronRangeCollection monthOfYear, CronRangeCollection dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRange minute, CronRangeCollection hour, CronRange dayOfMonth, CronRangeCollection monthOfYear, CronRangeCollection dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRangeCollection minute, CronRangeCollection hour, CronRange dayOfMonth, CronRangeCollection monthOfYear, CronRangeCollection dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRange minute, CronRange hour, CronRangeCollection dayOfMonth, CronRangeCollection monthOfYear, CronRangeCollection dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRange minute, CronRange hour, CronRangeCollection dayOfMonth, CronRangeCollection monthOfYear, CronRangeCollection dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRangeCollection minute, CronRange hour, CronRangeCollection dayOfMonth, CronRangeCollection monthOfYear, CronRangeCollection dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRangeCollection minute, CronRange hour, CronRangeCollection dayOfMonth, CronRangeCollection monthOfYear, CronRangeCollection dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRange minute, CronRangeCollection hour, CronRangeCollection dayOfMonth, CronRangeCollection monthOfYear, CronRangeCollection dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRange minute, CronRangeCollection hour, CronRangeCollection dayOfMonth, CronRangeCollection monthOfYear, CronRangeCollection dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRangeCollection minute, CronRangeCollection hour, CronRangeCollection dayOfMonth, CronRangeCollection monthOfYear, CronRangeCollection dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRangeCollection minute, CronRangeCollection hour, CronRangeCollection dayOfMonth, CronRangeCollection monthOfYear, CronRangeCollection dayOfWeek, CronRange year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRange minute, CronRange hour, CronRange dayOfMonth, CronRange monthOfYear, CronRange dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRange minute, CronRange hour, CronRange dayOfMonth, CronRange monthOfYear, CronRange dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRangeCollection minute, CronRange hour, CronRange dayOfMonth, CronRange monthOfYear, CronRange dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRangeCollection minute, CronRange hour, CronRange dayOfMonth, CronRange monthOfYear, CronRange dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRange minute, CronRangeCollection hour, CronRange dayOfMonth, CronRange monthOfYear, CronRange dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRange minute, CronRangeCollection hour, CronRange dayOfMonth, CronRange monthOfYear, CronRange dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRangeCollection minute, CronRangeCollection hour, CronRange dayOfMonth, CronRange monthOfYear, CronRange dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRangeCollection minute, CronRangeCollection hour, CronRange dayOfMonth, CronRange monthOfYear, CronRange dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRange minute, CronRange hour, CronRangeCollection dayOfMonth, CronRange monthOfYear, CronRange dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRange minute, CronRange hour, CronRangeCollection dayOfMonth, CronRange monthOfYear, CronRange dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRangeCollection minute, CronRange hour, CronRangeCollection dayOfMonth, CronRange monthOfYear, CronRange dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRangeCollection minute, CronRange hour, CronRangeCollection dayOfMonth, CronRange monthOfYear, CronRange dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRange minute, CronRangeCollection hour, CronRangeCollection dayOfMonth, CronRange monthOfYear, CronRange dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRange minute, CronRangeCollection hour, CronRangeCollection dayOfMonth, CronRange monthOfYear, CronRange dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRangeCollection minute, CronRangeCollection hour, CronRangeCollection dayOfMonth, CronRange monthOfYear, CronRange dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRangeCollection minute, CronRangeCollection hour, CronRangeCollection dayOfMonth, CronRange monthOfYear, CronRange dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRange minute, CronRange hour, CronRange dayOfMonth, CronRangeCollection monthOfYear, CronRange dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRange minute, CronRange hour, CronRange dayOfMonth, CronRangeCollection monthOfYear, CronRange dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRangeCollection minute, CronRange hour, CronRange dayOfMonth, CronRangeCollection monthOfYear, CronRange dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRangeCollection minute, CronRange hour, CronRange dayOfMonth, CronRangeCollection monthOfYear, CronRange dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRange minute, CronRangeCollection hour, CronRange dayOfMonth, CronRangeCollection monthOfYear, CronRange dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRange minute, CronRangeCollection hour, CronRange dayOfMonth, CronRangeCollection monthOfYear, CronRange dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRangeCollection minute, CronRangeCollection hour, CronRange dayOfMonth, CronRangeCollection monthOfYear, CronRange dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRange minute, CronRange hour, CronRangeCollection dayOfMonth, CronRangeCollection monthOfYear, CronRange dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRange minute, CronRange hour, CronRangeCollection dayOfMonth, CronRangeCollection monthOfYear, CronRange dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRangeCollection minute, CronRange hour, CronRangeCollection dayOfMonth, CronRangeCollection monthOfYear, CronRange dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRangeCollection minute, CronRange hour, CronRangeCollection dayOfMonth, CronRangeCollection monthOfYear, CronRange dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRange minute, CronRangeCollection hour, CronRangeCollection dayOfMonth, CronRangeCollection monthOfYear, CronRange dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRange minute, CronRangeCollection hour, CronRangeCollection dayOfMonth, CronRangeCollection monthOfYear, CronRange dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRangeCollection minute, CronRangeCollection hour, CronRangeCollection dayOfMonth, CronRangeCollection monthOfYear, CronRange dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRangeCollection minute, CronRangeCollection hour, CronRangeCollection dayOfMonth, CronRangeCollection monthOfYear, CronRange dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRange minute, CronRange hour, CronRange dayOfMonth, CronRange monthOfYear, CronRangeCollection dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRange minute, CronRange hour, CronRange dayOfMonth, CronRange monthOfYear, CronRangeCollection dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRangeCollection minute, CronRange hour, CronRange dayOfMonth, CronRange monthOfYear, CronRangeCollection dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRangeCollection minute, CronRange hour, CronRange dayOfMonth, CronRange monthOfYear, CronRangeCollection dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRange minute, CronRangeCollection hour, CronRange dayOfMonth, CronRange monthOfYear, CronRangeCollection dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRange minute, CronRangeCollection hour, CronRange dayOfMonth, CronRange monthOfYear, CronRangeCollection dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRangeCollection minute, CronRangeCollection hour, CronRange dayOfMonth, CronRange monthOfYear, CronRangeCollection dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRangeCollection minute, CronRangeCollection hour, CronRange dayOfMonth, CronRange monthOfYear, CronRangeCollection dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRange minute, CronRange hour, CronRangeCollection dayOfMonth, CronRange monthOfYear, CronRangeCollection dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRange minute, CronRange hour, CronRangeCollection dayOfMonth, CronRange monthOfYear, CronRangeCollection dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRangeCollection minute, CronRange hour, CronRangeCollection dayOfMonth, CronRange monthOfYear, CronRangeCollection dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRangeCollection minute, CronRange hour, CronRangeCollection dayOfMonth, CronRange monthOfYear, CronRangeCollection dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRange minute, CronRangeCollection hour, CronRangeCollection dayOfMonth, CronRange monthOfYear, CronRangeCollection dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRange minute, CronRangeCollection hour, CronRangeCollection dayOfMonth, CronRange monthOfYear, CronRangeCollection dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRangeCollection minute, CronRangeCollection hour, CronRangeCollection dayOfMonth, CronRange monthOfYear, CronRangeCollection dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRangeCollection minute, CronRangeCollection hour, CronRangeCollection dayOfMonth, CronRange monthOfYear, CronRangeCollection dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRange minute, CronRange hour, CronRange dayOfMonth, CronRangeCollection monthOfYear, CronRangeCollection dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRange minute, CronRange hour, CronRange dayOfMonth, CronRangeCollection monthOfYear, CronRangeCollection dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRangeCollection minute, CronRange hour, CronRange dayOfMonth, CronRangeCollection monthOfYear, CronRangeCollection dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRangeCollection minute, CronRange hour, CronRange dayOfMonth, CronRangeCollection monthOfYear, CronRangeCollection dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRange minute, CronRangeCollection hour, CronRange dayOfMonth, CronRangeCollection monthOfYear, CronRangeCollection dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRange minute, CronRangeCollection hour, CronRange dayOfMonth, CronRangeCollection monthOfYear, CronRangeCollection dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRangeCollection minute, CronRangeCollection hour, CronRange dayOfMonth, CronRangeCollection monthOfYear, CronRangeCollection dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRange minute, CronRange hour, CronRangeCollection dayOfMonth, CronRangeCollection monthOfYear, CronRangeCollection dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRange minute, CronRange hour, CronRangeCollection dayOfMonth, CronRangeCollection monthOfYear, CronRangeCollection dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRangeCollection minute, CronRange hour, CronRangeCollection dayOfMonth, CronRangeCollection monthOfYear, CronRangeCollection dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRangeCollection minute, CronRange hour, CronRangeCollection dayOfMonth, CronRangeCollection monthOfYear, CronRangeCollection dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRange minute, CronRangeCollection hour, CronRangeCollection dayOfMonth, CronRangeCollection monthOfYear, CronRangeCollection dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRange minute, CronRangeCollection hour, CronRangeCollection dayOfMonth, CronRangeCollection monthOfYear, CronRangeCollection dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRange second, CronRangeCollection minute, CronRangeCollection hour, CronRangeCollection dayOfMonth, CronRangeCollection monthOfYear, CronRangeCollection dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Creates a new <see cref="CronTabSchedule"/> object with the specified parameters.
        /// </summary>
        /// <param name="second">Seconds value.</param>
        /// <param name="minute">Minutes value.</param>
        /// <param name="hour">Hours value.</param>
        /// <param name="dayOfMonth">Days of month value.</param>
        /// <param name="monthOfYear">Months of year value.</param>
        /// <param name="dayOfWeek">Days of week value.</param>
        /// <param name="year">Years value.</param>
        /// <returns><see cref="CronTabSchedule"/> object.</returns>
        /// <exception cref="CrontabException" />
        public static CronTabSchedule CreateSchedule(CronRangeCollection second, CronRangeCollection minute, CronRangeCollection hour, CronRangeCollection dayOfMonth, CronRangeCollection monthOfYear, CronRangeCollection dayOfWeek, CronRangeCollection year)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(second.ToString());
            builder.AppendSpace();
            builder.Append(minute.ToString());
            builder.AppendSpace();
            builder.Append(hour.ToString());
            builder.AppendSpace();
            builder.Append(dayOfMonth.ToString());
            builder.AppendSpace();
            builder.Append(monthOfYear.ToString());
            builder.AppendSpace();
            builder.Append(dayOfWeek.ToString());
            builder.AppendSpace();
            builder.Append(year.ToString());

            return new CronTabSchedule(builder.ToString(), CronStringFormat.WithSecondsAndYears);
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return (obj == null || !(obj is NCronTabSchedule)) ? false : Equals((NCronTabSchedule)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(NCronTabSchedule obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(NCronTabSchedule x, NCronTabSchedule y)
        {
            bool equals = (x == null && y == null);

            if (!equals && (x != null) && (y != null))
            {
                equals = String.Equals(x.ToString(), y.ToString(), StringComparison.InvariantCultureIgnoreCase);
            }

            return equals;
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return GetHashCode(this);
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code.</returns>
        public int GetHashCode(NCronTabSchedule obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            else
            {
                return obj.ToString().GetHashCode();
            }
        }

        /// <summary>
        /// Creates a duplicate instance of the current object.
        /// </summary>
        /// <returns>Duplicate instance of the current object.</returns>
        public object Clone()
        {
            return new CronTabSchedule(ToString(), Format);
        }

        /// <summary>
        /// Creates a duplicate instance of the current object with the optional <see cref="Guid"/> that represents the user ID of the user who instantiated the new instance.
        /// </summary>
        /// <typeparam name="TObject">Type of object to return from the operation.</typeparam>
        /// <param name="createdBy"><see cref="Guid"/> ID of the user who instantiated the new instance.</param>
        /// <returns>Object of type <typeparamref name="TObject"/>.</returns>
        public TObject Clone<TObject>(Guid? createdBy = null)
        {
            return (TObject)(Clone());
        }

        /// <summary>
        /// Gets the cron schedule expressed in crontab syntax.
        /// </summary>
        /// <returns>Crontab syntax representing the current instance.</returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
