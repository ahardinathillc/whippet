using System;
using Athi.Whippet.Applications.Setup.ServiceManagers.Queries;
using Athi.Whippet;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Applications.Setup.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetWhippetApplicationByApplicationIdQuery"/> objects.
    /// </summary>
    public class GetWhippetApplicationByApplicationIdQueryHandler : WhippetApplicationQueryHandlerBase<GetWhippetApplicationByApplicationIdQuery>, IWhippetApplicationQueryHandler<GetWhippetApplicationByApplicationIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetApplicationByApplicationIdQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetWhippetApplicationByApplicationIdQueryHandler(IWhippetQueryRepository<WhippetApplication> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<WhippetApplication>>> HandleAsync(GetWhippetApplicationByApplicationIdQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<WhippetApplication> queryResult = await Repository.GetAsync(query.ApplicationID, query.Tenant);
                return new WhippetResultContainer<IEnumerable<WhippetApplication>>(queryResult.Result, new[] { queryResult.Item });
            }
        }
    }
}

