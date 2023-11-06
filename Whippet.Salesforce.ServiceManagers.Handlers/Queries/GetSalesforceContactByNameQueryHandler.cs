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
    /// Query handler for <see cref="GetSalesforceContactByNameQuery"/> objects.
    /// </summary>
    public class GetSalesforceContactByNameQueryHandler : SalesforceContactQueryHandlerBase<GetSalesforceContactByNameQuery>, ISalesforceContactQueryHandler<GetSalesforceContactByNameQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesforceContactByNameQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetSalesforceContactByNameQueryHandler(IWhippetQueryRepository<SalesforceContact> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<SalesforceContact>>> HandleAsync(GetSalesforceContactByNameQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<SalesforceContact>> queryResult = await Repository.GetByNameAsync(query.Account, query.FirstName, query.LastName);
                return new WhippetResultContainer<IEnumerable<SalesforceContact>>(queryResult.Result, queryResult.Item);
            }
        }
    }
}
