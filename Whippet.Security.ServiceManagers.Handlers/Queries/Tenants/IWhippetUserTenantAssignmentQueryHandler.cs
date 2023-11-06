using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Security.Tenants.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Handles queries against <see cref="WhippetUserTenantAssignment"/> objects.
    /// </summary>
    /// <typeparam name="TQuery"><see cref="IWhippetQuery{TEntity}"/> type to handle.</typeparam>
    public interface IWhippetUserTenantAssignmentQueryHandler<TQuery> : IWhippetQueryHandler<TQuery, WhippetUserTenantAssignment> where TQuery : IWhippetQuery<WhippetUserTenantAssignment>
    { }
}
