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
    /// Query handler for <see cref="GetInvariantAddressQuery"/> objects.
    /// </summary>
    public class GetInvariantAddressQueryHandler : InvariantAddressQueryHandlerBase<GetInvariantAddressQuery>, IInvariantAddressQueryHandler<GetInvariantAddressQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetInvariantAddressQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetInvariantAddressQueryHandler(IWhippetQueryRepository<InvariantAddress> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<InvariantAddress>>> HandleAsync(GetInvariantAddressQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<InvariantAddress> queryResult = await Repository.GetAsync(query.Address.LineOne, query.Address.LineTwo, query.Address.LineThree, query.Address.LineFour, query.Address.City, query.Address.PostalCode);
                return new WhippetResultContainer<IEnumerable<InvariantAddress>>(queryResult.Result, new[] { queryResult.Item });
            }
        }
    }
}
