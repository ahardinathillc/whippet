using System;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Jobs.Repositories;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Jobs.Repositories
{
    /// <summary>
    /// Represents a data repository for <see cref="MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter"/> objects.
    /// </summary>
    public interface IMultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameterRepository : IJobParameterRepository<MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter, MultichannelOrderManagerMagentoTaxSynchronizationJob>, IWhippetEntityRepository<MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter, Guid>, IWhippetQueryRepository<MultichannelOrderManagerMagentoTaxSynchronizationSourceServerParameter>
    { }
}
