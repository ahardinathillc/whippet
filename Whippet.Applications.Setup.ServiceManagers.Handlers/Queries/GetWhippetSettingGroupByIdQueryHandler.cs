using System;
using Athi.Whippet.Applications.Setup.ServiceManagers.Queries;
using Athi.Whippet;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Applications.Setup.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetWhippetSettingGroupByIdQuery"/> objects.
    /// </summary>
    public class GetWhippetSettingGroupByIdQueryHandler : WhippetSettingGroupQueryHandlerBase<GetWhippetSettingGroupByIdQuery>, IWhippetSettingGroupQueryHandler<GetWhippetSettingGroupByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetSettingGroupByIdQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetWhippetSettingGroupByIdQueryHandler(IWhippetQueryRepository<WhippetSettingGroup> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<WhippetSettingGroup>>> HandleAsync(GetWhippetSettingGroupByIdQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<WhippetSettingGroup> queryResult = await ((IWhippetExternalQueryRepository<WhippetSettingGroup, int>)(Repository)).GetAsync(query.ID);
                return new WhippetResultContainer<IEnumerable<WhippetSettingGroup>>(queryResult.Result, new[] { queryResult.Item });
            }
        }
    }
}

