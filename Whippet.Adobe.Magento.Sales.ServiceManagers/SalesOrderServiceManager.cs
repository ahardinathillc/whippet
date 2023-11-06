using System;
using NodaTime;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Services;
using Athi.Whippet.Adobe.Magento.Sales.Repositories;
using Athi.Whippet.Adobe.Magento.Sales.ServiceManagers.Queries;
using Athi.Whippet.Adobe.Magento.Sales.ServiceManagers.Handlers.Queries;

namespace Athi.Whippet.Adobe.Magento.Sales.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="ISalesOrder"/> domain objects.
    /// </summary>
    public class SalesOrderServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="ISalesOrderRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual ISalesOrderRepository OrderRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderServiceManager"/> class with the specified <see cref="ISalesOrderRepository"/> object.
        /// </summary>
        /// <param name="orderRepository"><see cref="ISalesOrderRepository"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SalesOrderServiceManager(ISalesOrderRepository orderRepository)
            : base()
        {
            if (orderRepository == null)
            {
                throw new ArgumentNullException(nameof(orderRepository));
            }
            else
            {
                OrderRepository = orderRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesOrderServiceManager"/> class with the specified <see cref="ISalesOrderRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="orderRepository"><see cref="ISalesOrderRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SalesOrderServiceManager(IWhippetServiceContext serviceLocator, ISalesOrderRepository orderRepository)
            : base(serviceLocator)
        {
            if (orderRepository == null)
            {
                throw new ArgumentNullException(nameof(orderRepository));
            }
            else
            {
                OrderRepository = orderRepository;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="ISalesOrder"/> object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="ISalesOrder"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<ISalesOrder>> GetOrder(uint id)
        {
            ISalesOrderQueryHandler<GetSalesOrderByIdQuery> handler = new GetSalesOrderByIdQueryHandler(OrderRepository);
            WhippetResultContainer<IEnumerable<SalesOrder>> result = await handler.HandleAsync(new GetSalesOrderByIdQuery(id));
            return new WhippetResultContainer<ISalesOrder>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Retrieves all <see cref="ISalesOrder"/> objects in the system.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<ISalesOrder>>> GetAllOrders()
        {
            ISalesOrderQueryHandler<GetAllSalesOrdersQuery> handler = new GetAllSalesOrdersQueryHandler(OrderRepository);
            WhippetResultContainer<IEnumerable<SalesOrder>> result = await handler.HandleAsync(new GetAllSalesOrdersQuery());
            return new WhippetResultContainer<IEnumerable<ISalesOrder>>(result.Result, result.Item);
        }

        /// <summary>
        /// Retrieves all <see cref="ISalesOrder"/> objects for the specified date range.
        /// </summary>
        /// <param name="fromDateTime">Starting date range.</param>
        /// <param name="toDateTime">Ending date range.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<ISalesOrder>>> GetOrders(Instant fromDateTime, Instant toDateTime)
        {
            ISalesOrderQueryHandler<GetSalesOrdersForDateRangeQuery> handler = new GetSalesOrdersForDateRangeQueryHandler(OrderRepository);
            WhippetResultContainer<IEnumerable<SalesOrder>> result = await handler.HandleAsync(new GetSalesOrdersForDateRangeQuery(fromDateTime, toDateTime));
            return new WhippetResultContainer<IEnumerable<ISalesOrder>>(result.Result, result.Item);
        }

        /// <summary>
        /// Retrieves all <see cref="ISalesOrder"/> objects for the specified date range.
        /// </summary>
        /// <param name="fromDateTime">Starting date range.</param>
        /// <param name="toDateTime">Ending date range.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<ISalesOrder>>> GetOrders(DateTime fromDateTime, DateTime toDateTime)
        {
            Instant fromUtcDate = Instant.FromDateTimeUtc(new DateTime(fromDateTime.Year, fromDateTime.Month, fromDateTime.Day, 0, 0, 0, DateTimeKind.Utc));
            Instant toUtcDate = Instant.FromDateTimeUtc(new DateTime(toDateTime.Year, toDateTime.Month, toDateTime.Day, 23, 59, 59, 999,DateTimeKind.Utc));

            return await GetOrders(fromUtcDate, toUtcDate);
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (OrderRepository != null)
            {
                OrderRepository.Dispose();
                OrderRepository = null;
            }

            base.Dispose();
        }
    }
}
