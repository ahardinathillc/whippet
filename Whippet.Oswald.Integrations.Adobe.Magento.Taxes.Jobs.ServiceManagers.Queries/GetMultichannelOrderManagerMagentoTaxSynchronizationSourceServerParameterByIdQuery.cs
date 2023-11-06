using System;
using Athi.Whippet.Jobs.ServiceManagers.Queries;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves a <see cref="MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter"/> by its ID. This class cannot be inherited.
    /// </summary>
    public sealed class GetMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterByIdQuery : GetJobParameterByIdQuery<MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter, MultichannelOrderManagerMagentoTaxSynchronizationJob>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterByIdQuery"/> class with no arguments.
        /// </summary>
        private GetMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterByIdQuery()
            : this(Guid.Empty)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterByIdQuery"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="GetMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterByIdQuery"/> to retrieve.</param>
        public GetMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterByIdQuery(Guid id)
            : base(id)
        { }
    }
}
