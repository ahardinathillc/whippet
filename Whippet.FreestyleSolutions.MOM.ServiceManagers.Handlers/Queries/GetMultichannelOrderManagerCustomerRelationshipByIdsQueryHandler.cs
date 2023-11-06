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
    /// Query handler for <see cref="GetMultichannelOrderManagerCustomerRelationshipsByIdsQuery"/> objects.
    /// </summary>
    public class GetMultichannelOrderManagerCustomerRelationshipsByIdsQueryHandler : MultichannelOrderManagerCustomerRelationshipQueryHandlerBase<GetMultichannelOrderManagerCustomerRelationshipsByIdsQuery>, IMultichannelOrderManagerCustomerRelationshipQueryHandler<GetMultichannelOrderManagerCustomerRelationshipsByIdsQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMultichannelOrderManagerCustomerRelationshipsByIdsQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetMultichannelOrderManagerCustomerRelationshipsByIdsQueryHandler(IWhippetQueryRepository<MultichannelOrderManagerCustomerRelationship> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomerRelationship>>> HandleAsync(GetMultichannelOrderManagerCustomerRelationshipsByIdsQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomerRelationship>> result = await Repository.GetCustomerRelationshipsAsync(query.IDs);
                return new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomerRelationship>>(result.Result, result.Item);
            }
        }
    }
}
