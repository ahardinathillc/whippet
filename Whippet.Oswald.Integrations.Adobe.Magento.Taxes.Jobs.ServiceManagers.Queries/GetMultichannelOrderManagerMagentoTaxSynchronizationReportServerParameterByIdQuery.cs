using System;
using Athi.Whippet.Jobs.ServiceManagers.Queries;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves a <see cref="MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter"/> by its ID. This class cannot be inherited.
    /// </summary>
    public sealed class GetMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterByIdQuery : GetJobParameterByIdQuery<MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter, MultichannelOrderManagerMagentoTaxSynchronizationJob>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterByIdQuery"/> class with no arguments.
        /// </summary>
        private GetMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterByIdQuery()
            : this(Guid.Empty)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterByIdQuery"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="GetMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterByIdQuery"/> to retrieve.</param>
        public GetMultichannelOrderManagerMagentoTaxSynchronizationReportServerParameterByIdQuery(Guid id)
            : base(id)
        { }
    }
}
