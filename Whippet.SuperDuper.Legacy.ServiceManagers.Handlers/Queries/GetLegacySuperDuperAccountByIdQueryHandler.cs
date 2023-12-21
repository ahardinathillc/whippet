using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.SuperDuper.Legacy.ServiceManagers.Queries;

namespace Athi.Whippet.SuperDuper.Legacy.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetLegacySuperDuperAccountByIdQuery"/> objects.
    /// </summary>
    public class GetLegacySuperDuperAccountByIdQueryHandler : LegacySuperDuperAccountQueryHandlerBase<GetLegacySuperDuperAccountByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetLegacySuperDuperAccountByIdQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetLegacySuperDuperAccountByIdQueryHandler(IWhippetQueryRepository<LegacySuperDuperAccount> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<LegacySuperDuperAccount>>> HandleAsync(GetLegacySuperDuperAccountByIdQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<LegacySuperDuperAccount> queryResult = await Repository.GetAsync(query.ID);
                return new WhippetResultContainer<IEnumerable<LegacySuperDuperAccount>>(queryResult.Result, new[] { queryResult.Item });
            }
        }
    }
}
