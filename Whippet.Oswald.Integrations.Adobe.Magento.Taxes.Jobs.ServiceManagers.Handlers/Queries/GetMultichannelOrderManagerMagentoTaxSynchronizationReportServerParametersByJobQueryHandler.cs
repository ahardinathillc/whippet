using System;
using Athi.Whippet.Jobs;
using Athi.Whippet.Jobs.ServiceManagers.Queries;
using Athi.Whippet.Jobs.ServiceManagers.Handlers.Queries;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.Repositories;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Queries;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetMultichannelOrderManagerMagentoTaxSynchronizationReportServerParametersByJobQuery"/> objects.
    /// </summary>
    public class GetMultichannelOrderManagerMagentoTaxSynchronizationReportServerParametersByJobQueryHandler : GetJobParametersByJobQueryHandler<MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter, MultichannelOrderManagerMagentoTaxSynchronizationJob>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerMagentoTaxSynchronizationReportServerParametersByJobQueryHandler"/> class with the specified <see cref="IMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterRepository"/> object.
        /// </summary>
        /// <param name="repository"><see cref="IMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetMultichannelOrderManagerMagentoTaxSynchronizationReportServerParametersByJobQueryHandler(IMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterRepository repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="GetMultichannelOrderManagerMagentoTaxSynchronizationReportServerParametersByJobQuery"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter>>> HandleAsync(GetMultichannelOrderManagerMagentoTaxSynchronizationReportServerParametersByJobQuery query)
        {
            return await base.HandleAsync(query);
        }
    }
}
