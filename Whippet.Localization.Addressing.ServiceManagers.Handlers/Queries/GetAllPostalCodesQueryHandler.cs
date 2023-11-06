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
    /// Query handler for <see cref="GetAllPostalCodesQuery"/> objects.
    /// </summary>
    public class GetAllPostalCodesQueryHandler : PostalCodeQueryHandlerBase<GetAllPostalCodesQuery>, IPostalCodeQueryHandler<GetAllPostalCodesQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllPostalCodesQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetAllPostalCodesQueryHandler(IWhippetQueryRepository<PostalCode> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<PostalCode>>> HandleAsync(GetAllPostalCodesQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<PostalCode>> queryResult = await Repository.GetAllAsync();
                return new WhippetResultContainer<IEnumerable<PostalCode>>(queryResult.Result, queryResult.Item);
            }
        }
    }
}
