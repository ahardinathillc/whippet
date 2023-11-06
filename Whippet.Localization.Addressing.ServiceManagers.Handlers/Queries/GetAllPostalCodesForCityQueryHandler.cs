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
    /// Query handler for <see cref="GetAllPostalCodesForCityQuery"/> objects.
    /// </summary>
    public class GetAllPostalCodesForCityQueryHandler : PostalCodeQueryHandlerBase<GetAllPostalCodesForCityQuery>, IPostalCodeQueryHandler<GetAllPostalCodesForCityQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllPostalCodesForCityQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetAllPostalCodesForCityQueryHandler(IWhippetQueryRepository<PostalCode> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<PostalCode>>> HandleAsync(GetAllPostalCodesForCityQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<PostalCode>> queryResult = await Repository.GetAsync(query.City);
                return new WhippetResultContainer<IEnumerable<PostalCode>>(queryResult.Result, queryResult.Item);
            }
        }
    }
}
