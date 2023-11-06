using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet;
using Athi.Whippet.Applications.Setup.Repositories;

namespace Athi.Whippet.Applications.Setup.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Base class for all <see cref="IWhippetQuery{TEntity}"/> handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TQuery">Type of query the handler intercepts.</typeparam>
    public abstract class WhippetSettingGroupQueryHandlerBase<TQuery> : WhippetQueryHandler<WhippetSettingGroup>, IWhippetQueryHandler<TQuery, WhippetSettingGroup>, IWhippetSettingGroupQueryHandler<TQuery>
        where TQuery : IWhippetQuery<WhippetSettingGroup>
    {
        /// <summary>
        /// Gets the <see cref="IWhippetSettingGroupRepository"/> that the queries are executed against. This property is read-only.
        /// </summary>
        protected new IWhippetSettingGroupRepository Repository
        {
            get
            {
                return base.Repository as IWhippetSettingGroupRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetSettingGroupQueryHandlerBase{TQuery}"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        protected WhippetSettingGroupQueryHandlerBase(IWhippetQueryRepository<WhippetSettingGroup> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously. This method must be overridden.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract Task<WhippetResultContainer<IEnumerable<WhippetSettingGroup>>> HandleAsync(TQuery query);

        /// <summary>
        /// Handles the specified query.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<WhippetSettingGroup>> Handle(TQuery query)
        {
            return Task.Run(() => HandleAsync(query)).Result;
        }
    }
}
