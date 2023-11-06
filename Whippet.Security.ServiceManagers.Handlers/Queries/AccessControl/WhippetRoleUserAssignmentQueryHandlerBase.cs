using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.AccessControl.Repositories;

namespace Athi.Whippet.Security.AccessControl.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Base class for all <see cref="IWhippetQuery{TEntity}"/> handlers. This class must be inherited.
    /// </summary>
    /// <typeparam name="TQuery">Type of query the handler intercepts.</typeparam>
    public abstract class WhippetRoleUserAssignmentQueryHandlerBase<TQuery> : WhippetQueryHandler<WhippetRoleUserAssignment>, IWhippetQueryHandler<TQuery, WhippetRoleUserAssignment>, IWhippetRoleUserAssignmentQueryHandler<TQuery>
        where TQuery : IWhippetQuery<WhippetRoleUserAssignment>
    {
        /// <summary>
        /// Gets the <see cref="IWhippetRoleUserAssignmentRepository"/> that the queries are executed against. This property is read-only.
        /// </summary>
        protected new IWhippetRoleUserAssignmentRepository Repository
        {
            get
            {
                return base.Repository as IWhippetRoleUserAssignmentRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetRoleUserAssignmentQueryHandlerBase{TQuery}"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        protected WhippetRoleUserAssignmentQueryHandlerBase(IWhippetQueryRepository<WhippetRoleUserAssignment> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously. This method must be overridden.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public abstract Task<WhippetResultContainer<IEnumerable<WhippetRoleUserAssignment>>> HandleAsync(TQuery query);

        /// <summary>
        /// Handles the specified query.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<WhippetRoleUserAssignment>> Handle(TQuery query)
        {
            return Task.Run(() => HandleAsync(query)).Result;
        }
    }
}
