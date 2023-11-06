using System;
using Athi.Whippet.Jobs.ServiceManagers.Queries;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves all <see cref="MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter"/> objects. This class cannot be inherited.
    /// </summary>
    public sealed class GetAllMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParametersQuery : GetAllJobParametersQuery<MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter, MultichannelOrderManagerMagentoTaxSynchronizationJob>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParametersQuery"/> class with no arguments.
        /// </summary>
        public GetAllMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParametersQuery()
            : base()
        { }
    }
}
