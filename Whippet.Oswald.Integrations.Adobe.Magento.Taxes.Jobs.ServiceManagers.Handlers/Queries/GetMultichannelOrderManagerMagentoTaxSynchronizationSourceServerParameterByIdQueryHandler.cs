using System;
using Athi.Whippet.Jobs;
using Athi.Whippet.Jobs.ServiceManagers.Queries;
using Athi.Whippet.Jobs.ServiceManagers.Handlers.Queries;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.Repositories;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Queries;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterByIdQuery"/> objects.
    /// </summary>
    public class GetMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterByIdQueryHandler : GetJobParameterByIdQueryHandler<MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter, MultichannelOrderManagerMagentoTaxSynchronizationJob>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterByIdQueryHandler"/> class with the specified <see cref="IMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterByIdQueryHandler(IMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="GetMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterByIdQuery"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter>>> HandleAsync(GetMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterByIdQuery query)
        {
            return await base.HandleAsync(query);
        }
    }
}
