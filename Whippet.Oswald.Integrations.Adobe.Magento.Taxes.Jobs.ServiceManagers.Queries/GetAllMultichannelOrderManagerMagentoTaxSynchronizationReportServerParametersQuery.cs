using System;
using Athi.Whippet.Jobs.ServiceManagers.Queries;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves all <see cref="MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter"/> objects. This class cannot be inherited.
    /// </summary>
    public sealed class GetAllMultichannelOrderManagerMagentoTaxSynchronizationReportServerParametersQuery : GetAllJobParametersQuery<MultichannelOrderManagerMagentoTaxSynchronizationReportServerParameter, MultichannelOrderManagerMagentoTaxSynchronizationJob>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllMultichannelOrderManagerMagentoTaxSynchronizationReportServerParametersQuery"/> class with no arguments.
        /// </summary>
        public GetAllMultichannelOrderManagerMagentoTaxSynchronizationReportServerParametersQuery()
            : base()
        { }
    }
}
