using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.ParadoxLabs.Magento.Subscriptions.Repositories;

namespace Athi.Whippet.ParadoxLabs.Magento.Subscriptions.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Base class for all <see cref="IWhippetQuery{TEntity}"/> handlers. This class must be inherited.
    /// </summary>
    public abstract class SubscriptionQueryHandlerBase<TQuery> : WhippetQueryHandler<Subscription>, IWhippetQueryHandler<TQuery, Subscription>, ISubscriptionQueryHandler<TQuery>
        where TQuery : IWhippetQuery<Subscription>
    {
        /// <summary>
        /// Gets the <see cref="ISubscriptionRepository"/> that the queries are executed against. This property is read-only.
        /// </summary>
        protected new ISubscriptionRepository Repository
        {
            get
            {
                return base.Repository as ISubscriptionRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionQueryHandlerBase{TQuery}"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        protected SubscriptionQueryHandlerBase(IWhippetQueryRepository<Subscription> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously. This method must be overridden.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract Task<WhippetResultContainer<IEnumerable<Subscription>>> HandleAsync(TQuery query);

        /// <summary>
        /// Handles the specified query.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<Subscription>> Handle(TQuery query)
        {
            return Task.Run(() => HandleAsync(query)).Result;
        }        
    }
}
