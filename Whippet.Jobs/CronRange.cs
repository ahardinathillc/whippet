using System;

namespace Athi.Whippet.Jobs
{
    /// <summary>
    /// Represents a numeric range for a cron job.
    /// </summary>
    public struct CronRange : IEqualityComparer<CronRange>
    {
        /// <summary>
        /// Represents the lowerbound range value. This property is read-only.
        /// </summary>
        public int? Start
        { get; private set; }

        /// <summary>
        /// Represents the upperbound range value. This property is read-only.
        /// </summary>
        public int? End
        { get; private set; }

        /// <summary>
        /// Represents the repeat interval to apply to the range. This property is read-only.
        /// </summary>
        public int? Interval
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CronRange"/> struct with no arguments.
        /// </summary>
        static CronRange()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CronRange"/> struct with the specified range.
        /// </summary>
        /// <param name="start">Lowerbound range value.</param>
        /// <param name="end">Upperbound range value.</param>
        /// <exception cref="ArgumentOutOfRangeException" />
        public CronRange(int? start, int? end)
            : this(start, end, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CronRange"/> struct with the specified range.
        /// </summary>
        /// <param name="start">Lowerbound range value.</param>
        /// <param name="end">Upperbound range value.</param>
        /// <param name="interval">Repeat interval to apply to the range.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public CronRange(int? start, int? end, int? interval)
            : this()
        {
            if ((start.GetValueOrDefault() > end.GetValueOrDefault()) || (start.GetValueOrDefault() < 0))
            {
                throw new ArgumentOutOfRangeException(nameof(start));
            }
            else if (end.GetValueOrDefault() < start.GetValueOrDefault() || (end.GetValueOrDefault() < 0))
            {
                throw new ArgumentOutOfRangeException(nameof(end));
            }
            else if (interval.GetValueOrDefault() < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(interval));
            }
            else
            {
                Start = start;
                End = end;
                Interval = interval;
            }
        }

        /// <summary>
        /// Creates a <see cref="CronRange"/> instance that is executed for every interval of a given time with the optional repeat interval.
        /// </summary>
        /// <param name="interval">Repeat interval value.</param>
        /// <returns><see cref="CronRange"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        public static CronRange CreateEachInstace(int? interval = null)
        {
            return new CronRange(null, null, interval);
        }

        /// <summary>
        /// Creates a single interval <see cref="CronRange"/> with the specified repeat interval value.
        /// </summary>
        /// <param name="value">Individual value that is both the start and end range.</param>
        /// <param name="interval">Repeat interval value.</param>
        /// <returns><see cref="CronRange"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException" />
        public static CronRange CreateSingleInstance(int? value, int? interval = null)
        {
            return new CronRange(value, value, interval);
        }

        /// <summary>
        /// Creates an instance for the seconds portion of the cron schedule.
        /// </summary>
        /// <param name="value">Value to apply.</param>
        /// <param name="interval">Repeat interval value.</param>
        /// <returns><see cref="CronRange"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static CronRange CreateSecondInstance(int? value, int? interval = null)
        {
            if (value.GetValueOrDefault() < 0 || value.GetValueOrDefault() > 59)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }
            else
            {
                return CreateSingleInstance(value, interval);
            }
        }

        /// <summary>
        /// Creates an instance for the seconds portion of the cron schedule.
        /// </summary>
        /// <param name="start">Lowerbound range value.</param>
        /// <param name="end">Upperbound range value.</param>
        /// <param name="interval">Repeat interval value.</param>
        /// <returns><see cref="CronRange"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static CronRange CreateSecondRange(int? start, int? end, int? interval = null)
        {
            if (start.GetValueOrDefault() < 0 || start.GetValueOrDefault() > 59)
            {
                throw new ArgumentOutOfRangeException(nameof(start));
            }
            else if (end.GetValueOrDefault() < 0 || end.GetValueOrDefault() > 59)
            {
                throw new ArgumentOutOfRangeException(nameof(end));
            }
            else
            {
                return new CronRange(start, end, interval);
            }
        }

