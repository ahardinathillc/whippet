using System;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Json;

namespace Athi.Whippet.Adobe.Magento.Repositories
{
    /// <summary>
    /// Provides bulk operation support to Magento entity repositories.
    /// </summary>
    /// <typeparam name="TObject">Type of Magento entity.</typeparam>
    public interface IMagentoBulkSupport<TObject>
        where TObject : IMagentoEntity
    {
        /// <summary>
        /// Adds the specified collection of <typeparamref name="TObject"/> objects to the Magento data store.
        /// </summary>
        /// <param name="objects"><see cref="IEnumerable{T}"/> collection of <typeparamref name="TObject"/> objects.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<MagentoBulkOperationResponseViewModel> BulkAdd(IEnumerable<TObject> objects);

        /// <summary>
        /// Adds the specified collection of <typeparamref name="TObject"/> objects to the Magento data store.
        /// </summary>
        /// <param name="objects"><see cref="IEnumerable{T}"/> collection of <typeparamref name="TObject"/> objects.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<MagentoBulkOperationResponseViewModel>> BulkAddAsync(IEnumerable<TObject> objects, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Deletes the specified collection of <typeparamref name="TObject"/> objects from the Magento data store.
        /// </summary>
        /// <param name="objects"><see cref="IEnumerable{T}"/> collection of <typeparamref name="TObject"/> objects.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<MagentoBulkOperationResponseViewModel> BulkDelete(IEnumerable<TObject> objects);

        /// <summary>
        /// Deletes the specified collection of <typeparamref name="TObject"/> objects from the Magento data store.
        /// </summary>
        /// <param name="objects"><see cref="IEnumerable{T}"/> collection of <typeparamref name="TObject"/> objects.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<MagentoBulkOperationResponseViewModel>> BulkDeleteAsync(IEnumerable<TObject> objects, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Updates the specified collection of <typeparamref name="TObject"/> objects from the Magento data store.
        /// </summary>
        /// <param name="objects"><see cref="IEnumerable{T}"/> collection of <typeparamref name="TObject"/> objects.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<MagentoBulkOperationResponseViewModel> BulkUpdate(IEnumerable<TObject> objects);

        /// <summary>
        /// Updates the specified collection of <typeparamref name="TObject"/> objects from the Magento data store.
        /// </summary>
        /// <param name="objects"><see cref="IEnumerable{T}"/> collection of <typeparamref name="TObject"/> objects.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<MagentoBulkOperationResponseViewModel>> BulkUpdateAsync(IEnumerable<TObject> objects, CancellationToken? cancellationToken = null);
    }
}