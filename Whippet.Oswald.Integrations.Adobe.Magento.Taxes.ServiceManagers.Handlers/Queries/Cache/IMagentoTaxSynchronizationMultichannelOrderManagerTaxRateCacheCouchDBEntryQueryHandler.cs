using System;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Handles queries against <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> objects.
    /// </summary>
    /// <typeparam name="TQuery"><see cref="IWhippetQuery{TEntity}"/> type to handle.</typeparam>
    public interface IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryQueryHandler<TQuery> : IWhippetQueryHandler<TQuery, MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry> where TQuery : IWhippetQuery<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>
    { }
}
