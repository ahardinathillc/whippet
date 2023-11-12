using System;
using Athi.Whippet.Adobe.Magento.Json;

namespace Athi.Whippet.Adobe.Magento.ServiceManagers
{
    /// <summary>
    /// Allows service managers to perform bulk operations with Magento's bulk API.
    /// </summary>
    public interface IBulkServiceManager
    {
        /// <summary>
        /// Gets the status of a bulk operation in Magento.
        /// </summary>
        /// <param name="responseViewModel"><see cref="MagentoBulkOperationResponseViewModel"/> object that contains information about the bulk operation.</param>
        /// <param name="storeCode">Magento store code.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the query.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<WhippetResultContainer<MagentoBulkOperationStatusViewModel>> GetBulkOperationStatus(MagentoBulkOperationResponseViewModel responseViewModel, string storeCode);
    }
}