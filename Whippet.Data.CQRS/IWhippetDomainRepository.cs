using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athi.Whippet.Data.CQRS
{
    /// <summary>
    /// Provides support for domain repositories in Whippet.
    /// </summary>
    public interface IWhippetDomainRepository : IWhippetRepository<WhippetAggregateRoot, Guid>
    {
        /// <summary>
        /// Retrieves the <see cref="WhippetAggregateRoot"/> with the specified ID.
        /// </summary>
        /// <typeparam name="TAggregateRoot">Type of <see cref="WhippetAggregateRoot"/> to return.</typeparam>
        /// <param name="aggregateRootId">Aggregate root ID.</param>
        /// <param name="throwOnNotFound">Throws an exception if the <typeparamref name="TAggregateRoot"/> object could not be loaded based on the specified ID.</param>
        /// <returns><see cref="WhippetAggregateRoot"/> object.</returns>
        /// <exception cref="AggregateNotFoundException" />
        TAggregateRoot Get<TAggregateRoot>(Guid aggregateRootId, bool throwOnNotFound = false) where TAggregateRoot : WhippetAggregateRoot, new();

        /// <summary>
        /// Saves the specified <see cref="WhippetAggregateRoot"/> to the data store.
        /// </summary>
        /// <param name="aggregateRoot"><see cref="WhippetAggregateRoot"/> object to save.</param>
        /// <exception cref="ArgumentNullException" />
        void Save(WhippetAggregateRoot aggregateRoot);
    }
}
