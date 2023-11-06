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
    /// Query handler for <see cref="GetSalesforceOpportunityByIdQuery"/> objects.
    /// </summary>
    public class GetSalesforceOpportunityByIdQueryHandler : SalesforceOpportunityQueryHandlerBase<GetSalesforceOpportunityByIdQuery>, ISalesforceOpportunityQueryHandler<GetSalesforceOpportunityByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesforceOpportunityByIdQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetSalesforceOpportunityByIdQueryHandler(IWhippetQueryRepository<SalesforceOpportunity> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<SalesforceOpportunity>>> HandleAsync(GetSalesforceOpportunityByIdQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<SalesforceOpportunity> queryResult = await Repository.GetAsync(query.ID);
                return new WhippetResultContainer<IEnumerable<SalesforceOpportunity>>(queryResult.Result, new[] { queryResult.Item });
            }
        }
    }
}
