using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;
using Athi.Whippet.Data;
using Athi.Whippet.Adobe.Magento.Json;

namespace Athi.Whippet.Adobe.Magento.Data
{
    /// <summary>
    /// Represents a generic repository that is independent of the backing data store for <see cref="MagentoEntity"/> objects accessible by a RESTful interface. This class must be inherited.
    /// </summary>
    /// <typeparam name="TEntity">Type of <see cref="WhippetEntity"/> object to store in the repository.</typeparam>
    public interface IMagentoEntityRepository<TEntity> : IWhippetEntityRepository<TEntity, uint>, IWhippetRepository<TEntity, uint>, IWhippetRestRepository<TEntity, uint>, IDisposable
        where TEntity : MagentoEntity, IMagentoEntity, new()
    {
        /// <summary>
        /// Gets the bulk operation status based on the unique ID of the operation.
        /// </summary>
        /// <param name="responseViewModel"><see cref="MagentoBulkOperationResponseViewModel"/> object that contains the ID of the bulk operation.</param>
        /// <param name="storeCode">Store code.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        WhippetResultContainer<MagentoBulkOperationStatusViewModel> GetBulkOperationStatus(MagentoBulkOperationResponseViewModel responseViewModel, string storeCode);

        /// <summary>
        /// Gets the bulk operation status based on the unique ID of the operation.
        /// </summary>
        /// <param name="responseViewModel"><see cref="MagentoBulkOperationResponseViewModel"/> object that contains the ID of the bulk operation.</param>
        /// <param name="storeCode">Store code.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<WhippetResultContainer<MagentoBulkOperationStatusViewModel>> GetBulkOperationStatusAsync(MagentoBulkOperationResponseViewModel responseViewModel, string storeCode);
    }
}        
