using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Localization.Addressing.ServiceManagers.Queries;

namespace Athi.Whippet.Localization.Addressing.ServiceManagers.Handlers.Queries
{
    public class GetStateProvinceByIdQueryHandler : StateProvinceQueryHandlerBase<GetStateProvinceByIdQuery>, IStateProvinceQueryHandler<GetStateProvinceByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetStateProvinceByIdQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetStateProvinceByIdQueryHandler(IWhippetQueryRepository<StateProvince> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<StateProvince>>> HandleAsync(GetStateProvinceByIdQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<StateProvince> queryResult = await Repository.GetAsync(query.ID);
                return new WhippetResultContainer<IEnumerable<StateProvince>>(queryResult.Result, new[] { queryResult.Item });
            }
        }
    }
}
