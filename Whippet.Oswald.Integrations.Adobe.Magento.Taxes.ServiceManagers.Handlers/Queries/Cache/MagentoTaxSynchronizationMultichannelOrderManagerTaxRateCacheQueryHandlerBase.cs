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
    public abstract class MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheQueryHandlerBase<TQuery> : WhippetQueryHandler<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>, IWhippetQueryHandler<TQuery, MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>, IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheQueryHandler<TQuery>
        where TQuery : IWhippetQuery<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>
    {
        /// <summary>
        /// Gets the <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheRepository"/> that the queries are executed against. This property is read-only.
        /// </summary>
        protected new IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheRepository Repository
        {
            get
            {
                return base.Repository as IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheQueryHandlerBase{TQuery}"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        protected MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheQueryHandlerBase(IWhippetQueryRepository<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously. This method must be overridden.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract Task<WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>>> HandleAsync(TQuery query);

        /// <summary>
        /// Handles the specified query.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>> Handle(TQuery query)
        {
            return Task.Run(() => HandleAsync(query)).Result;
        }
    }
}
