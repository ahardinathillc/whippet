using System;
using Athi.Whippet.Applications.Setup.ServiceManagers.Queries;
using Athi.Whippet;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Applications.Setup.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetWhippetApplicationByIdQuery"/> objects.
    /// </summary>
    public class GetWhippetApplicationByIdQueryHandler : WhippetApplicationQueryHandlerBase<GetWhippetApplicationByIdQuery>, IWhippetApplicationQueryHandler<GetWhippetApplicationByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetApplicationByIdQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetWhippetApplicationByIdQueryHandler(IWhippetQueryRepository<WhippetApplication> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<WhippetApplication>>> HandleAsync(GetWhippetApplicationByIdQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<WhippetApplication> queryResult = await ((IWhippetExternalQueryRepository<WhippetApplication, int>)(Repository)).GetAsync(query.ID);
                return new WhippetResultContainer<IEnumerable<WhippetApplication>>(queryResult.Result, new[] { queryResult.Item });
            }
        }
    }
}

