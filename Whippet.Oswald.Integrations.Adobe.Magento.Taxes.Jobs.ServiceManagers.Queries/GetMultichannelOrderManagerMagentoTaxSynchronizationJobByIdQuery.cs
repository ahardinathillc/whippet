using System;
using Athi.Whippet.Jobs.ServiceManagers.Queries;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves a <see cref="MultichannelOrderManagerMagentoTaxSynchronizationJob"/> by its ID. This class cannot be inherited.
    /// </summary>
    public sealed class GetMultichannelOrderManagerMagentoTaxSynchronizationJobByIdQuery : GetJobByIdQuery<MultichannelOrderManagerMagentoTaxSynchronizationJob>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerMagentoTaxSynchronizationJobByIdQuery"/> class with no arguments.
        /// </summary>
        private GetMultichannelOrderManagerMagentoTaxSynchronizationJobByIdQuery()
            : this(Guid.Empty)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerMagentoTaxSynchronizationJobByIdQuery"/> class with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="GetMultichannelOrderManagerMagentoTaxSynchronizationJobByIdQuery"/> to retrieve.</param>
        public GetMultichannelOrderManagerMagentoTaxSynchronizationJobByIdQuery(Guid id)
            : base(id)
        { }
    }
}
