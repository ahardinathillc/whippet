using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.SalesRule.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves the a <see cref="SalesRule"/> object(s) by its ID. This class cannot be inherited.
    /// </summary>
    public sealed class GetSalesRuleByIdQuery : WhippetQuery<SalesRule>, IWhippetQuery<SalesRule>
    {
        /// <summary>
        /// Gets or sets the ID to query by.
        /// </summary>
        public uint RuleID
        { get; set; }

        /// <summary>
        /// Gets or sets the row ID to query by in conjunction with <see cref="RuleID"/>.
        /// </summary>
        public uint? RowID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesRuleByIdQuery"/> class with no arguments.
        /// </summary>
        private GetSalesRuleByIdQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesRuleByIdQuery"/> class with the specified ID.
        /// </summary>
        /// <param name="ruleId">ID of the <see cref="SalesRule"/> object to retrieve.</param>
        public GetSalesRuleByIdQuery(uint ruleId)
            : this(ruleId, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesRuleByIdQuery"/> class with the specified ID.
        /// </summary>
        /// <param name="ruleId">ID of the <see cref="SalesRule"/> object to retrieve.</param>
        /// <param name="rowId">Row ID to query by in conjunction with <paramref name="ruleId"/>.</param>
        public GetSalesRuleByIdQuery(uint ruleId, uint? rowId)
            : this()
        {
            RuleID = ruleId;
            RowID = rowId;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[]
            {
                new KeyValuePair<string, object>(nameof(RuleID), RuleID),
                new KeyValuePair<string, object>(nameof(RowID), RowID)
            });
        }
    }
}
