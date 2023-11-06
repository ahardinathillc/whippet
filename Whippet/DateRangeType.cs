using System;

namespace Athi.Whippet
{
    /// <summary>
    /// Indicates the type of <see cref="DateRange"/> to use.
    /// </summary>
    public enum DateRangeType
    {
        /// <summary>
        /// Both the beginning and ending dates are included in the range.
        /// </summary>
        Inclusive,
        /// <summary>
        /// Only the dates that occur between the beginning and ending dates are included in the range.
        /// </summary>
        Exclusive,
        /// <summary>
        /// Only the beginning date is included in the range up to one day less than the ending range.
        /// </summary>
        InclusiveStart,
        /// <summary>
        /// Only the ending date is included in the range starting at one day after the starting range.
        /// </summary>
        InclusiveEnd
    }
}

