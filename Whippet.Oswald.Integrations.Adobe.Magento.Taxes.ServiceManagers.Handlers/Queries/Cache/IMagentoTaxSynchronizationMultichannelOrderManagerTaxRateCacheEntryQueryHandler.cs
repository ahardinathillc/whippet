using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Handles queries against <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> objects.
    /// </summary>
    /// <typeparam name="TQuery"><see cref="IWhippetQuery{TEntity}"/> type to handle.</typeparam>
    public interface IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryQueryHandler<TQuery> : IWhippetQueryHandler<TQuery, MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry> where TQuery : IWhippetQuery<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>
    { }
}
