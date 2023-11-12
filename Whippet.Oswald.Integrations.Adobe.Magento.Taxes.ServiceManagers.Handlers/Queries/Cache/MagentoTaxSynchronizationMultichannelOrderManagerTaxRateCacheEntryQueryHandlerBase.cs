using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.Repositories;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Base class for all <see cref="IWhippetQuery{TEntity}"/> handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TQuery">Type of query the handler intercepts.</typeparam>
    public abstract class MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryQueryHandlerBase<TQuery> : WhippetQueryHandler<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>, IWhippetQueryHandler<TQuery, MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>, IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryQueryHandler<TQuery>
        where TQuery : IWhippetQuery<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>
    {
        /// <summary>
        /// Gets the <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryRepository"/> that the queries are executed against. This property is read-only.
        /// </summary>
        protected new IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryRepository Repository
        {
            get
            {
                return base.Repository as IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryQueryHandlerBase{TQuery}"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        protected MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryQueryHandlerBase(IWhippetQueryRepository<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously. This method must be overridden.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract Task<WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>>> HandleAsync(TQuery query);

        /// <summary>
        /// Handles the specified query.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>> Handle(TQuery query)
        {
            return Task.Run(() => HandleAsync(query)).Result;
        }
    }
}