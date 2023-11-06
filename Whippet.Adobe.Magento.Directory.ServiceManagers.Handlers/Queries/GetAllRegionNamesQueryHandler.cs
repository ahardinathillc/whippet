using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.Directory.ServiceManagers.Queries;

namespace Athi.Whippet.Adobe.Magento.Directory.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetAllRegionNamesQuery"/> objects.
    /// </summary>
    public class GetAllRegionNamesQueryHandler : RegionNameQueryHandlerBase<GetAllRegionNamesQuery>, IRegionNameQueryHandler<GetAllRegionNamesQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllRegionNamesQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetAllRegionNamesQueryHandler(IWhippetQueryRepository<RegionName> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<RegionName>>> HandleAsync(GetAllRegionNamesQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<RegionName>> result = await ((IWhippetExternalQueryRepository<RegionName, RegionNameKey>)(Repository)).GetAllAsync();
                return result;
            }
        }
    }
}
