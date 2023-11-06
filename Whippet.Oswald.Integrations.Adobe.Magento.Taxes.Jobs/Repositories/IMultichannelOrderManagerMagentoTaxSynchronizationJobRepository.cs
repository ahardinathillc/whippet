using System;
using Athi.Whippet.Jobs.Repositories;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.Repositories
{
    /// <summary>
    /// Represents a data repository for <see cref="MultichannelOrderManagerMagentoTaxSynchronizationJob"/> objects.
    /// </summary>
    public interface IMultichannelOrderManagerMagentoTaxSynchronizationJobRepository : IJobRepository<MultichannelOrderManagerMagentoTaxSynchronizationJob>, IWhippetQueryRepository<MultichannelOrderManagerMagentoTaxSynchronizationJob>
    { }
}
