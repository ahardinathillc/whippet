using System;
using NodaTime;

namespace Athi.Whippet
{
    /// <summary>
    /// Represents a range between two dates. All dates are set to UTC time.
    /// </summary>
    public struct DateRange
    {
        /// <summary>
        /// Gets the starting date range. This property is read-only.
        /// </summary>
        public Instant Start
        { get; private set; } = Instant.MinValue;

        public Instant End
        { get; private set; } = Instant.MaxValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="DateRange"/> structure with no arguments.
        /// </summary>
        static DateRange()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DateRange"/> structure with the specified start and end dates.
        /// </summary>
        /// <param name="start">Start date.</param>
        /// <param name="end">End date.</param>
        /// <param name="type"><see cref="DateRangeType"/> value that indicates how the range should be established.</param>
        public DateRange(Instant start, Instant end, DateRangeType type = DateRangeType.Inclusive)
            : this()
        {
            DateTime startDttm = start.ToDateTimeUtc();
            DateTime endDttm = end.ToDateTimeUtc();

            startDttm = new DateTime(startDttm.Year, startDttm.Month, startDttm.Day, 0, 0, 0, 0, 0, DateTimeKind.Utc);
            endDttm = new DateTime(endDttm.Year, endDttm.Month, endDttm.Day, 23, 59, 59, 999, 999, DateTimeKind.Utc);

            switch (type)
            {
                case DateRangeType.Exclusive:
                    startDttm = startDttm.AddDays(1.0);
                    endDttm = endDttm.AddDays(-1.0);
                    break;
                case DateRangeType.InclusiveStart:
                    endDttm = endDttm.AddDays(-1.0);
                    break;
                case DateRangeType.InclusiveEnd:
                    startDttm = startDttm.AddDays(1.0);
                    break;
                case DateRangeType.Inclusive:
                default:
                    break;
            }

            Start = Instant.FromDateTimeUtc(startDttm);
            End = Instant.FromDateTimeUtc(endDttm);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DateRange"/> structure with the specified start and end dates.
        /// </summary>
        /// <param name="start">Start date.</param>
        /// <param name="end">End date.</param>
        /// <param name="type"><see cref="DateRangeType"/> value that indicates how the range should be established.</param>
        public DateRange(DateTime start, DateTime end, DateRangeType type = DateRangeType.Inclusive)
            : this(Instant.FromDateTimeUtc(start.Kind == DateTimeKind.Utc ? start : start.ToUniversalTime()), Instant.FromDateTimeUtc(end.Kind == DateTimeKind.Utc ? end : end.ToUniversalTime()), type)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DateRange"/> structure with the specified start and end dates.
        /// </summary>
        /// <param name="start">Start date.</param>
        /// <param name="end">End date.</param>
        /// <param name="type"><see cref="DateRangeType"/> value that indicates how the range should be established.</param>
        public DateRange(DateOnly start, DateOnly end, DateRangeType type = DateRangeType.Inclusive)
            : this(Instant.FromDateTimeUtc(new DateTime(start.Year, start.Month, start.Day, 0, 0, 0, DateTimeKind.Utc)), Instant.FromDateTimeUtc(new DateTime(end.Year, end.Month, end.Day, 0, 0, 0, DateTimeKind.Utc)))
        { }
    }
}

