using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.Sales.ServiceManagers.Queries;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Sales.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetAllSalesOrdersQuery"/> objects.
    /// </summary>
    public class GetAllSalesOrdersQueryHandler : SalesOrderQueryHandlerBase<GetAllSalesOrdersQuery>, ISalesOrderQueryHandler<GetAllSalesOrdersQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllSalesOrdersQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetAllSalesOrdersQueryHandler(IWhippetQueryRepository<SalesOrder> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<SalesOrder>>> HandleAsync(GetAllSalesOrdersQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<IEnumerable<SalesOrder>> result = await ((IWhippetExternalQueryRepository<SalesOrder, uint>)(Repository)).GetAllAsync();
                return result;
            }
        }
    }
}
