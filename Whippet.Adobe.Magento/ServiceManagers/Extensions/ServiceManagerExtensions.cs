using System;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Adobe.Magento.Json;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.ServiceManagers.Extensions
{
    /// <summary>
    /// Provides extension methods to <see cref="ServiceManager"/> objects. This class cannot be inherited.
    /// </summary>
    public static class ServiceManagerExtensions
    {
        /// <summary>
        /// Gets the status of a bulk operation in Magento.
        /// </summary>
        /// <typeparam name="TRepository"><see cref="IMagentoEntity"/> repository type.</typeparam>
        /// <typeparam name="TEntity"><see cref="IMagentoEntity"/> object type.</typeparam>
        /// <param name="serviceManager"><see cref="ServiceManager"/> object that provides context for the operation.</param>
        /// <param name="repository"><see cref="IMagentoEntityRepository{TEntity}"/> to execute the operation from.</param>
        /// <param name="responseViewModel"><see cref="MagentoBulkOperationResponseViewModel"/> object that contains information about the bulk operation.</param>
        /// <param name="storeCode">Magento store code.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object containing the result of the query.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<WhippetResultContainer<MagentoBulkOperationStatusViewModel>> GetMagentoBulkOperationStatus<TRepository, TEntity>(this ServiceManager serviceManager, TRepository repository, MagentoBulkOperationResponseViewModel responseViewModel, string storeCode)
            where TEntity : MagentoEntity, IMagentoEntity, new()
            where TRepository : IMagentoEntityRepository<TEntity>
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }
            else if (String.IsNullOrWhiteSpace(storeCode))
            {
                throw new ArgumentNullException(nameof(storeCode));
            }
            else
            {
                return await repository.GetBulkOperationStatusAsync(responseViewModel, storeCode);
            }
        }
    }
}

