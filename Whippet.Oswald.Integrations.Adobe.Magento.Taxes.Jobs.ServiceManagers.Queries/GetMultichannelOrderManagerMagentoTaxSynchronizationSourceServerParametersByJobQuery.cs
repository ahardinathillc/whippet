using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Jobs.ServiceManagers.Queries;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves a <see cref="MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter"/> by its ID. This class cannot be inherited.
    /// </summary>
    public sealed class GetMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParametersByJobQuery : GetJobParametersByJobQuery<MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter, MultichannelOrderManagerMagentoTaxSynchronizationJob>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParametersByJobQuery"/> class with no arguments.
        /// </summary>
        private GetMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParametersByJobQuery()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParametersByJobQuery"/> class with the specified <see cref="MultichannelOrderManagerMagentoTaxSynchronizationJob"/>.
        /// </summary>
        /// <param name="job"><see cref="MultichannelOrderManagerMagentoTaxSynchronizationJob"/> object to initialize with.</param>
        public GetMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParametersByJobQuery(MultichannelOrderManagerMagentoTaxSynchronizationJob job)
            : base(job)
        { }
    }
}
