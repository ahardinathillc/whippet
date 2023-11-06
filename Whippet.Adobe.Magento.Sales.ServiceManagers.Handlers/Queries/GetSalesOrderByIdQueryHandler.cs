using System;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Adobe.Magento.Sales.ServiceManagers.Queries;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Sales.ServiceManagers.Handlers.Queries
{
    /// <summary>
    /// Query handler for <see cref="GetSalesOrderByIdQuery"/> objects.
    /// </summary>
    public class GetSalesOrderByIdQueryHandler : SalesOrderQueryHandlerBase<GetSalesOrderByIdQuery>, ISalesOrderQueryHandler<GetSalesOrderByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesOrderByIdQueryHandler"/> class with the specified <see cref="IWhippetQueryRepository{TEntity}"/>.
        /// </summary>
        /// <param name="repository"><see cref="IWhippetQueryRepository{TEntity}"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException" />
        public GetSalesOrderByIdQueryHandler(IWhippetQueryRepository<SalesOrder> repository)
            : base(repository)
        { }

        /// <summary>
        /// Handles the specified query asynchronously.
        /// </summary>
        /// <param name="query"><see cref="IWhippetQuery{TEntity}"/> object to handle.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public override async Task<WhippetResultContainer<IEnumerable<SalesOrder>>> HandleAsync(GetSalesOrderByIdQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            else
            {
                WhippetResultContainer<SalesOrder> result = await ((IWhippetExternalQueryRepository<SalesOrder, uint>)(Repository)).GetAsync(query.OrderID);
                return result.ToEnumerableResult();
            }
        }
    }
}
