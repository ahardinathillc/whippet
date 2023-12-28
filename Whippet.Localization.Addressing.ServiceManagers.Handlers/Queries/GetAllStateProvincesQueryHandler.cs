using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Localization.Addressing.ServiceManagers.Queries;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetAllStateProvincesQuery"/> objects.
    /// </summary>
    public class GetAllStateProvincesQueryHandler : StateProvinceQueryHandlerBase<GetAllStateProvincesQuery>, IStateProvinceQueryHandler<GetAllStateProvincesQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllStateProvincesQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetAllStateProvincesQueryHandler(IWhippetQueryRepository<StateProvince> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<StateProvince>>> HandleAsync(GetAllStateProvincesQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<StateProvince>> queryResult = await Repository.GetAllAsync();
                return new WhippetResultContainer<IEnumerable<StateProvince>>(queryResult.Result, queryResult.Item);
            }
        }
    }
}
