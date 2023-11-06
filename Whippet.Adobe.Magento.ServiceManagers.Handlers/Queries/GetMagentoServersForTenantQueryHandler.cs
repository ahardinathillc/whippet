using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.ServiceManagers.Queries;

namespace Athi.Whippet.Adobe.Magento.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetMagentoServersForTenantQuery"/> objects.
    /// </summary>
    public class GetMagentoServersForTenantQueryHandler : MagentoServerQueryHandlerBase<GetMagentoServersForTenantQuery>, IMagentoServerQueryHandler<GetMagentoServersForTenantQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMagentoServersForTenantQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetMagentoServersForTenantQueryHandler(IWhippetQueryRepository<MagentoServer> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<MagentoServer>>> HandleAsync(GetMagentoServersForTenantQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<MagentoServer>> queryResult = await Repository.GetForTenantAsync(query.Tenant);
                return queryResult;
            }
        }
    }
}
