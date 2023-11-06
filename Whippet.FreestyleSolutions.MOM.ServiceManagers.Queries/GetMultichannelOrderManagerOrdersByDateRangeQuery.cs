using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves <see cref="MultichannelOrderManagerOrder"/> objects within a specified date range.
    /// </summary>
    public class GetMultichannelOrderManagerOrdersByDateRangeQuery : WhippetQuery<MultichannelOrderManagerOrder>, IWhippetQuery<MultichannelOrderManagerOrder>
    {
        /// <summary>
        /// Gets or sets the start date range inclusive for filtering the <see cref="MultichannelOrderManagerOrder"/> objects.
        /// </summary>
        public Instant StartDate
        { get; set; }

        /// <summary>
        /// Gets or sets the end date range inclusive for filtering the <see cref="MultichannelOrderManagerOrder"/> objects.
        /// </summary>
        public Instant EndDate
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerOrdersByDateRangeQuery"/> class with no arguments.
        /// </summary>
        private GetMultichannelOrderManagerOrdersByDateRangeQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerOrdersByDateRangeQuery"/> class with the specified date range.
        /// </summary>
        /// <param name="startDate">Start date range inclusive for filtering the <see cref="MultichannelOrderManagerOrder"/> objects.</param>
        /// <param name="endDate">End date range inclusive for filtering the <see cref="MultichannelOrderManagerOrder"/> objects.</param>
        public GetMultichannelOrderManagerOrdersByDateRangeQuery(Instant startDate, Instant endDate)
            : this()
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[]
            {
                new KeyValuePair<string, object>(nameof(StartDate), StartDate),
                new KeyValuePair<string, object>(nameof(EndDate), EndDate)
            });
        }
    }
}
