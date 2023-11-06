using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.ServiceManagers.Queries;

namespace Athi.Whippet.Adobe.Magento.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetAllMagentoServersQuery"/> objects.
    /// </summary>
    public class GetAllMagentoServersQueryHandler : MagentoServerQueryHandlerBase<GetAllMagentoServersQuery>, IMagentoServerQueryHandler<GetAllMagentoServersQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllMagentoServersQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetAllMagentoServersQueryHandler(IWhippetQueryRepository<MagentoServer> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<MagentoServer>>> HandleAsync(GetAllMagentoServersQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<MagentoServer>> queryResult = await Repository.GetAllAsync();
                return queryResult;
            }
        }
    }
}
