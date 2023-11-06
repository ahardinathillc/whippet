using System;
using Athi.Whippet.Applications.Setup.ServiceManagers.Queries;
using Athi.Whippet;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Applications.Setup.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetWhippetApplicationsByTenantQuery"/> objects.
    /// </summary>
    public class GetWhippetApplicationsByTenantQueryHandler : WhippetApplicationQueryHandlerBase<GetWhippetApplicationsByTenantQuery>, IWhippetApplicationQueryHandler<GetWhippetApplicationsByTenantQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetApplicationsByTenantQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetWhippetApplicationsByTenantQueryHandler(IWhippetQueryRepository<WhippetApplication> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<WhippetApplication>>> HandleAsync(GetWhippetApplicationsByTenantQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<WhippetApplication>> queryResult = await Repository.GetApplicationsForTenantAsync(query.Tenant);
                return new WhippetResultContainer<IEnumerable<WhippetApplication>>(queryResult.Result, queryResult.Item);
            }
        }
    }
}

