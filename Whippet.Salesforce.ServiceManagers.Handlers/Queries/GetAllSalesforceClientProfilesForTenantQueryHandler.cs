using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Extensions.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet;
using Athi.Whippet.Salesforce.ServiceManagers.Queries;

namespace Athi.Whippet.Salesforce.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetAllSalesforceClientProfilesForTenantQuery"/> objects.
    /// </summary>
    public class GetAllSalesforceClientProfilesForTenantQueryHandler : SalesforceClientProfileQueryHandlerBase<GetAllSalesforceClientProfilesForTenantQuery>, ISalesforceClientProfileQueryHandler<GetAllSalesforceClientProfilesForTenantQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllSalesforceClientProfilesForTenantQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetAllSalesforceClientProfilesForTenantQueryHandler(IWhippetQueryRepository<SalesforceClientProfile> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<SalesforceClientProfile>>> HandleAsync(GetAllSalesforceClientProfilesForTenantQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<SalesforceClientProfile>> queryResult = await Repository.GetSalesforceProfilesForTenantAsync(query.Tenant);
                return new WhippetResultContainer<IEnumerable<SalesforceClientProfile>>(queryResult.Result, queryResult.Item);
            }
        }
    }
}
