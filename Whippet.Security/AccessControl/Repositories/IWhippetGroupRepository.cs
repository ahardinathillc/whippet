using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Criterion;
using Athi.Whippet.Data;
using Athi.Whippet.Security.AccessControl;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Security.AccessControl.Repositories
{
    /// <summary>
    /// Repository for <see cref="WhippetGroup"/> objects.
    /// </summary>
    public interface IWhippetGroupRepository : IWhippetEntityRepository<WhippetGroup, Guid>, IWhippetQueryRepository<WhippetGroup>
    {
        /// <summary>
        /// Gets the specified group based on its name.
        /// </summary>
        /// <param name="groupName">Name of the group to retrieve.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to search for the group in.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<WhippetGroup> GetByName(string groupName, IWhippetTenant tenant);

        /// <summary>
        /// Asynchronously gets the specified group based on its name.
        /// </summary>
        /// <param name="groupName">Name of the group to retrieve.</param>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to search for the group in.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<WhippetGroup>> GetByNameAsync(string groupName, IWhippetTenant tenant, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets all groups for the specified tenant.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to list the groups for.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<WhippetGroup>> GetByTenant(IWhippetTenant tenant);

        /// <summary>
        /// Asynchronously gets all groups for the specified tenant.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> to list the groups for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<WhippetGroup>>> GetByTenantAsync(IWhippetTenant tenant, CancellationToken? cancellationToken = null);
    }
}
