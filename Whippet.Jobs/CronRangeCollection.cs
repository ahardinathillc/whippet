using System;
using System.Text;
using System.Collections;
using System.Collections.ObjectModel;

namespace Athi.Whippet.Jobs
{
    /// <summary>
    /// Represents a read-only collection of <see cref="CronRange"/> objects for use in constructing cron schedules. Only <see cref="CronRange"/> values that have both a <see cref="CronRange.Start"/> and <see cref="CronRange.End"/> value are stored in the collection; all others are discarded. <see cref="CronRange.Interval"/> is also ignored. This class cannot be inherited.
    /// </summary>
    public sealed class CronRangeCollection : ReadOnlyCollection<CronRange>, IList<CronRange>, ICollection<CronRange>, IEnumerable<CronRange>, IEnumerable, IList, ICollection, IReadOnlyList<CronRange>, IReadOnlyCollection<CronRange>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CronRangeCollection"/> class with no arguments.
        /// </summary>
        private CronRangeCollection()
            : base(new List<CronRange>())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CronRangeCollection"/> class with the specified <see cref="IEnumerable{T}"/> collection of <see cref="CronRange"/> objects.
        /// </summary>
        /// <param name="collection"><see cref="IEnumerable{T}"/> collection of <see cref="CronRange"/> objects.</param>
        /// <exception cref="ArgumentNullException" />
        public CronRangeCollection(IEnumerable<CronRange> collection)
            : base((collection == null) ? null : new List<CronRange>(collection.Where(c => c.Start.HasValue && c.End.HasValue)))
        { }

        /// <summary>
        /// Gets the string representation of the current object.
        /// </summary>
        /// <returns>String representation of the current object.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            foreach (CronRange item in this.OrderBy(cr => cr.Start.GetValueOrDefault()))
            {
                builder.Append(item.ToString(false));
                builder.Append(',');
            }

            builder = builder.Remove(builder.Length - 1, 1);    // remove comma

            return builder.ToString();
        }
    }
}

