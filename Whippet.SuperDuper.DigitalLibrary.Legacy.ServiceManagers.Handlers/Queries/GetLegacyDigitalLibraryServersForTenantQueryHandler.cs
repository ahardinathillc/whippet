using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.ServiceManagers.Queries;

namespace Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetLegacyDigitalLibraryServersForTenantQuery"/> objects.
    /// </summary>
    public class GetLegacyDigitalLibraryServersForTenantQueryHandler : LegacyDigitalLibraryServerQueryHandlerBase<GetLegacyDigitalLibraryServersForTenantQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetLegacyDigitalLibraryServersForTenantQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetLegacyDigitalLibraryServersForTenantQueryHandler(IWhippetQueryRepository<LegacyDigitalLibraryServer> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<LegacyDigitalLibraryServer>>> HandleAsync(GetLegacyDigitalLibraryServersForTenantQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<LegacyDigitalLibraryServer>> queryResult = await Repository.GetAllAsync(query.Tenant);
                return new WhippetResultContainer<IEnumerable<LegacyDigitalLibraryServer>>(queryResult.Result, queryResult.Item);
            }
        }
    }
}
