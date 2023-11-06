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
    /// Query handler for <see cref="GetPostalCodesQuery"/> objects.
    /// </summary>
    public class GetPostalCodesQueryHandler : PostalCodeQueryHandlerBase<GetPostalCodesQuery>, IPostalCodeQueryHandler<GetPostalCodesQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetPostalCodesQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetPostalCodesQueryHandler(IWhippetQueryRepository<PostalCode> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<PostalCode>>> HandleAsync(GetPostalCodesQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<PostalCode>> queryResult = await (query.City == null ? Repository.GetAsync(query.Value) : Repository.GetAsync(query.Value, query.City));
                return new WhippetResultContainer<IEnumerable<PostalCode>>(queryResult.Result, queryResult.Item);
            }
        }
    }
}
