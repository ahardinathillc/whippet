using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.Sales.ServiceManagers.Queries;

namespace Athi.Whippet.Adobe.Magento.Sales.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetSalesOrdersForDateRangeQuery"/> objects.
    /// </summary>
    public class GetSalesOrdersForDateRangeQueryHandler : SalesOrderQueryHandlerBase<GetSalesOrdersForDateRangeQuery>, ISalesOrderQueryHandler<GetSalesOrdersForDateRangeQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesOrdersForDateRangeQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetSalesOrdersForDateRangeQueryHandler(IWhippetQueryRepository<SalesOrder> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<SalesOrder>>> HandleAsync(GetSalesOrdersForDateRangeQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<SalesOrder>> result = await Repository.GetAsync(query.FromDate, query.ToDate);
                return result;
            }
        }
    }
}
