using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using NodaTime;
using Athi.Whippet;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Services;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.Security.Tenants.Extensions;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Queries;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Commands;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Handlers.Commands;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers.Handlers.Queries;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Repositories;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="IMultichannelOrderManagerOrder"/> domain objects.
    /// </summary>
    public class MultichannelOrderManagerOrderServiceManager : ServiceManager, IDisposable
    {
        /// <summary>
        /// Gets the <see cref="IMultichannelOrderManagerOrderRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IMultichannelOrderManagerOrderRepository OrderRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerOrderServiceManager"/> class with the specified <see cref="IMultichannelOrderManagerOrderItemRepository"/>.
        /// </summary>
        /// <param name="orderRepository"><see cref="IMultichannelOrderManagerOrder"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerOrderServiceManager(IMultichannelOrderManagerOrderRepository orderRepository)
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
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerOrderServiceManager"/> class with the specified <see cref="IMultichannelOrderManagerOrderRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="orderRepository"><see cref="IMultichannelOrderManagerOrderRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerOrderServiceManager(IWhippetServiceContext serviceLocator, IMultichannelOrderManagerOrderRepository orderRepository)
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
        /// Gets the total number of <see cref="MultichannelOrderManagerOrder"/> objects in the data store.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        public virtual async Task<WhippetResultContainer<long>> GetTotalOrders()
        {
            return await OrderRepository.GetOrderCountAsync();
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerOrder"/> objects that fall within the specified date range.
        /// </summary>
        /// <param name="startDate">Beginning inclusive date range to filter orders by.</param>
        /// <param name="endDate">Ending inclusive date range to filter orders by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerOrder>>> GetOrders(Instant startDate, Instant endDate)
        {
            if (endDate < startDate)
            {
                throw new ArgumentException(null, nameof(endDate));
            }
            else
            {
                IMultichannelOrderManagerOrderQueryHandler<GetMultichannelOrderManagerOrdersByDateRangeQuery> handler = new GetMultichannelOrderManagerOrdersByDateRangeQueryHandler(OrderRepository);
                WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>> result = await handler.HandleAsync(new GetMultichannelOrderManagerOrdersByDateRangeQuery(startDate, endDate));
                return new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerOrder>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerOrder"/> objects that fall within the specified date range and have a <see cref="MultichannelOrderManagerOrder.IsQuote"/> value of <see langword="true"/>.
        /// </summary>
        /// <param name="startDate">Beginning inclusive date range to filter orders by.</param>
        /// <param name="endDate">Ending inclusive date range to filter orders by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerOrder>>> GetQuotes(Instant startDate, Instant endDate)
        {
            if (endDate < startDate)
            {
                throw new ArgumentException(null, nameof(endDate));
            }
            else
            {
                IMultichannelOrderManagerOrderQueryHandler<GetMultichannelOrderManagerQuotesByDateRangeQuery> handler = new GetMultichannelOrderManagerQuotesByDateRangeQueryHandler(OrderRepository);
                WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>> result = await handler.HandleAsync(new GetMultichannelOrderManagerQuotesByDateRangeQuery(startDate, endDate));
                return new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerOrder>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerOrder"/> objects for a specific <see cref="IMultichannelOrderManagerCustomer"/> and have a <see cref="MultichannelOrderManagerOrder.IsQuote"/> value of <see langword="true"/>.
        /// </summary>
        /// <param name="customer"><see cref="IMultichannelOrderManagerCustomer"/> object to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerOrder>>> GetQuotes(IMultichannelOrderManagerCustomer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            else
            {
                IMultichannelOrderManagerOrderQueryHandler<GetMultichannelOrderManagerQuotesByCustomerQuery> handler = new GetMultichannelOrderManagerQuotesByCustomerQueryHandler(OrderRepository);
                WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>> result = await handler.HandleAsync(new GetMultichannelOrderManagerQuotesByCustomerQuery(customer.ToMultichannelOrderManagerCustomer()));
                return new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerOrder>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerOrder"/> objects for a specific <see cref="IMultichannelOrderManagerCustomer"/> and have a <see cref="MultichannelOrderManagerOrder.IsQuote"/> value of <see langword="true"/>.
        /// </summary>
        /// <param name="quoteNumbers"><see cref="IEnumerable{T}"/> collection of quote numbers to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerOrder>>> GetQuotes(IEnumerable<long> quoteNumbers)
        {
            if (quoteNumbers == null || !quoteNumbers.Any())
            {
                throw new ArgumentNullException(nameof(quoteNumbers));
            }
            else
            {
                IMultichannelOrderManagerOrderQueryHandler<GetMultichannelOrderManagerQuotesByIdsQuery> handler = new GetMultichannelOrderManagerQuotesByIdsQueryHandler(OrderRepository);
                WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>> result = await handler.HandleAsync(new GetMultichannelOrderManagerQuotesByIdsQuery(quoteNumbers));
                return new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerOrder>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerOrder"/> objects that fall within the specified <see cref="MultichannelOrderManagerOrder.OrderNumber"/> range.
        /// </summary>
        /// <param name="lowerOrderId">Inclusive lower range of the <see cref="MultichannelOrderManagerOrder.OrderNumber"/> to filter by.</param>
        /// <param name="upperOrderId">Inclusive upper range of the <see cref="MultichannelOrderManagerOrder.OrderNumber"/> to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerOrder>>> GetOrders(long lowerOrderId, long upperOrderId)
        {
            if (upperOrderId < lowerOrderId)
            {
                throw new ArgumentException(null, nameof(upperOrderId));
            }
            else
            {
                IMultichannelOrderManagerOrderQueryHandler<GetMultichannelOrderManagerOrdersQuery> handler = new GetMultichannelOrderManagerOrdersQueryHandler(OrderRepository);
                WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>> result = await handler.HandleAsync(new GetMultichannelOrderManagerOrdersQuery(lowerOrderId, upperOrderId));
                return new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerOrder>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerOrder"/> objects for a specific <see cref="IMultichannelOrderManagerCustomer"/>.
        /// </summary>
        /// <param name="customer"><see cref="IMultichannelOrderManagerCustomer"/> object to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerOrder>>> GetOrders(IMultichannelOrderManagerCustomer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            else
            {
                IMultichannelOrderManagerOrderQueryHandler<GetMultichannelOrderManagerOrdersByCustomerQuery> handler = new GetMultichannelOrderManagerOrdersByCustomerQueryHandler(OrderRepository);
                WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>> result = await handler.HandleAsync(new GetMultichannelOrderManagerOrdersByCustomerQuery(customer.ToMultichannelOrderManagerCustomer()));
                return new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerOrder>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerOrder"/> objects that fall within the specified <see cref="MultichannelOrderManagerOrder.OrderNumber"/> range and have a <see cref="MultichannelOrderManagerOrder.IsQuote"/> value of <see langword="true"/>.
        /// </summary>
        /// <param name="lowerOrderId">Inclusive lower range of the <see cref="MultichannelOrderManagerOrder.OrderNumber"/> to filter by.</param>
        /// <param name="upperOrderId">Inclusive upper range of the <see cref="MultichannelOrderManagerOrder.OrderNumber"/> to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerOrder>>> GetQuotes(long lowerOrderId, long upperOrderId)
        {
            WhippetResultContainer<IEnumerable<IMultichannelOrderManagerOrder>> orders = await GetOrders(lowerOrderId, upperOrderId);

            if (orders.IsSuccess && orders.HasItem)
            {
                orders = new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerOrder>>(orders.Result, orders.Item.Where(o => o.IsQuote));
            }

            return orders;
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerOrder"/> objects for a specific <see cref="IMultichannelOrderManagerCustomer"/> and have a <see cref="MultichannelOrderManagerOrder.IsQuote"/> value of <see langword="false"/>.
        /// </summary>
        /// <param name="quoteNumbers"><see cref="IEnumerable{T}"/> collection of order numbers to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<IMultichannelOrderManagerOrder>>> GetOrders(IEnumerable<long> quoteNumbers)
        {
            if (quoteNumbers == null || !quoteNumbers.Any())
            {
                throw new ArgumentNullException(nameof(quoteNumbers));
            }
            else
            {
                IMultichannelOrderManagerOrderQueryHandler<GetMultichannelOrderManagerOrdersByIdsQuery> handler = new GetMultichannelOrderManagerOrdersByIdsQueryHandler(OrderRepository);
                WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>> result = await handler.HandleAsync(new GetMultichannelOrderManagerOrdersByIdsQuery(quoteNumbers));
                return new WhippetResultContainer<IEnumerable<IMultichannelOrderManagerOrder>>(result.Result, result.Item);
            }
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
