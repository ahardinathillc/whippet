using System;
using Athi.Whippet.Jobs.ServiceManagers.Queries;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves all <see cref="MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter"/> objects. This class cannot be inherited.
    /// </summary>
    public sealed class GetAllMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParametersQuery : GetAllJobParametersQuery<MultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParameter, MultichannelOrderManagerMagentoTaxSynchronizationJob>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParametersQuery"/> class with no arguments.
        /// </summary>
        public GetAllMultichannelOrderManagerMagentoTaxSynchronizationMagentoServerParametersQuery()
            : base()
        { }
    }
}
