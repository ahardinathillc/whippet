using System;
using FluentNHibernate.Data;
using NodaTime;
using Athi.Whippet;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="MultichannelOrderManagerOrder"/> entity objects.
    /// </summary>
    public interface IMultichannelOrderManagerOrderRepository : IWhippetEntityRepository<MultichannelOrderManagerOrder, long>, IWhippetQueryRepository<MultichannelOrderManagerOrder>, IWhippetExternalQueryRepository<MultichannelOrderManagerOrder, long>
    {
        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerOrder"/> objects for the specified date range.
        /// </summary>
        /// <param name="fromDateTimeUTC">From date/time range.</param>
        /// <param name="toDateTimeUTC">To date/time range.</param>
        /// <param name="includeQuotes">If <see langword="true"/>, orders that are marked as quotes will be included.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>> GetOrdersForDateRange(Instant fromDateTimeUTC, Instant toDateTimeUTC, bool includeQuotes);

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerOrder"/> objects for the specified date range.
        /// </summary>
        /// <param name="fromDateTimeUTC">From date/time range.</param>
        /// <param name="toDateTimeUTC">To date/time range.</param>
        /// <param name="includeQuotes">If <see langword="true"/>, orders that are marked as quotes will be included.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>>> GetOrdersForDateRangeAsync(Instant fromDateTimeUTC, Instant toDateTimeUTC, bool includeQuotes, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerOrder"/> objects for the specified date range that are indicated as quotes (<see cref="MultichannelOrderManagerOrder.IsQuote"/> value is <see langword="true"/>).
        /// </summary>
        /// <param name="fromDateTimeUTC">From date/time range.</param>
        /// <param name="toDateTimeUTC">To date/time range.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>> GetQuotesForDateRange(Instant fromDateTimeUTC, Instant toDateTimeUTC);

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerOrder"/> objects for the specified date range that are indicated as quotes (<see cref="MultichannelOrderManagerOrder.IsQuote"/> value is <see langword="true"/>).
        /// </summary>
        /// <param name="fromDateTimeUTC">From date/time range.</param>
        /// <param name="toDateTimeUTC">To date/time range.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>>> GetQuotesForDateRangeAsync(Instant fromDateTimeUTC, Instant toDateTimeUTC, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerOrder"/> objects for the specified order range.
        /// </summary>
        /// <param name="orderIdStart">The lower order ID inclusive value to start.</param>
        /// <param name="orderIdEnd">The upper order ID inclusive value to stop.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>> GetOrders(long orderIdStart, long orderIdEnd);

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerOrder"/> objects for the specified order range.
        /// </summary>
        /// <param name="orderIdStart">The lower order ID inclusive value to start.</param>
        /// <param name="orderIdEnd">The upper order ID inclusive value to stop.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>>> GetOrdersAsync(long orderIdStart, long orderIdEnd, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerOrder"/> objects based on the specified <see cref="IMultichannelOrderManagerOrder.OrderNumber"/> values.
        /// </summary>
        /// <param name="orderIds"><see cref="IEnumerable{T}"/> collection of <see cref="IMultichannelOrderManagerOrder.OrderNumber"/> values.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>> GetOrders(IEnumerable<long> orderIds);

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerOrder"/> objects based on the specified <see cref="IMultichannelOrderManagerOrder.OrderNumber"/> values.
        /// </summary>
        /// <param name="orderIds"><see cref="IEnumerable{T}"/> collection of <see cref="IMultichannelOrderManagerOrder.OrderNumber"/> values.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>>> GetOrdersAsync(IEnumerable<long> orderIds, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets the total number of orders in the data store.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        WhippetResultContainer<long> GetOrderCount();

        /// <summary>
        /// Gets the total number of orders in the data store.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        Task<WhippetResultContainer<long>> GetOrderCountAsync(CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerOrder"/> objects for the specified <see cref="IMultichannelOrderManagerCustomer"/>.
        /// </summary>
        /// <param name="customer"><see cref="IMultichannelOrderManagerCustomer"/> to retrieve orders for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>> GetOrdersForCustomer(IMultichannelOrderManagerCustomer customer);

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerOrder"/> objects for the specified <see cref="IMultichannelOrderManagerCustomer"/>.
        /// </summary>
        /// <param name="customer"><see cref="IMultichannelOrderManagerCustomer"/> to retrieve orders for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>>> GetOrdersForCustomerAsync(IMultichannelOrderManagerCustomer customer, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerOrder"/> objects for the specified <see cref="IMultichannelOrderManagerCustomer"/> that are indicated as quotes (<see cref="MultichannelOrderManagerOrder.IsQuote"/> value is <see langword="true"/>).
        /// </summary>
        /// <param name="customer"><see cref="IMultichannelOrderManagerCustomer"/> to retrieve quotes for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>> GetQuotesForCustomer(IMultichannelOrderManagerCustomer customer);

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerOrder"/> objects for the specified <see cref="IMultichannelOrderManagerCustomer"/> that are indicated as quotes (<see cref="MultichannelOrderManagerOrder.IsQuote"/> value is <see langword="true"/>).
        /// </summary>
        /// <param name="customer"><see cref="IMultichannelOrderManagerCustomer"/> to retrieve quotes for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>>> GetQuotesForCustomerAsync(IMultichannelOrderManagerCustomer customer, CancellationToken? cancellationToken = null);
    }
}
