using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Extensions.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Queries;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetMultichannelOrderManagerCustomersActiveOnlyQuery"/> objects.
    /// </summary>
    public class GetMultichannelOrderManagerCustomersActiveOnlyQueryHandler : MultichannelOrderManagerCustomerQueryHandlerBase<GetMultichannelOrderManagerCustomersActiveOnlyQuery>, IMultichannelOrderManagerCustomerQueryHandler<GetMultichannelOrderManagerCustomersActiveOnlyQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerCustomersActiveOnlyQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetMultichannelOrderManagerCustomersActiveOnlyQueryHandler(IWhippetQueryRepository<MultichannelOrderManagerCustomer> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>> HandleAsync(GetMultichannelOrderManagerCustomersActiveOnlyQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>> result = query.CustomerNumbersOnly ? await Repository.GetActiveCustomerNumbersAsync(query.FromDate, query.ToDate) : await Repository.GetActiveCustomersAsync(query.FromDate, query.ToDate);
                return new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>(result.Result, result.Item);
            }
        }
    }
}
