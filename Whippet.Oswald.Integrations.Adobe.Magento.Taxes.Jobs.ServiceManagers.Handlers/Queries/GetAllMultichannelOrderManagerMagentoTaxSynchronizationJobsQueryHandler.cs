using System;
using Athi.Whippet.Jobs;
using Athi.Whippet.Jobs.ServiceManagers.Queries;
using Athi.Whippet.Jobs.ServiceManagers.Handlers.Queries;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.Repositories;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Queries;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Command handler for <see cref="GetAllMultichannelOrderManagerMagentoTaxSynchronizationJobsQuery"/> objects.
    /// </summary>
    public class GetAllMultichannelOrderManagerMagentoTaxSynchronizationJobsQueryHandler : GetAllJobsQueryHandler<MultichannelOrderManagerMagentoTaxSynchronizationJob>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllMultichannelOrderManagerMagentoTaxSynchronizationJobsQueryHandler"/> class with the specified <see cref="IMultichannelOrderManagerMagentoTaxSynchronizationJobRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IMultichannelOrderManagerMagentoTaxSynchronizationJobRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetAllMultichannelOrderManagerMagentoTaxSynchronizationJobsQueryHandler(IMultichannelOrderManagerMagentoTaxSynchronizationJobRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="MultichannelOrderManagerMagentoTaxSynchronizationJob"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerMagentoTaxSynchronizationJob>>> HandleAsync(GetAllJobsQuery<MultichannelOrderManagerMagentoTaxSynchronizationJob> query)
        {
            return await base.HandleAsync(query);
        }
    }
}

