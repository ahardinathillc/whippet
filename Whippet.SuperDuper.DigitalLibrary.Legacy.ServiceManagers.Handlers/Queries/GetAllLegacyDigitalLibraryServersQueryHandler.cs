using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.ServiceManagers.Queries;

namespace Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetAllLegacyDigitalLibraryServersQuery"/> objects.
    /// </summary>
    public class GetAllLegacyDigitalLibraryServersQueryHandler : LegacyDigitalLibraryServerQueryHandlerBase<GetAllLegacyDigitalLibraryServersQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllLegacyDigitalLibraryServersQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetAllLegacyDigitalLibraryServersQueryHandler(IWhippetQueryRepository<LegacyDigitalLibraryServer> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<LegacyDigitalLibraryServer>>> HandleAsync(GetAllLegacyDigitalLibraryServersQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<LegacyDigitalLibraryServer>> queryResult = await Repository.GetAllAsync();
                return new WhippetResultContainer<IEnumerable<LegacyDigitalLibraryServer>>(queryResult.Result, queryResult.Item);
            }
        }
    }
}
