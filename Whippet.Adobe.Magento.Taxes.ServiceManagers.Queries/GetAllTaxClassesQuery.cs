using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.Taxes.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves all <see cref="TaxClass"/> objects in the system. This class cannot be inherited.
    /// </summary>
    public sealed class GetAllTaxClassesQuery : WhippetQuery<TaxClass>, IWhippetQuery<TaxClass>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllTaxClassesQuery"/> class with no arguments.
        /// </summary>
        public GetAllTaxClassesQuery()
            : base()
        { }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return NoParameters;
        }
    }
}