        /// <summary>
        /// Creates an instance for the minutes portion of the cron schedule.
        /// </summary>
        /// <param name="value">Value to apply.</param>
        /// <param name="interval">Repeat interval value.</param>
        /// <returns><see cref="CronRange"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static CronRange CreateMinuteInstance(int? value, int? interval = null)
        {
            if (value.GetValueOrDefault() < 0 || value.GetValueOrDefault() > 59)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }
            else
            {
                return CreateSingleInstance(value, interval);
            }
        }

        /// <summary>
        /// Creates an instance for the minutes portion of the cron schedule.
        /// </summary>
        /// <param name="start">Lowerbound range value.</param>
        /// <param name="end">Upperbound range value.</param>
        /// <param name="interval">Repeat interval value.</param>
        /// <returns><see cref="CronRange"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static CronRange CreateMinuteRange(int? start, int? end, int? interval = null)
        {
            if (start.GetValueOrDefault() < 0 || start.GetValueOrDefault() > 59)
            {
                throw new ArgumentOutOfRangeException(nameof(start));
            }
            else if (end.GetValueOrDefault() < 0 || end.GetValueOrDefault() > 59)
            {
                throw new ArgumentOutOfRangeException(nameof(end));
            }
            else
            {
                return new CronRange(start, end, interval);
            }
        }

        /// <summary>
        /// Creates an instance for the hours portion of the cron schedule.
        /// </summary>
        /// <param name="value">Value to apply.</param>
        /// <param name="interval">Repeat interval value.</param>
        /// <returns><see cref="CronRange"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static CronRange CreateHourInstance(int? value, int? interval = null)
        {
            if (value.GetValueOrDefault() < 0 || value.GetValueOrDefault() > 23)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }
            else
            {
                return CreateSingleInstance(value, interval);
            }
        }

        /// <summary>
        /// Creates an instance for the hours portion of the cron schedule.
        /// </summary>
        /// <param name="start">Lowerbound range value.</param>
        /// <param name="end">Upperbound range value.</param>
        /// <param name="interval">Repeat interval value.</param>
        /// <returns><see cref="CronRange"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static CronRange CreateHourRange(int? start, int? end, int? interval = null)
        {
            if (start.GetValueOrDefault() < 0 || start.GetValueOrDefault() > 23)
            {
                throw new ArgumentOutOfRangeException(nameof(start));
            }
            else if (end.GetValueOrDefault() < 0 || end.GetValueOrDefault() > 23)
            {
                throw new ArgumentOutOfRangeException(nameof(end));
            }
            else
            {
                return new CronRange(start, end, interval);
            }
        }

        /// <summary>
        /// Creates an instance for the days of month portion of the cron schedule.
        /// </summary>
        /// <param name="value">Value to apply.</param>
        /// <param name="interval">Repeat interval value.</param>
        /// <returns><see cref="CronRange"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static CronRange CreateDayOfMonthInstance(int? value, int? interval = null)
        {
            if (value.GetValueOrDefault() < 0 || value.GetValueOrDefault() > 31)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }
            else
            {
                return CreateSingleInstance(value, interval);
            }
        }

        /// <summary>
        /// Creates an instance for the days of month portion of the cron schedule.
        /// </summary>
        /// <param name="start">Lowerbound range value.</param>
        /// <param name="end">Upperbound range value.</param>
        /// <param name="interval">Repeat interval value.</param>
        /// <returns><see cref="CronRange"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static CronRange CreateDayOfMonthRange(int? start, int? end, int? interval = null)
        {
            if (start.GetValueOrDefault() < 0 || start.GetValueOrDefault() > 31)
            {
                throw new ArgumentOutOfRangeException(nameof(start));
            }
            else if (end.GetValueOrDefault() < 0 || end.GetValueOrDefault() > 31)
            {
                throw new ArgumentOutOfRangeException(nameof(end));
            }
            else
            {
                return new CronRange(start, end, interval);
            }
        }

        /// <summary>
        /// Creates an instance for the months portion of the cron schedule.
        /// </summary>
        /// <param name="value">Value to apply.</param>
        /// <param name="interval">Repeat interval value.</param>
        /// <returns><see cref="CronRange"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static CronRange CreateMonthInstance(int? value, int? interval = null)
        {
            if (value.GetValueOrDefault() < 0 || value.GetValueOrDefault() > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }
            else
            {
                return CreateSingleInstance(value, interval);
            }
        }

        /// <summary>
        /// Creates an instance for the months portion of the cron schedule.
        /// </summary>
        /// <param name="start">Lowerbound range value.</param>
        /// <param name="end">Upperbound range value.</param>
        /// <param name="interval">Repeat interval value.</param>
        /// <returns><see cref="CronRange"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static CronRange CreateMonthRange(int? start, int? end, int? interval = null)
        {
            if (start.GetValueOrDefault() < 0 || start.GetValueOrDefault() > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(start));
            }
            else if (end.GetValueOrDefault() < 0 || end.GetValueOrDefault() > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(end));
            }
            else
            {
                return new CronRange(start, end, interval);
            }
        }

        /// <summary>
        /// Creates an instance for the days of week portion of the cron schedule.
        /// </summary>
        /// <param name="value">Value to apply.</param>
        /// <param name="interval">Repeat interval value.</param>
        /// <returns><see cref="CronRange"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static CronRange CreateDayOfWeekInstance(int? value, int? interval = null)
        {
            if (value.GetValueOrDefault() < 0 || value.GetValueOrDefault() > 7)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }
            else
            {
                return CreateSingleInstance(value, interval);
            }
        }

        /// <summary>
        /// Creates an instance for the days of week portion of the cron schedule.
        /// </summary>
        /// <param name="start">Lowerbound range value.</param>
        /// <param name="end">Upperbound range value.</param>
        /// <param name="interval">Repeat interval value.</param>
        /// <returns><see cref="CronRange"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static CronRange CreateDayOfWeekRange(int? start, int? end, int? interval = null)
        {
            if (start.HasValue && (start.GetValueOrDefault() < 0 || start.GetValueOrDefault() > 7))
            {
                throw new ArgumentOutOfRangeException(nameof(start));
            }
            else if (end.HasValue && (end.GetValueOrDefault() < 0 || end.GetValueOrDefault() > 7))
            {
                throw new ArgumentOutOfRangeException(nameof(end));
            }
            else
            {
                return new CronRange(start, end, interval);
            }
        }

        /// <summary>
        /// Creates an instance for the years portion of the cron schedule.
        /// </summary>
        /// <param name="value">Value to apply.</param>
        /// <param name="interval">Repeat interval value.</param>
        /// <returns><see cref="CronRange"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static CronRange CreateYearInstance(int? value, int? interval = null)
        {
            if (value.HasValue && (value.GetValueOrDefault() < 1900 || value.GetValueOrDefault() > 3000))
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }
            else
            {
                return CreateSingleInstance(value, interval);
            }
        }

        /// <summary>
        /// Creates an instance for the years portion of the cron schedule.
        /// </summary>
        /// <param name="start">Lowerbound range value.</param>
        /// <param name="end">Upperbound range value.</param>
        /// <param name="interval">Repeat interval value.</param>
        /// <returns><see cref="CronRange"/> instance.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static CronRange CreateYearRange(int? start, int? end, int? interval = null)
        {
            if (start.HasValue && (start.GetValueOrDefault() < 1900 || start.GetValueOrDefault() > 3000))
            {
                throw new ArgumentOutOfRangeException(nameof(start));
            }
            else if (end.HasValue && (end.GetValueOrDefault() < 1900 || end.GetValueOrDefault() > 3000))
            {
                throw new ArgumentOutOfRangeException(nameof(end));
            }
            else
            {
                return new CronRange(start, end, interval);
            }
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the two objects are equal; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object obj)
        {
            return (obj == null || !(obj is CronRange)) ? false : Equals((CronRange)(obj));
        }

        /// <summary>
        /// Compares the current instance to the specified object for equality.
        /// </summary>
        /// <param name="obj">Object to compare against.</param>
        /// <returns><see langword="true"/> if the two objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(CronRange obj)
        {
            return Equals(this, obj);
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="x">First object to compare.</param>
        /// <param name="y">Second object to compare.</param>
        /// <returns><see langword="true"/> if the two objects are equal; otherwise, <see langword="false"/>.</returns>
        public bool Equals(CronRange x, CronRange y)
        {
            return x.Start.GetValueOrDefault() == y.End.GetValueOrDefault() && x.Interval.GetValueOrDefault() == y.Interval.GetValueOrDefault();
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        /// <summary>
        /// Gets the hash code for the specified object.
        /// </summary>
        /// <param name="obj">Object to get the hash code for.</param>
        /// <returns>Hash code for the specified object.</returns>
        public int GetHashCode(CronRange obj)
        {
            return obj.GetHashCode();
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            return ToString(true);
        }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <param name="includeInterval">If <see langword="true"/>, will include the <see cref="Interval"/> value as part of the cron statement.</param>
        /// <returns>String representation of the current object.</returns>
        public string ToString(bool includeInterval)
        {
            string cronStatement = null;

            if (Start.HasValue && End.HasValue)
            {
                if (Start.Value == End.Value)
                {
                    cronStatement = Convert.ToString(Start.Value);
                }
                else
                {
                    cronStatement = Convert.ToString(Start.Value) + '-' + Convert.ToString(End.Value);
                }
            }
            else
            {
                if (Start.HasValue && !End.HasValue)
                {
                    cronStatement = Convert.ToString(Start.Value);
                }
                else if (!Start.HasValue && End.HasValue)
                {
                    cronStatement = Convert.ToString(End.Value);
                }
                else
                {
                    cronStatement = "*";
                }
            }

            if (Interval.HasValue && includeInterval)
            {
                cronStatement = cronStatement + '/' + Convert.ToString(Interval.Value);
            }

            return cronStatement;
        }
    }
}

