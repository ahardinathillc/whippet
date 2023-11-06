using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Jobs.ServiceManagers.Queries;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves a <see cref="MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter"/> by its ID. This class cannot be inherited.
    /// </summary>
    public sealed class GetMultichannelOrderManagerMagentoTaxSynchronizationReportServerParametersByJobQuery : GetJobParametersByJobQuery<MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter, MultichannelOrderManagerMagentoTaxSynchronizationJob>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerMagentoTaxSynchronizationReportServerParametersByJobQuery"/> class with no arguments.
        /// </summary>
        private GetMultichannelOrderManagerMagentoTaxSynchronizationReportServerParametersByJobQuery()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerMagentoTaxSynchronizationReportServerParametersByJobQuery"/> class with the specified <see cref="MultichannelOrderManagerMagentoTaxSynchronizationJob"/>.
        /// </summary>
        /// <param name="job"><see cref="MultichannelOrderManagerMagentoTaxSynchronizationJob"/> object to initialize with.</param>
        public GetMultichannelOrderManagerMagentoTaxSynchronizationReportServerParametersByJobQuery(MultichannelOrderManagerMagentoTaxSynchronizationJob job)
            : base(job)
        { }
    }
}
