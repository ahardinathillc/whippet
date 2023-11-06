using System;
using Athi.Whippet.Applications.Setup.ServiceManagers.Queries;
using Athi.Whippet;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Applications.Setup.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetWhippetSettingByIdQuery"/> objects.
    /// </summary>
    public class GetWhippetSettingByIdQueryHandler : WhippetSettingQueryHandlerBase<GetWhippetSettingByIdQuery>, IWhippetSettingQueryHandler<GetWhippetSettingByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetSettingByIdQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetWhippetSettingByIdQueryHandler(IWhippetQueryRepository<WhippetSetting> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<WhippetSetting>>> HandleAsync(GetWhippetSettingByIdQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<WhippetSetting> queryResult = await ((IWhippetExternalQueryRepository<WhippetSetting, int>)(Repository)).GetAsync(query.ID);
                return new WhippetResultContainer<IEnumerable<WhippetSetting>>(queryResult.Result, new[] { queryResult.Item });
            }
        }
    }
}

