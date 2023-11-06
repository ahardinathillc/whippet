using System;
using FluentNHibernate.Data;
using Athi.Whippet;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="MultichannelOrderManagerCustomerRelationship"/> entity objects.
    /// </summary>
    public interface IMultichannelOrderManagerCustomerRelationshipRepository : IWhippetEntityRepository<MultichannelOrderManagerCustomerRelationship, long>, IWhippetQueryRepository<MultichannelOrderManagerCustomerRelationship>, IWhippetExternalQueryRepository<MultichannelOrderManagerCustomerRelationship, long>
    {
        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerCustomerRelationship"/> objects for the specified relationship IDs.
        /// </summary>
        /// <param name="relationshipIds"><see cref="MultichannelOrderManagerCustomerRelationship"/> IDs of the objects to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomerRelationship>> GetCustomerRelationships(IEnumerable<long> relationshipIds);

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerCustomerRelationship"/> objects for the specified relationship IDs.
        /// </summary>
        /// <param name="relationshipIds"><see cref="MultichannelOrderManagerCustomerRelationship"/> IDs of the objects to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomerRelationship>>> GetCustomerRelationshipsAsync(IEnumerable<long> relationshipIds, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerCustomerRelationship"/> objects for the specified parent <see cref="MultichannelOrderManagerCustomer.CustomerId"/>.
        /// </summary>
        /// <param name="parentCustomerId">Parent <see cref="MultichannelOrderManagerCustomer.CustomerId"/>.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomerRelationship>> GetCustomerRelationshipsForParentCustomer(long parentCustomerId);

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerCustomerRelationship"/> objects for the specified parent <see cref="MultichannelOrderManagerCustomer.CustomerId"/>.
        /// </summary>
        /// <param name="parentCustomerId">Parent <see cref="MultichannelOrderManagerCustomer.CustomerId"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomerRelationship>>> GetCustomerRelationshipsForParentCustomerAsync(long parentCustomerId, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerCustomerRelationship"/> objects for the specified child <see cref="MultichannelOrderManagerCustomer.CustomerId"/>.
        /// </summary>
        /// <param name="childCustomerId">Child <see cref="MultichannelOrderManagerCustomer.CustomerId"/>.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomerRelationship>> GetCustomerRelationshipsForChildCustomer(long childCustomerId);

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerCustomerRelationship"/> objects for the specified child <see cref="MultichannelOrderManagerCustomer.CustomerId"/>.
        /// </summary>
        /// <param name="childCustomerId">Child <see cref="MultichannelOrderManagerCustomer.CustomerId"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomerRelationship>>> GetCustomerRelationshipsForChildCustomerAsync(long childCustomerId, CancellationToken? cancellationToken = null);
    }
}
