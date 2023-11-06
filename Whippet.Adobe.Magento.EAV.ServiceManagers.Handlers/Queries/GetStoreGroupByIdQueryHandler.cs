using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.EAV.ServiceManagers.Queries;

namespace Athi.Whippet.Adobe.Magento.EAV.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetStoreGroupByIdQuery"/> objects.
    /// </summary>
    public class GetStoreGroupByIdQueryHandler : StoreGroupQueryHandlerBase<GetStoreGroupByIdQuery>, IStoreGroupQueryHandler<GetStoreGroupByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetStoreGroupByIdQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetStoreGroupByIdQueryHandler(IWhippetQueryRepository<StoreGroup> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<StoreGroup>>> HandleAsync(GetStoreGroupByIdQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<StoreGroup> result = await ((IWhippetExternalQueryRepository<StoreGroup, uint>)(Repository)).GetAsync(query.GroupID);
                return result.ToEnumerableResult();
            }
        }
    }
}
