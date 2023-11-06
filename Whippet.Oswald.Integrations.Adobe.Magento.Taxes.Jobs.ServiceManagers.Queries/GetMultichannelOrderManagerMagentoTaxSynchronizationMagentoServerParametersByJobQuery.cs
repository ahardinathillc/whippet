using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Jobs.ServiceManagers.Queries;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves a <see cref="MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter"/> by its ID. This class cannot be inherited.
    /// </summary>
    public sealed class GetMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParametersByJobQuery : GetJobParametersByJobQuery<MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter, MultichannelOrderManagerMagentoTaxSynchronizationJob>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParametersByJobQuery"/> class with no arguments.
        /// </summary>
        private GetMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParametersByJobQuery()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParametersByJobQuery"/> class with the specified <see cref="MultichannelOrderManagerMagentoTaxSynchronizationJob"/>.
        /// </summary>
        /// <param name="job"><see cref="MultichannelOrderManagerMagentoTaxSynchronizationJob"/> object to initialize with.</param>
        public GetMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParametersByJobQuery(MultichannelOrderManagerMagentoTaxSynchronizationJob job)
            : base(job)
        { }
    }
}
