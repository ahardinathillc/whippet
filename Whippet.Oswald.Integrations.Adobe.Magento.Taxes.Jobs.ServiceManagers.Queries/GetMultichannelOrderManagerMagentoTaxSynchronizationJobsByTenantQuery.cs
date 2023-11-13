using System;
using Athi.Whippet.Jobs.ServiceManagers.Queries;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.ServiceManagers.Queries
{
    /// <summary>
    /// Represents a query that retrieves all <see cref="MultichannelOrderManagerMagentoTaxSynchronizationJob"/> objects by their associated <see cref="IWhippetTenant"/>. This class cannot be inherited.
    /// </summary>
    public sealed class GetMultichannelOrderManagerMagentoTaxSynchronizationJobsByTenantQuery : GetJobsByTenantQuery<MultichannelOrderManagerMagentoTaxSynchronizationJob>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerMagentoTaxSynchronizationJobsByTenantQuery"/> class with no arguments.
        /// </summary>
        public GetMultichannelOrderManagerMagentoTaxSynchronizationJobsByTenantQuery()
            : this(null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerMagentoTaxSynchronizationJobsByTenantQuery"/> class with the specified <see cref="IWhippetTenant"/>.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to filter by.</param>
        public GetMultichannelOrderManagerMagentoTaxSynchronizationJobsByTenantQuery(IWhippetTenant tenant)
            : base(tenant)
        { }
    }
}
