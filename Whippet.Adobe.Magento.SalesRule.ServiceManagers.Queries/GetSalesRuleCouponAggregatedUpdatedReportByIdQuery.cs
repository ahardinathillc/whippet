using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.SalesRule.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves the a <see cref="SalesRuleCouponAggregatedUpdatedReport"/> object by its ID. This class cannot be inherited.
    /// </summary>
    public sealed class GetSalesRuleCouponAggregatedUpdatedReportByIdQuery : WhippetQuery<SalesRuleCouponAggregatedUpdatedReport>, IWhippetQuery<SalesRuleCouponAggregatedUpdatedReport>
    {
        /// <summary>
        /// Gets or sets the ID to query by.
        /// </summary>
        public uint ID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesRuleCouponAggregatedUpdatedReportByIdQuery"/> class with no arguments.
        /// </summary>
        private GetSalesRuleCouponAggregatedUpdatedReportByIdQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesRuleCouponAggregatedUpdatedReportByIdQuery"/> class with the specified ID.
        /// </summary>
        /// <param name="reportId">ID of the <see cref="SalesRuleCouponAggregatedUpdatedReport"/> object to retrieve.</param>
        public GetSalesRuleCouponAggregatedUpdatedReportByIdQuery(uint reportId)
            : this()
        {
            ID = reportId;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[]
            {
                new KeyValuePair<string, object>(nameof(ID), ID)
            });
        }
    }
}
