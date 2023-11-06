using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.Extensions.Threading.Tasks;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet;
using Athi.Whippet.Salesforce.ServiceManagers.Queries;

namespace Athi.Whippet.Salesforce.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetAllSalesforcePriceBookEntriesForPriceBookQuery"/> objects.
    /// </summary>
    public class GetAllSalesforcePriceBookEntriesForPriceBookQueryHandler : SalesforcePriceBookEntryQueryHandlerBase<GetAllSalesforcePriceBookEntriesForPriceBookQuery>, ISalesforcePriceBookEntryQueryHandler<GetAllSalesforcePriceBookEntriesForPriceBookQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllSalesforcePriceBookEntriesForPriceBookQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetAllSalesforcePriceBookEntriesForPriceBookQueryHandler(IWhippetQueryRepository<SalesforcePriceBookEntry> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<SalesforcePriceBookEntry>>> HandleAsync(GetAllSalesforcePriceBookEntriesForPriceBookQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<SalesforcePriceBookEntry>> queryResult = await Repository.GetForPriceBookAsync(query.PricebookID);
                return new WhippetResultContainer<IEnumerable<SalesforcePriceBookEntry>>(queryResult.Result, queryResult.Item);
            }
        }
    }
}
