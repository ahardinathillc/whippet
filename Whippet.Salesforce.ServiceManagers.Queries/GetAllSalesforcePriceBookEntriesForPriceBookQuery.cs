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
    /// Represents a query that retrieves all <see cref="SalesforcePriceBookEntry"/> objects based on a given <see cref="SalesforcePriceBook"/> ID.
    /// </summary>
    public class GetAllSalesforcePriceBookEntriesForPriceBookQuery : WhippetQuery<SalesforcePriceBookEntry>, IWhippetQuery<SalesforcePriceBookEntry>
    {
        /// <summary>
        /// Gets or sets the ID of the <see cref="SalesforcePriceBook"/> to query by.
        /// </summary>
        public string PricebookID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllSalesforcePriceBookEntriesForPriceBookQuery"/> class with no arguments.
        /// </summary>
        public GetAllSalesforcePriceBookEntriesForPriceBookQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllSalesforcePriceBookEntriesForPriceBookQuery"/> class with the specified IDs.
        /// </summary>
        /// <param name="priceBookId">ID of the <see cref="SalesforcePriceBook"/> to query by.</param>
        public GetAllSalesforcePriceBookEntriesForPriceBookQuery(string priceBookId)
            : this()
        {
            PricebookID = priceBookId;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[]
            {
                new KeyValuePair<string, object>(nameof(PricebookID), PricebookID)
            });
        }
    }
}
