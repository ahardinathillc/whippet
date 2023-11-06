using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.ServiceManagers.Queries;

namespace Athi.Whippet.Adobe.Magento.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetMagentoRestEndpointByIdQuery"/> objects.
    /// </summary>
    public class GetMagentoRestEndpointByIdQueryHandler : MagentoRestEndpointQueryHandlerBase<GetMagentoRestEndpointByIdQuery>, IMagentoRestEndpointQueryHandler<GetMagentoRestEndpointByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMagentoRestEndpointByIdQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetMagentoRestEndpointByIdQueryHandler(IWhippetQueryRepository<MagentoRestEndpoint> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<MagentoRestEndpoint>>> HandleAsync(GetMagentoRestEndpointByIdQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<MagentoRestEndpoint> queryResult = await Repository.GetAsync(query.ID);
                return queryResult.ToEnumerableResult();
            }
        }
    }
}
