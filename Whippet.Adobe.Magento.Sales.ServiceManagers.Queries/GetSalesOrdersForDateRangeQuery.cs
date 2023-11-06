using System;
using NodaTime;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.Sales.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves all <see cref="SalesOrder"/> objects for a specific date range.
    /// </summary>
    public class GetSalesOrdersForDateRangeQuery : WhippetQuery<SalesOrder>, IWhippetQuery<SalesOrder>
    {
        /// <summary>
        /// Gets or sets the starting date of the query.
        /// </summary>
        public Instant FromDate
        { get; set; }

        /// <summary>
        /// Gets or sets the ending date of the query.
        /// </summary>
        public Instant ToDate
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesOrdersForDateRangeQuery"/> with a default date range of the previous day to the current.
        /// </summary>
        public GetSalesOrdersForDateRangeQuery()
            : this(Instant.FromDateTimeUtc(new DateTime(DateTime.UtcNow.AddDays(-1).Year, DateTime.UtcNow.AddDays(-1).Month, DateTime.UtcNow.AddDays(-1).Day, 0, 0, 0, DateTimeKind.Utc)), Instant.FromDateTimeUtc(new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 0, 0, 0, DateTimeKind.Utc)))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesOrdersForDateRangeQuery"/> with the specified date range.
        /// </summary>
        /// <param name="fromDate">Starting date range of the query.</param>
        /// <param name="toDate">Ending date range of the query.</param>
        public GetSalesOrdersForDateRangeQuery(Instant fromDate, Instant toDate)
        {
            FromDate = fromDate;
            ToDate = toDate;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[]
            {
                new KeyValuePair<string, object>(nameof(FromDate), FromDate),
                new KeyValuePair<string, object>(nameof(ToDate), ToDate)
            });
        }
    }
}
