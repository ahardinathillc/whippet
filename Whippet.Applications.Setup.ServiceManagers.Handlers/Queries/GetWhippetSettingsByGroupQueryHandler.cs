using System;
using Athi.Whippet.Applications.Setup.ServiceManagers.Queries;
using Athi.Whippet;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Applications.Setup.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetWhippetSettingsByGroupQuery"/> objects.
    /// </summary>
    public class GetWhippetSettingsByGroupQueryHandler : WhippetSettingQueryHandlerBase<GetWhippetSettingsByGroupQuery>, IWhippetSettingQueryHandler<GetWhippetSettingsByGroupQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetWhippetSettingsByGroupQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetWhippetSettingsByGroupQueryHandler(IWhippetQueryRepository<WhippetSetting> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<WhippetSetting>>> HandleAsync(GetWhippetSettingsByGroupQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<WhippetSetting>> queryResult = await Repository.GetSettingsForGroupAsync(query.Group);
                return new WhippetResultContainer<IEnumerable<WhippetSetting>>(queryResult.Result, queryResult.Item);
            }
        }
    }
}

