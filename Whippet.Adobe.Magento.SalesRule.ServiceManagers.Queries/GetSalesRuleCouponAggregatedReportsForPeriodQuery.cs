using System;
using NodaTime;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.SalesRule.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves all <see cref="SalesRuleCouponAggregatedReport"/> objects for a specified period. This class cannot be inherited.
    /// </summary>
    public sealed class GetSalesRuleCouponAggregatedReportsForPeriodQuery : WhippetQuery<SalesRuleCouponAggregatedReport>, IWhippetQuery<SalesRuleCouponAggregatedReport>
    {
        /// <summary>
        /// Gets or sets the starting period to query by.
        /// </summary>
        public Instant FromPeriod
        { get; set; }

        /// <summary>
        /// Gets or sets the ending period to query by.
        /// </summary>
        public Instant ToPeriod
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesRuleCouponAggregatedReportsForPeriodQuery"/> class with no arguments.
        /// </summary>
        public GetSalesRuleCouponAggregatedReportsForPeriodQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesRuleCouponAggregatedReportsForPeriodQuery"/> class with the specified period.
        /// </summary>
        /// <param name="fromPeriod">Starting period to query by.</param>
        /// <param name="toPeriod">Ending period to query by.</param>
        public GetSalesRuleCouponAggregatedReportsForPeriodQuery(Instant fromPeriod, Instant toPeriod)
            : this()
        {
            FromPeriod = fromPeriod;
            ToPeriod = toPeriod;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[]
            {
                new KeyValuePair<string, object>(nameof(FromPeriod), FromPeriod),
                new KeyValuePair<string, object>(nameof(ToPeriod), ToPeriod)
            });
        }
    }
}
