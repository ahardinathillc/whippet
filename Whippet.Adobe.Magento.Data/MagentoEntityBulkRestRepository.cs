using System;
using System.Collections;
using System.Collections.Generic;
using Athi.Whippet.Data;
using Athi.Whippet.Net.Rest;
using Athi.Whippet.Adobe.Magento.Json;
using Athi.Whippet.Adobe.Magento.Repositories;

namespace Athi.Whippet.Adobe.Magento.Data
{
    /// <summary>
    /// Represents a generic repository that is independent of the backing data store for <see cref="MagentoEntity"/> objects accessible by a RESTful interface with support for bulk operations. This class must be inherited.
    /// </summary>
    /// <typeparam name="TEntity">Type of <see cref="WhippetEntity"/> object to store in the repository.</typeparam>
    public abstract class MagentoEntityBulkRestRepository<TEntity> : MagentoEntityRestRepository<TEntity>, IDisposable, IMagentoEntityRepository<TEntity>, IMagentoBulkSupport<TEntity>
        where TEntity : MagentoEntity, IMagentoEntity, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoEntityBulkRestRepository{TEntity}"/> class with the specified <see cref="IWhippetRestClient"/>.
        /// </summary>
        /// <param name="restClient"><see cref="IWhippetRestClient"/> object used to marshall the REST requests.</param>
        /// <param name="bearerToken">Authorization bearer token for making requests.</param>
        /// <exception cref="ArgumentNullException" />
        protected MagentoEntityBulkRestRepository(IWhippetRestClient restClient, string bearerToken)
            : base(restClient, bearerToken)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoEntityBulkRestRepository{TEntity}"/> class with the specified <see cref="IWhippetRestClient"/>.
        /// </summary>
        /// <param name="restClient"><see cref="IWhippetRestClient"/> object used to marshall the REST requests.</param>
        /// <param name="bearerToken">Authorization bearer token for making requests.</param>
        /// <param name="baseUrl">Base URL of the request (e.g., &quote;orders/&quot;).</param>
        /// <exception cref="ArgumentNullException" />
        protected MagentoEntityBulkRestRepository(IWhippetRestClient restClient, string bearerToken, string baseUrl)
            : base(restClient, bearerToken, baseUrl)
        { }        
        
        /// <summary>
        /// Adds the specified collection of <typeparamref name="TEntity"/> objects to the Magento data store.
        /// </summary>
        /// <param name="objects"><see cref="IEnumerable{T}"/> collection of <typeparamref name="TEntity"/> objects.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract WhippetResultContainer<MagentoBulkOperationResponseViewModel> BulkAdd(IEnumerable<TEntity> objects);

        /// <summary>
        /// Adds the specified collection of <typeparamref name="TEntity"/> objects to the Magento data store.
        /// </summary>
        /// <param name="objects"><see cref="IEnumerable{T}"/> collection of <typeparamref name="TEntity"/> objects.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract Task<WhippetResultContainer<MagentoBulkOperationResponseViewModel>> BulkAddAsync(IEnumerable<TEntity> objects, CancellationToken? cancellationToken = null);
        
        /// <summary>
        /// Deletes the specified collection of <typeparamref name="TEntity"/> objects from the Magento data store.
        /// </summary>
        /// <param name="objects"><see cref="IEnumerable{T}"/> collection of <typeparamref name="TEntity"/> objects.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract WhippetResultContainer<MagentoBulkOperationResponseViewModel> BulkDelete(IEnumerable<TEntity> objects);

        /// <summary>
        /// Deletes the specified collection of <typeparamref name="TEntity"/> objects from the Magento data store.
        /// </summary>
        /// <param name="objects"><see cref="IEnumerable{T}"/> collection of <typeparamref name="TEntity"/> objects.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract Task<WhippetResultContainer<MagentoBulkOperationResponseViewModel>> BulkDeleteAsync(IEnumerable<TEntity> objects, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Updates the specified collection of <typeparamref name="TEntity"/> objects from the Magento data store.
        /// </summary>
        /// <param name="objects"><see cref="IEnumerable{T}"/> collection of <typeparamref name="TEntity"/> objects.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract WhippetResultContainer<MagentoBulkOperationResponseViewModel> BulkUpdate(IEnumerable<TEntity> objects);

        /// <summary>
        /// Updates the specified collection of <typeparamref name="TEntity"/> objects from the Magento data store.
        /// </summary>
        /// <param name="objects"><see cref="IEnumerable{T}"/> collection of <typeparamref name="TEntity"/> objects.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract Task<WhippetResultContainer<MagentoBulkOperationResponseViewModel>> BulkUpdateAsync(IEnumerable<TEntity> objects, CancellationToken? cancellationToken = null);
    }
}
