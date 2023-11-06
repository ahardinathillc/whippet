using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security;
using Athi.Whippet.Security.Repositories;
using Athi.Whippet.Web.Mvc.Security;
using Athi.Whippet.Web.Mvc.Security.Repositories;
using Athi.Whippet.Web.Mvc.Security.ServiceManagers.Queries;

namespace Athi.Whippet.Web.Mvc.Security.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Base class for all <see cref="IWhippetQuery{TEntity}"/> handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TQuery">Type of query the handler intercepts.</typeparam>
    public abstract class WhippetViewPermissionEntryQueryHandlerBase<TQuery> : WhippetQueryHandler<WhippetViewPermissionEntry>, IWhippetQueryHandler<TQuery, WhippetViewPermissionEntry>, IWhippetViewPermissionEntryQueryHandler<TQuery>
        where TQuery : IWhippetQuery<WhippetViewPermissionEntry>
    {
        /// <summary>
        /// Gets the <see cref="IWhippetViewPermissionEntryRepository"/> that the queries are executed against. This property is read-only.
        /// </summary>
        protected new IWhippetViewPermissionEntryRepository Repository
        {
            get
            {
                return base.Repository as IWhippetViewPermissionEntryRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetViewPermissionEntryQueryHandlerBase{TQuery}"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        protected WhippetViewPermissionEntryQueryHandlerBase(IWhippetQueryRepository<WhippetViewPermissionEntry> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously. This method must be overridden.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract Task<WhippetResultContainer<IEnumerable<WhippetViewPermissionEntry>>> HandleAsync(TQuery query);

        /// <summary>
        /// Handles the specified query.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<WhippetViewPermissionEntry>> Handle(TQuery query)
        {
            return Task.Run(() => HandleAsync(query)).Result;
        }
    }
}
