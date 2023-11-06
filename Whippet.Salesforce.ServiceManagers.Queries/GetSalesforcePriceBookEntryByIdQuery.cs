using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Salesforce.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves all <see cref="SalesforcePriceBookEntry"/> objects based on a specific composite key.
    /// </summary>
    public class GetSalesforcePriceBookEntryByIdQuery : WhippetQuery<SalesforcePriceBookEntry>, IWhippetQuery<SalesforcePriceBookEntry>
    {
        /// <summary>
        /// Gets or sets the ID of the <see cref="SalesforcePriceBook"/> to query by.
        /// </summary>
        public string PricebookID
        { get; set; }

        /// <summary>
        /// Gets or sets the ID of the <see cref="SalesforceProduct"/> to query by.
        /// </summary>
        public string ProductID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesforcePriceBookEntryByIdQuery"/> class with no arguments.
        /// </summary>
        public GetSalesforcePriceBookEntryByIdQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesforcePriceBookEntryByIdQuery"/> class with the specified <see cref="SalesforcePriceBookEntryKey"/>.
        /// </summary>
        /// <param name="entry"><see cref="SalesforcePriceBookEntryKey"/> object.</param>
        public GetSalesforcePriceBookEntryByIdQuery(SalesforcePriceBookEntryKey entry)
            : this(entry.PriceBookId, entry.ProductId)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesforcePriceBookEntryByIdQuery"/> class with the specified IDs.
        /// </summary>
        /// <param name="priceBookId">ID of the <see cref="SalesforcePriceBook"/> to query by.</param>
        /// <param name="productId">ID of the <see cref="SalesforceProduct"/> to query by.</param>
        public GetSalesforcePriceBookEntryByIdQuery(string priceBookId, string productId)
            : this()
        {
            PricebookID = priceBookId;
            ProductID = productId;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[]
            {
                new KeyValuePair<string, object>(nameof(PricebookID), PricebookID),
                new KeyValuePair<string, object>(nameof(ProductID), ProductID)
            });
        }
    }
}
