using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.EAV.Repositories;

namespace Athi.Whippet.Adobe.Magento.EAV.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Base class for all <see cref="IWhippetQuery{TEntity}"/> handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TQuery">Type of query the handler intercepts.</typeparam>
    public abstract class StoreGroupQueryHandlerBase<TQuery> : WhippetQueryHandler<StoreGroup>, IWhippetQueryHandler<TQuery, StoreGroup>, IStoreGroupQueryHandler<TQuery>
        where TQuery : IWhippetQuery<StoreGroup>
    {
        /// <summary>
        /// Gets the <see cref="IStoreGroupRepository"/> that the queries are executed against. This property is read-only.
        /// </summary>
        protected new IStoreGroupRepository Repository
        {
            get
            {
                return base.Repository as IStoreGroupRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreGroupQueryHandlerBase{TQuery}"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        protected StoreGroupQueryHandlerBase(IWhippetQueryRepository<StoreGroup> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously. This method must be overridden.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract Task<WhippetResultContainer<IEnumerable<StoreGroup>>> HandleAsync(TQuery query);

        /// <summary>
        /// Handles the specified query.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<StoreGroup>> Handle(TQuery query)
        {
            return Task.Run(() => HandleAsync(query)).Result;
        }
    }
}
