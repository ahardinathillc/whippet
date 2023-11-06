using System;
using Athi.Whippet.Jobs;
using Athi.Whippet.Jobs.ServiceManagers.Queries;
using Athi.Whippet.Jobs.ServiceManagers.Handlers.Queries;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.Repositories;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Queries;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParametersByJobQuery"/> objects.
    /// </summary>
    public class GetMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParametersByJobQueryHandler : GetJobParametersByJobQueryHandler<MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter, MultichannelOrderManagerMagentoTaxSynchronizationJob>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParametersByJobQueryHandler"/> class with the specified <see cref="IMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParametersByJobQueryHandler(IMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="GetMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParametersByJobQuery"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter>>> HandleAsync(GetMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParametersByJobQuery query)
        {
            return await base.HandleAsync(query);
        }
    }
}
