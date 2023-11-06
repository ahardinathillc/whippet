using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Extensions.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Security.Tenants.ServiceManagers.Queries;

namespace Athi.Whippet.Security.Tenants.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Handles all <see cref="GetWhippetUserTenantAssignmentsForUserQuery"/> objects.
    /// </summary>
    public class GetWhippetUserTenantAssignmentsForUserQueryHandler : WhippetUserTenantAssignmentQueryHandlerBase<GetWhippetUserTenantAssignmentsForUserQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetUserTenantAssignmentsForUserQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetWhippetUserTenantAssignmentsForUserQueryHandler(IWhippetQueryRepository<WhippetUserTenantAssignment> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<WhippetUserTenantAssignment>>> HandleAsync(GetWhippetUserTenantAssignmentsForUserQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<WhippetUserTenantAssignment>> queryResult = await Repository.GetAsync(query.User);
                return new WhippetResultContainer<IEnumerable<WhippetUserTenantAssignment>>(queryResult.Result, queryResult.Item);
            }
        }
    }
}
