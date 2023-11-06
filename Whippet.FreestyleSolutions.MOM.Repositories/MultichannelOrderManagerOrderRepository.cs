using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Data;
using System.Linq;
using NHibernate;
using NodaTime;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;
using Athi.Whippet.Data;
using Athi.Whippet.Data.Database.Microsoft.Extensions;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Repositories
{
    /// <summary>
    /// Represents a data repository for managing <see cref="MultichannelOrderManagerOrder"/> entity objects.
    /// </summary>
    public class MultichannelOrderManagerOrderRepository : MultichannelOrderManagerRepositoryBase<MultichannelOrderManagerOrder, long>, IMultichannelOrderManagerOrderRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerOrderRepository"/> class with the specified <see cref="IDbConnection"/> object.
        /// </summary>
        /// <param name="connection"><see cref="IDbConnection"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerOrderRepository(IDbConnection connection)
            : base(connection)
        { }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerOrder"/> objects for the specified date range.
        /// </summary>
        /// <param name="fromDateTimeUTC">From date/time range.</param>
        /// <param name="toDateTimeUTC">To date/time range.</param>
        /// <param name="includeQuotes">If <see langword="true"/>, orders that are marked as quotes will be included.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        public virtual WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>> GetOrdersForDateRange(Instant fromDateTimeUTC, Instant toDateTimeUTC, bool includeQuotes)
        {
            return Task.Run(() => GetOrdersForDateRangeAsync(fromDateTimeUTC, toDateTimeUTC, includeQuotes)).Result;
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerOrder"/> objects for the specified date range.
        /// </summary>
        /// <param name="server"><see cref="IMultichannelOrderManagerServer"/> object that specifies where the M.O.M. instance is hosted.</param>
        /// <param name="fromDateTimeUTC">From date/time range.</param>
        /// <param name="toDateTimeUTC">To date/time range.</param>
        /// <param name="includeQuotes">If <see langword="true"/>, orders that are marked as quotes will be included.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>>> GetOrdersForDateRangeAsync(Instant fromDateTimeUTC, Instant toDateTimeUTC, bool includeQuotes, CancellationToken? cancellationToken = null)
        {
            if (toDateTimeUTC < fromDateTimeUTC)
            {
                throw new ArgumentException(null, nameof(toDateTimeUTC));
            }
            else
            {
                QueryFactory context = null;
                Query query = null;

                WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>> result = null;

                WhippetDataRowImportMap map = InternalObject.CreateImportMap();

                IEnumerable<dynamic> results = null;

                try
                {
                    context = CreateQueryFactory<SqlServerCompiler>();
                    query = context.Query(TableName)
                        .WhereDate(map[nameof(InternalObject.OrderDate)].Column, ">=", fromDateTimeUTC.ToSqlServerUtcDate())
                        .WhereDate(map[nameof(InternalObject.OrderDate)].Column, "<=", toDateTimeUTC.ToSqlServerUtcDate())
                        .WhereFalse(map[nameof(InternalObject.IsQuote)].Column);

                    if (!includeQuotes)
                    {
                        query = query.WhereFalse(map[nameof(InternalObject.IsQuote)].Column);
                    }

                    results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>>(WhippetResult.Success, await ImportFromDynamicResultSetAsync(results));
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>>(new WhippetResult(e), null);
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                        context = null;
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerOrder"/> objects for the specified date range that are indicated as quotes (<see cref="MultichannelOrderManagerOrder.IsQuote"/> value is <see langword="true"/>).
        /// </summary>
        /// <param name="fromDateTimeUTC">From date/time range.</param>
        /// <param name="toDateTimeUTC">To date/time range.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        public virtual WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>> GetQuotesForDateRange(Instant fromDateTimeUTC, Instant toDateTimeUTC)
        {
            return Task.Run(() => GetOrdersForDateRangeAsync(fromDateTimeUTC, toDateTimeUTC, true)).Result;
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerOrder"/> objects for the specified date range that are indicated as quotes (<see cref="MultichannelOrderManagerOrder.IsQuote"/> value is <see langword="true"/>).
        /// </summary>
        /// <param name="fromDateTimeUTC">From date/time range.</param>
        /// <param name="toDateTimeUTC">To date/time range.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>>> GetQuotesForDateRangeAsync(Instant fromDateTimeUTC, Instant toDateTimeUTC, CancellationToken? cancellationToken = null)
        {
            if (toDateTimeUTC < fromDateTimeUTC)
            {
                throw new ArgumentException(null, nameof(toDateTimeUTC));
            }
            else
            {
                QueryFactory context = null;
                Query query = null;

                WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>> result = null;

                WhippetDataRowImportMap map = InternalObject.CreateImportMap();

                IEnumerable<dynamic> results = null;

                try
                {
                    context = CreateQueryFactory<SqlServerCompiler>();
                    query = context.Query(TableName)
                        .WhereDate(map[nameof(InternalObject.OrderDate)].Column, ">=", fromDateTimeUTC.ToSqlServerUtcDate())
                        .WhereDate(map[nameof(InternalObject.OrderDate)].Column, "<=", toDateTimeUTC.ToSqlServerUtcDate())
                        .WhereTrue(map[nameof(InternalObject.IsQuote)].Column);

                    results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>>(WhippetResult.Success, await ImportFromDynamicResultSetAsync(results));
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>>(new WhippetResult(e), null);
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                        context = null;
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerOrder"/> objects for the specified order range.
        /// </summary>
        /// <param name="orderIdStart">The lower order ID inclusive value to start.</param>
        /// <param name="orderIdEnd">The upper order ID inclusive value to stop.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        public virtual WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>> GetOrders(long orderIdStart, long orderIdEnd)
        {
            return Task.Run(() => GetOrdersAsync(orderIdStart, orderIdEnd)).Result;
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerOrder"/> objects for the specified order range.
        /// </summary>
        /// <param name="orderIdStart">The lower order ID inclusive value to start.</param>
        /// <param name="orderIdEnd">The upper order ID inclusive value to stop.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>>> GetOrdersAsync(long orderIdStart, long orderIdEnd, CancellationToken? cancellationToken = null)
        {
            if (orderIdEnd < orderIdStart)
            {
                throw new ArgumentException(null, nameof(orderIdEnd));
            }
            else
            {
                QueryFactory context = null;
                Query query = null;

                WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>> result = null;

                WhippetDataRowImportMap map = InternalObject.CreateImportMap();

                IEnumerable<dynamic> results = null;

                try
                {
                    context = CreateQueryFactory<SqlServerCompiler>();
                    query = context.Query(TableName)
                        .WhereDate(map[nameof(InternalObject.OrderNumber)].Column, ">=", orderIdStart)
                        .WhereDate(map[nameof(InternalObject.OrderNumber)].Column, "<=", orderIdEnd)
                        .WhereFalse(map[nameof(InternalObject.IsQuote)].Column);

                    results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>>(WhippetResult.Success, await ImportFromDynamicResultSetAsync(results));
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>>(new WhippetResult(e), null);
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                        context = null;
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Gets the total number of orders in the data store.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        public virtual WhippetResultContainer<long> GetOrderCount()
        {
            return Task.Run(() => GetOrderCountAsync()).Result;
        }

        /// <summary>
        /// Gets the total number of orders in the data store.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        public virtual async Task<WhippetResultContainer<long>> GetOrderCountAsync(CancellationToken? cancellationToken = null)
        {
            QueryFactory context = null;
            Query query = null;

            WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>> result = null;

            WhippetDataRowImportMap map = InternalObject.CreateImportMap();

            IEnumerable<dynamic> results = null;

            long totalRecords = 0;

            try
            {
                context = CreateQueryFactory<SqlServerCompiler>();
                query = context.Query(TableName)
                    .WhereFalse(map[nameof(InternalObject.IsQuote)].Column)
                    .AsCount();

                results = await query.GetAsync();
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>>(new WhippetResult(e), null);
            }
            finally
            {
                if (context != null)
                {
                    context.Dispose();
                    context = null;
                }

                if (results != null && results.Any())
                {
                    totalRecords = Convert.ToInt64(results.FirstOrDefault().count);
                }
            }

            return new WhippetResultContainer<long>(WhippetResult.Success, totalRecords);
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerOrder"/> objects for the specified <see cref="IMultichannelOrderManagerCustomer"/>.
        /// </summary>
        /// <param name="customer"><see cref="IMultichannelOrderManagerCustomer"/> to retrieve orders for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>> GetOrdersForCustomer(IMultichannelOrderManagerCustomer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            else
            {
                return Task.Run(() => GetOrdersForCustomerAsync(customer)).Result;
            }
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerOrder"/> objects for the specified <see cref="IMultichannelOrderManagerCustomer"/>.
        /// </summary>
        /// <param name="customer"><see cref="IMultichannelOrderManagerCustomer"/> to retrieve orders for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>>> GetOrdersForCustomerAsync(IMultichannelOrderManagerCustomer customer, CancellationToken? cancellationToken = null)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            else
            {
                QueryFactory context = null;
                Query query = null;

                WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>> result = null;

                WhippetDataRowImportMap map = InternalObject.CreateImportMap();

                IEnumerable<dynamic> results = null;

                try
                {
                    context = CreateQueryFactory<SqlServerCompiler>();
                    query = context.Query(TableName)
                        .Where(map[nameof(InternalObject.CustomerNumber)].Column, customer.CustomerId)
                        .WhereFalse(map[nameof(InternalObject.IsQuote)].Column);

                    results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>>(WhippetResult.Success, await ImportFromDynamicResultSetAsync(results));
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>>(new WhippetResult(e), null);
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                        context = null;
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerOrder"/> objects for the specified <see cref="IMultichannelOrderManagerCustomer"/> that are indicated as quotes (<see cref="MultichannelOrderManagerOrder.IsQuote"/> value is <see langword="true"/>).
        /// </summary>
        /// <param name="customer"><see cref="IMultichannelOrderManagerCustomer"/> to retrieve quotes for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>> GetQuotesForCustomer(IMultichannelOrderManagerCustomer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            else
            {
                return Task.Run(() => GetQuotesForCustomerAsync(customer)).Result;
            }
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerOrder"/> objects for the specified <see cref="IMultichannelOrderManagerCustomer"/> that are indicated as quotes (<see cref="MultichannelOrderManagerOrder.IsQuote"/> value is <see langword="true"/>).
        /// </summary>
        /// <param name="customer"><see cref="IMultichannelOrderManagerCustomer"/> to retrieve quotes for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>>> GetQuotesForCustomerAsync(IMultichannelOrderManagerCustomer customer, CancellationToken? cancellationToken = null)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            else
            {
                QueryFactory context = null;
                Query query = null;

                WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>> result = null;

                WhippetDataRowImportMap map = InternalObject.CreateImportMap();

                IEnumerable<dynamic> results = null;

                try
                {
                    context = CreateQueryFactory<SqlServerCompiler>();
                    query = context.Query(TableName)
                        .Where(map[nameof(InternalObject.CustomerNumber)].Column, customer.CustomerId)
                        .WhereTrue(map[nameof(InternalObject.IsQuote)].Column);

                    results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>>(WhippetResult.Success, await ImportFromDynamicResultSetAsync(results));
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>>(new WhippetResult(e), null);
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                        context = null;
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerOrder"/> objects based on the specified <see cref="IMultichannelOrderManagerOrder.OrderNumber"/> values.
        /// </summary>
        /// <param name="orderIds"><see cref="IEnumerable{T}"/> collection of <see cref="IMultichannelOrderManagerOrder.OrderNumber"/> values.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>> GetOrders(IEnumerable<long> orderIds)
        {
            if (orderIds == null)
            {
                throw new ArgumentNullException(nameof(orderIds));
            }
            else
            {
                return Task.Run(() => GetOrdersAsync(orderIds)).Result;
            }
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerOrder"/> objects based on the specified <see cref="IMultichannelOrderManagerOrder.OrderNumber"/> values.
        /// </summary>
        /// <param name="orderIds"><see cref="IEnumerable{T}"/> collection of <see cref="IMultichannelOrderManagerOrder.OrderNumber"/> values.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>>> GetOrdersAsync(IEnumerable<long> orderIds, CancellationToken? cancellationToken = null)
        {
            if (orderIds == null)
            {
                throw new ArgumentNullException(nameof(orderIds));
            }
            else
            {
                QueryFactory context = null;
                Query query = null;

                WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>> result = null;

                WhippetDataRowImportMap map = InternalObject.CreateImportMap();

                IEnumerable<dynamic> results = null;

                try
                {
                    context = CreateQueryFactory<SqlServerCompiler>();
                    query = context.Query(TableName)
                        .WhereIn(map[nameof(InternalObject.OrderNumber)].Column, orderIds);

                    results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>>(WhippetResult.Success, await ImportFromDynamicResultSetAsync(results));
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerOrder>>(new WhippetResult(e), null);
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                        context = null;
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        /// <param name="key">Unique key of the record to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        WhippetResultContainer<MultichannelOrderManagerOrder> IWhippetRepository<MultichannelOrderManagerOrder, Guid>.Get(System.Guid key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        /// <param name="key">Unique key of the record to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        Task<WhippetResultContainer<MultichannelOrderManagerOrder>> IWhippetRepository<MultichannelOrderManagerOrder, Guid>.GetAsync(Guid key, CancellationToken? cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
