using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.ParadoxLabs.Magento.Subscriptions.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves a <see cref="Subscription"/> object by its ID. This class cannot be inherited.
    /// </summary>
    public sealed class GetSubscriptionByIdQuery : WhippetQuery<Subscription>, IWhippetQuery<Subscription>
    {
        /// <summary>
        /// Gets the ID of the <see cref="Subscription"/> to retrieve. This property is read-only.
        /// </summary>
        public int ID
        { get; private set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSubscriptionByIdQuery"/> class with no arguments.
        /// </summary>
        private GetSubscriptionByIdQuery()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSubscriptionByIdQuery"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="Subscription"/> to retrieve.</param>
        public GetSubscriptionByIdQuery(int id)
            : this()
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(id, 1);
            ID = id;
        }
        
        /// <summary>
        /// Gets an <see cref="IReadOnlyDictionary{TKey, TValue}"/> indexed by the query parameters and their associated values in the object's current state.
        /// </summary>
        /// <returns><see cref="IReadOnlyDictionary{TKey, TValue}"/> object.</returns>
        protected override IReadOnlyDictionary<string, object> GetQueryParametersAndValues()
        {
            return new Dictionary<string, object>(new[] { new KeyValuePair<string, object>(nameof(ID), ID) });
        }
    }
}
