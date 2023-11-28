using System;
using Athi.Whippet.Adobe.Magento.Json;

namespace Athi.Whippet.Adobe.Magento.Data
{
    /// <summary>
    /// Provides support for monitoring Magento bulk REST operations.
    /// </summary>
    public interface IMagentoBulkStatusReporter
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
