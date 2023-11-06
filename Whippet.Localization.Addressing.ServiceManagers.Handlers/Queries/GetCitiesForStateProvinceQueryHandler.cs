using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Localization.Addressing.ServiceManagers.Queries;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetCitiesForStateProvinceQuery"/> objects.
    /// </summary>
    public class GetCitiesForStateProvinceQueryHandler : CityQueryHandlerBase<GetCitiesForStateProvinceQuery>, ICityQueryHandler<GetCitiesForStateProvinceQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCitiesForStateProvinceQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetCitiesForStateProvinceQueryHandler(IWhippetQueryRepository<City> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<City>>> HandleAsync(GetCitiesForStateProvinceQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<City>> queryResult = await Repository.GetAsync(query.StateProvince);
                return new WhippetResultContainer<IEnumerable<City>>(queryResult.Result, queryResult.Item);
            }
        }
    }
}
