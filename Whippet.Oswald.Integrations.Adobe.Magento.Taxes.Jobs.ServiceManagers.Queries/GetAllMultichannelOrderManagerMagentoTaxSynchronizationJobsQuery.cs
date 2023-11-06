using System;
using Athi.Whippet.Jobs.ServiceManagers.Queries;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves all <see cref="MultichannelOrderManagerMagentoTaxSynchronizationJob"/> objects in the system. This class cannot be inherited.
    /// </summary>
    public sealed class GetAllMultichannelOrderManagerMagentoTaxSynchronizationJobsQuery : GetAllJobsQuery<MultichannelOrderManagerMagentoTaxSynchronizationJob>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllMultichannelOrderManagerMagentoTaxSynchronizationJobsQuery"/> class with no arguments.
        /// </summary>
        public GetAllMultichannelOrderManagerMagentoTaxSynchronizationJobsQuery()
            : base()
        { }
    }
}

