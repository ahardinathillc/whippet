using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves the a <see cref="TaxRule"/> object by its ID. This class cannot be inherited.
    /// </summary>
    public sealed class GetTaxRuleByIdQuery : WhippetQuery<TaxRule>, IWhippetQuery<TaxRule>
    {
        /// <summary>
        /// Gets or sets the ID to query by.
        /// </summary>
        public int ID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetTaxRuleByIdQuery"/> class with no arguments.
        /// </summary>
        private GetTaxRuleByIdQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetTaxRuleByIdQuery"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID to query by.</param>
        public GetTaxRuleByIdQuery(int id)
            : this()
        {
            ID = id;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[] { new KeyValuePair<string, object>(nameof(ID), ID) });
        }

    }
}
