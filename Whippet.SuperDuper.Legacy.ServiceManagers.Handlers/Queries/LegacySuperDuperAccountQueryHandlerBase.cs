using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.SuperDuper.Legacy.Repositories;

namespace Athi.Whippet.SuperDuper.Legacy.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Base class for all <see cref="IWhippetQuery{TEntity}"/> handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TQuery">Type of query the handler intercepts.</typeparam>
    public abstract class LegacySuperDuperAccountQueryHandlerBase<TQuery> : WhippetQueryHandler<LegacySuperDuperAccount>, IWhippetQueryHandler<TQuery, LegacySuperDuperAccount>, ILegacySuperDuperAccountQueryHandler<TQuery>
        where TQuery : IWhippetQuery<LegacySuperDuperAccount>
    {
        /// <summary>
        /// Gets the <see cref="ILegacySuperDuperAccountRepository"/> that the queries are executed against. This property is read-only.
        /// </summary>
        protected new ILegacySuperDuperAccountRepository Repository
        {
            get
            {
                return base.Repository as ILegacySuperDuperAccountRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LegacySuperDuperAccountQueryHandlerBase{TQuery}"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        protected LegacySuperDuperAccountQueryHandlerBase(IWhippetQueryRepository<LegacySuperDuperAccount> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously. This method must be overridden.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract Task<WhippetResultContainer<IEnumerable<LegacySuperDuperAccount>>> HandleAsync(TQuery query);

        /// <summary>
        /// Handles the specified query.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<LegacySuperDuperAccount>> Handle(TQuery query)
        {
            return Task.Run(() => HandleAsync(query)).Result;
        }        
    }
}
