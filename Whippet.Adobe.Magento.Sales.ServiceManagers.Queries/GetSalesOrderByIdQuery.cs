using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Adobe.Magento.Sales.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves the a <see cref="SalesOrder"/> object by its ID. This class cannot be inherited.
    /// </summary>
    public sealed class GetSalesOrderByIdQuery : WhippetQuery<SalesOrder>, IWhippetQuery<SalesOrder>
    {
        /// <summary>
        /// Gets or sets the ID to query by.
        /// </summary>
        public uint OrderID
        { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesOrderByIdQuery"/> class with no arguments.
        /// </summary>
        private GetSalesOrderByIdQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesOrderByIdQuery"/> class with the specified ID.
        /// </summary>
        /// <param name="orderId">ID of the <see cref="SalesOrder"/> object to retrieve.</param>
        public GetSalesOrderByIdQuery(uint orderId)
            : this()
        {
            OrderID = orderId;
        }

        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state. This method must be overridden.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[]
            {
                new KeyValuePair<string, object>(nameof(OrderID), OrderID)
            });
        }
    }
}
