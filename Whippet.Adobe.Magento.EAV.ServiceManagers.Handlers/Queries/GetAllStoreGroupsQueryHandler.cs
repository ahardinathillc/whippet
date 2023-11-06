using System;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.EAV.ServiceManagers.Queries;

namespace Athi.Whippet.Adobe.Magento.EAV.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetAllStoreGroupsQuery"/> objects.
    /// </summary>
    public class GetAllStoreGroupsQueryHandler : StoreGroupQueryHandlerBase<GetAllStoreGroupsQuery>, IStoreGroupQueryHandler<GetAllStoreGroupsQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllStoreGroupsQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetAllStoreGroupsQueryHandler(IWhippetQueryRepository<StoreGroup> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<StoreGroup>>> HandleAsync(GetAllStoreGroupsQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<StoreGroup>> result = await ((IMagentoRowNumberEntityRepository<StoreGroup>)(Repository)).GetAllAsync();
                return result;
            }
        }
    }
}
