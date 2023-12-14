using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.ServiceManagers.Queries;

namespace Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetLegacyDigitalLibraryServerByIdQuery"/> objects.
    /// </summary>
    public class GetLegacyDigitalLibraryServerByIdQueryHandler : LegacyDigitalLibraryServerQueryHandlerBase<GetLegacyDigitalLibraryServerByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetLegacyDigitalLibraryServerByIdQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetLegacyDigitalLibraryServerByIdQueryHandler(IWhippetQueryRepository<LegacyDigitalLibraryServer> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<LegacyDigitalLibraryServer>>> HandleAsync(GetLegacyDigitalLibraryServerByIdQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<LegacyDigitalLibraryServer> queryResult = await Repository.GetAsync(query.ID);
                return new WhippetResultContainer<IEnumerable<LegacyDigitalLibraryServer>>(queryResult.Result, new[] { queryResult.Item });
            }
        }
    }
}
