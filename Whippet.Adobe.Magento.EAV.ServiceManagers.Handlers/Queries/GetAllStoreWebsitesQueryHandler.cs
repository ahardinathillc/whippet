using System;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.EAV.ServiceManagers.Queries;

namespace Athi.Whippet.Adobe.Magento.EAV.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetAllStoreWebsitesQuery"/> objects.
    /// </summary>
    public class GetAllStoreWebsitesQueryHandler : StoreWebsiteQueryHandlerBase<GetAllStoreWebsitesQuery>, IStoreWebsiteQueryHandler<GetAllStoreWebsitesQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllStoreWebsitesQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetAllStoreWebsitesQueryHandler(IWhippetQueryRepository<StoreWebsite> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<StoreWebsite>>> HandleAsync(GetAllStoreWebsitesQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<StoreWebsite>> result = await ((IMagentoRowNumberEntityRepository<StoreWebsite>)(Repository)).GetAllAsync();
                return result;
            }
        }
    }
}
