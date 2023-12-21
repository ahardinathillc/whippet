using System;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.SuperDuper.Legacy.ServiceManagers.Queries;

namespace Athi.Whippet.SuperDuper.Legacy.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetAllLegacySuperDuperAccountsQuery"/> objects.
    /// </summary>
    public class GetAllLegacySuperDuperAccountsQueryHandler : LegacySuperDuperAccountQueryHandlerBase<GetAllLegacySuperDuperAccountsQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllLegacySuperDuperAccountsQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetAllLegacySuperDuperAccountsQueryHandler(IWhippetQueryRepository<LegacySuperDuperAccount> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<LegacySuperDuperAccount>>> HandleAsync(GetAllLegacySuperDuperAccountsQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                return await ((IWhippetRepository<LegacySuperDuperAccount, int>)(Repository)).GetAllAsync();
            }
        }
    }
}
