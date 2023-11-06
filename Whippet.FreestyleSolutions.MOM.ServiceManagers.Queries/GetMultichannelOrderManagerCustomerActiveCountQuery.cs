using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Extensions;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves the total number of active <see cref="MultichannelOrderManagerCustomer"/> objects for a specific date range. This class cannot be inherited.
    /// </summary>
    public sealed class GetMultichannelOrderManagerCustomerActiveCountQuery : WhippetQuery<MultichannelOrderManagerCustomer>, IWhippetQuery<MultichannelOrderManagerCustomer>
    {
        /// <summary>
        /// Gets or sets the start date range of the query.
        /// </summary>
        public Instant FromDate
        { get; set; }

        /// <summary>
        /// Gets or sets the end date range of the query.
        /// </summary>
        public Instant ToDate
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerCustomerActiveCountQuery"/> class with no arguments.
        /// </summary>
        public GetMultichannelOrderManagerCustomerActiveCountQuery()
            : this(null, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerCustomerActiveCountQuery"/> class with the specified starting and ending date ranges.
        /// </summary>
        /// <param name="fromDate">Starting date range of the query.</param>
        /// <param name="toDate">Ending date range of the query.</param>
        public GetMultichannelOrderManagerCustomerActiveCountQuery(Instant? fromDate, Instant? toDate)
            : base()
        {
            if (!fromDate.HasValue)
            {
                fromDate = DateTime.UtcNow.Lookback(months: 3);  // default to three month lookback
            }

            if (!toDate.HasValue)
            {
                toDate = Instant.FromDateTimeUtc(DateTime.UtcNow);
            }

            FromDate = fromDate.Value;
            ToDate = toDate.Value;
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
