using System;
using Athi.Whippet.Jobs;
using Athi.Whippet.Jobs.ServiceManagers.Queries;
using Athi.Whippet.Jobs.ServiceManagers.Handlers.Queries;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.Repositories;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Queries;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterByIdQuery"/> objects.
    /// </summary>
    public class GetMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterByIdQueryHandler : GetJobParameterByIdQueryHandler<MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter, MultichannelOrderManagerMagentoTaxSynchronizationJob>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterByIdQueryHandler"/> class with the specified <see cref="IMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterByIdQueryHandler(IMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="GetMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterByIdQuery"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter>>> HandleAsync(GetMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameterByIdQuery query)
        {
            return await base.HandleAsync(query);
        }
    }
}
