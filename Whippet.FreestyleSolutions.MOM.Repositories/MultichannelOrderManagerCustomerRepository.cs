using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Data;
using System.Linq;
using System.Text;
using NHibernate;
using NodaTime;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;
using Athi.Whippet.Data;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Repositories
{
    /// <summary>
    /// Represents a data repository for managing <see cref="MultichannelOrderManagerCustomer"/> entity objects.
    /// </summary>
    public class MultichannelOrderManagerCustomerRepository : MultichannelOrderManagerRepositoryBase<MultichannelOrderManagerCustomer, long>, IMultichannelOrderManagerCustomerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerCustomerRepository"/> class with the specified <see cref="IDbConnection"/> object.
        /// </summary>
        /// <param name="connection"><see cref="IDbConnection"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerCustomerRepository(IDbConnection connection)
            : base(connection)
        { }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerCustomer"/> objects that are companies, specifically entities that have no <see cref="MultichannelOrderManagerCustomer.FirstName"/> and <see cref="MultichannelOrderManagerCustomer.LastName"/>.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        public virtual WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>> GetCompanies()
        {
            return Task.Run(() => GetCompaniesAsync()).Result;
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerCustomer"/> objects that are companies, specifically entities that have no <see cref="MultichannelOrderManagerCustomer.FirstName"/> and <see cref="MultichannelOrderManagerCustomer.LastName"/>.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>> GetCompaniesAsync(CancellationToken? cancellationToken = null)
        {
            QueryFactory context = null;
            Query query = null;

            WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>> result = null;

            WhippetDataRowImportMap map = InternalObject.CreateImportMap();

            IEnumerable<dynamic> results = null;

            try
            {
                context = CreateQueryFactory<SqlServerCompiler>();
                query = context.Query(TableName)
                    .Where(map[nameof(InternalObject.FirstName)].Column, String.Empty)
                    .Where(map[nameof(InternalObject.LastName)].Column, String.Empty)
                    .WhereNot(map[nameof(InternalObject.Company)].Column, String.Empty)
                    .WhereNot(map[nameof(InternalObject.Company)].Column, DBNull.Value);

                results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>(WhippetResult.Success, await ImportFromDynamicResultSetAsync(results));
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>(new WhippetResult(e), null);
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

        /// <summary>
        /// Gets the <see cref="MultichannelOrderManagerCustomer"/> objects that is a company and matches the specified name.
        /// </summary>
        /// <param name="companyName">Name of the company to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<MultichannelOrderManagerCustomer> GetCompany(string companyName)
        {
            if (String.IsNullOrWhiteSpace(companyName))
            {
                throw new ArgumentNullException(nameof(companyName));
            }
            else
            {
                return Task.Run(() => GetCompanyAsync(companyName)).Result;
            }
        }

        /// <summary>
        /// Gets the <see cref="MultichannelOrderManagerCustomer"/> objects that is a company and matches the specified name.
        /// </summary>
        /// <param name="companyName">Name of the company to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        public virtual async Task<WhippetResultContainer<MultichannelOrderManagerCustomer>> GetCompanyAsync(string companyName, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(companyName))
            {
                throw new ArgumentNullException(nameof(companyName));
            }
            else
            {
                QueryFactory context = null;
                Query query = null;

                WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>> result = null;

                WhippetDataRowImportMap map = InternalObject.CreateImportMap();

                IEnumerable<dynamic> results = null;

                try
                {
                    context = CreateQueryFactory<SqlServerCompiler>();
                    query = context.Query(TableName)
                        .Where(map[nameof(InternalObject.Company)].Column, companyName)
                        .Where(map[nameof(InternalObject.FirstName)].Column, String.Empty)
                        .Where(map[nameof(InternalObject.LastName)].Column, String.Empty);

                    results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>(WhippetResult.Success, await ImportFromDynamicResultSetAsync(results));
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>(new WhippetResult(e), null);
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                        context = null;
                    }
                }

                return new WhippetResultContainer<MultichannelOrderManagerCustomer>(result.Result, result.Item.FirstOrDefault());
            }
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerCustomer"/> objects that have the specified company name.
        /// </summary>
        /// <param name="companyName">Company name to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>> GetCustomersForCompany(string companyName)
        {
            if (String.IsNullOrWhiteSpace(companyName))
            {
                throw new ArgumentNullException(nameof(companyName));
            }
            else
            {
                return Task.Run(() => GetCustomersForCompanyAsync(companyName)).Result;
            }
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerCustomer"/> objects that have the specified company name.
        /// </summary>
        /// <param name="companyName">Company name to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>> GetCustomersForCompanyAsync(string companyName, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(companyName))
            {
                throw new ArgumentNullException(nameof(companyName));
            }
            else
            {
                QueryFactory context = null;
                Query query = null;

                WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>> result = null;

                WhippetDataRowImportMap map = InternalObject.CreateImportMap();

                IEnumerable<dynamic> results = null;

                try
                {
                    context = CreateQueryFactory<SqlServerCompiler>();

                    if (companyName.Contains('_') || companyName.Contains('%'))
                    {
                        query = context.Query(TableName)
                            .WhereLike(map[nameof(InternalObject.Company)].Column, companyName)
                            .OrWhereLike(map[nameof(InternalObject.FirstName)].Column, companyName)
                            .OrWhereLike(map[nameof(InternalObject.LastName)].Column, companyName);
                    }
                    else
                    {
                        query = context.Query(TableName)
                            .Where(map[nameof(InternalObject.Company)].Column, companyName)
                            .OrWhere(map[nameof(InternalObject.FirstName)].Column, companyName)
                            .OrWhere(map[nameof(InternalObject.LastName)].Column, companyName);
                    }

                    results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>(WhippetResult.Success, await ImportFromDynamicResultSetAsync(results));
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>(new WhippetResult(e), null);
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
        /// Retrieves all <see cref="MultichannelOrderManagerCustomer"/> objects with the optional first and last name filter(s).
        /// </summary>
        /// <param name="firstName">Optional first name filter. If wildcard characters are used, a SQL LIKE operation will be performed.</param>
        /// <param name="lastName">Optional last name filter. If wildcard characters are used, a SQL LIKE operation will be performed.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        public virtual WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>> GetCustomers(string firstName = null, string lastName = null)
        {
            return Task.Run(() => GetCustomersAsync(firstName, lastName)).Result;
        }

        /// <summary>
        /// Retrieves all <see cref="MultichannelOrderManagerCustomer"/> objects with the optional first and last name filter(s).
        /// </summary>
        /// <param name="firstName">Optional first name filter. If wildcard characters are used, a SQL LIKE operation will be performed.</param>
        /// <param name="lastName">Optional last name filter. If wildcard characters are used, a SQL LIKE operation will be performed.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>> GetCustomersAsync(string firstName = null, string lastName = null, CancellationToken? cancellationToken = null)
        {
            QueryFactory context = null;
            Query query = null;

            WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>> result = null;

            WhippetDataRowImportMap map = InternalObject.CreateImportMap();

            IEnumerable<dynamic> results = null;

            try
            {
                context = CreateQueryFactory<SqlServerCompiler>();

                query = context.Query(TableName);

                if (!String.IsNullOrWhiteSpace(firstName))
                {
                    if (firstName.Contains('_') || firstName.Contains('%'))
                    {
                        query = query.WhereLike(map[nameof(InternalObject.FirstName)].Column, firstName);
                    }
                    else
                    {
                        query = query.Where(map[nameof(InternalObject.FirstName)].Column, firstName);
                    }
                }

                if (!String.IsNullOrWhiteSpace(lastName))
                {
                    if (lastName.Contains('_') || lastName.Contains('%'))
                    {
                        query = query.WhereLike(map[nameof(InternalObject.LastName)].Column, lastName);
                    }
                    else
                    {
                        query = query.Where(map[nameof(InternalObject.LastName)].Column, lastName);
                    }
                }

                results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>(WhippetResult.Success, await ImportFromDynamicResultSetAsync(results));
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>(new WhippetResult(e), null);
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

        /// <summary>
        /// Retrieves all <see cref="MultichannelOrderManagerCustomer"/> objects with the specified <see cref="MultichannelOrderManagerCustomer.CustomerId"/> values.
        /// </summary>
        /// <param name="customerIds"><see cref="MultichannelOrderManagerCustomer.CustomerId"/> values to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>> GetCustomers(IEnumerable<long> customerIds)
        {
            if (customerIds == null)
            {
                throw new ArgumentNullException(nameof(customerIds));
            }
            else
            {
                return Task.Run(() => GetCustomersAsync(customerIds)).Result;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="MultichannelOrderManagerCustomer"/> objects with the specified <see cref="MultichannelOrderManagerCustomer.CustomerId"/> values.
        /// </summary>
        /// <param name="customerIds"><see cref="MultichannelOrderManagerCustomer.CustomerId"/> values to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>> GetCustomersAsync(IEnumerable<long> customerIds, CancellationToken? cancellationToken = null)
        {
            if (customerIds == null)
            {
                throw new ArgumentNullException(nameof(customerIds));
            }
            else
            {
                QueryFactory context = null;
                Query query = null;

                WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>> result = null;

                WhippetDataRowImportMap map = InternalObject.CreateImportMap();

                IEnumerable<dynamic> results = null;

                try
                {
                    context = CreateQueryFactory<SqlServerCompiler>();

                    query = context.Query(TableName);

                    query = query.WhereIn<long>(map[nameof(InternalObject.CustomerId)].Column, customerIds.Distinct());

                    results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>(WhippetResult.Success, await ImportFromDynamicResultSetAsync(results));
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>(new WhippetResult(e), null);
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
        /// Retrieves all <see cref="MultichannelOrderManagerCustomer"/> objects with the specified <see cref="MultichannelOrderManagerCustomer.ZipCode"/> value.
        /// </summary>
        /// <param name="postalCode">Postal code to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>> GetCustomersByPostalCode(string postalCode)
        {
            if (String.IsNullOrWhiteSpace(postalCode))
            {
                throw new ArgumentNullException(nameof(postalCode));
            }
            else
            {
                return Task.Run(() => GetCustomersByPostalCodeAsync(postalCode)).Result;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="MultichannelOrderManagerCustomer"/> objects with the specified <see cref="MultichannelOrderManagerCustomer.ZipCode"/> value.
        /// </summary>
        /// <param name="postalCode">Postal code to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>> GetCustomersByPostalCodeAsync(string postalCode, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(postalCode))
            {
                throw new ArgumentNullException(nameof(postalCode));
            }
            else
            {
                QueryFactory context = null;
                Query query = null;

                WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>> result = null;

                WhippetDataRowImportMap map = InternalObject.CreateImportMap();

                IEnumerable<dynamic> results = null;

                try
                {
                    context = CreateQueryFactory<SqlServerCompiler>();

                    query = context.Query(TableName);
                    query = query.WhereLike(map[nameof(InternalObject.ZipCode)].Column, postalCode);

                    results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>(WhippetResult.Success, await ImportFromDynamicResultSetAsync(results));
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>(new WhippetResult(e), null);
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
        /// Retrieves all <see cref="MultichannelOrderManagerCustomer"/> objects with the specified <see cref="MultichannelOrderManagerCustomer.Email"/> value.
        /// </summary>
        /// <param name="emailAddress">E-mail address to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>> GetCustomersByEmailAddress(string emailAddress)
        {
            if (String.IsNullOrWhiteSpace(emailAddress))
            {
                throw new ArgumentNullException(nameof(emailAddress));
            }
            else
            {
                return Task.Run(() => GetCustomersByEmailAddressAsync(emailAddress)).Result;
            }
        }

        /// <summary>
        /// Retrieves all <see cref="MultichannelOrderManagerCustomer"/> objects with the specified <see cref="MultichannelOrderManagerCustomer.Email"/> value.
        /// </summary>
        /// <param name="emailAddress">E-mail address to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>> GetCustomersByEmailAddressAsync(string emailAddress, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(emailAddress))
            {
                throw new ArgumentNullException(nameof(emailAddress));
            }
            else
            {
                QueryFactory context = null;
                Query query = null;

                WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>> result = null;

                WhippetDataRowImportMap map = InternalObject.CreateImportMap();

                IEnumerable<dynamic> results = null;

                try
                {
                    context = CreateQueryFactory<SqlServerCompiler>();

                    query = context.Query(TableName);
                    query = query.WhereLike(map[nameof(InternalObject.Email)].Column, emailAddress);

                    results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>(WhippetResult.Success, await ImportFromDynamicResultSetAsync(results));
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>(new WhippetResult(e), null);
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
        /// Determines the total number of active customers for a specific date range.
        /// </summary>
        /// <param name="fromDate">Starting date range of the query.</param>
        /// <param name="toDate">Ending date range of the query.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        public virtual WhippetResultContainer<long> GetActiveCustomerCount(Instant fromDate, Instant toDate)
        {
            return Task.Run(() => GetActiveCustomerCountAsync(fromDate, toDate)).Result;
        }

        /// <summary>
        /// Determines the total number of active customers for a specific date range.
        /// </summary>
        /// <param name="fromDate">Starting date range of the query.</param>
        /// <param name="toDate">Ending date range of the query.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        public virtual async Task<WhippetResultContainer<long>> GetActiveCustomerCountAsync(Instant fromDate, Instant toDate, CancellationToken? cancellationToken = null)
        {
            QueryFactory context = null;
            Query query = null;

            WhippetResultContainer<long> result = null;

            WhippetDataRowImportMap map = InternalObject.CreateImportMap();

            IEnumerable<dynamic> results = null;
            KeyValuePair<string, object> dapperRow = default(KeyValuePair<string, object>);

            long count = 0;

            try
            {
                context = CreateQueryFactory<SqlServerCompiler>();

                query = context.Query(TableName);
                query = query.SelectRaw("COUNT(*)");
                query = query.Where(map[nameof(InternalObject.Expired)].Column, false);
                query = query.WhereDate(map[nameof(InternalObject.LookupOn)].Column, ">=", fromDate.ToDateTimeUtc().ToString("yyyy-MM-dd"));
                query = query.WhereDate(map[nameof(InternalObject.LookupOn)].Column, "<=", toDate.ToDateTimeUtc().ToString("yyyy-MM-dd"));

                results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                if (results.Any() && results.First() is IEnumerable<KeyValuePair<string, object>>)
                {
                    dapperRow = ((IEnumerable<KeyValuePair<string, object>>)(results.First())).FirstOrDefault();

                    if (dapperRow.Value != null && dapperRow.Value != DBNull.Value)
                    {
                        count = Int64.Parse(Convert.ToString(dapperRow.Value));
                    }
                }

                result = new WhippetResultContainer<long>(WhippetResult.Success, count);
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<long>(new WhippetResult(e), default(long));
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

        /// <summary>
        /// Retrieves all <see cref="MultichannelOrderManagerCustomer"/> objects that are active for the specified date range.
        /// </summary>
        /// <param name="fromDate">Starting date range of the query.</param>
        /// <param name="toDate">Ending date range of the query.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        public virtual WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>> GetActiveCustomers(Instant fromDate, Instant toDate)
        {
            return Task.Run(() => GetActiveCustomersAsync(fromDate, toDate)).Result;
        }

        /// <summary>
        /// Retrieves all <see cref="MultichannelOrderManagerCustomer"/> objects that are active for the specified date range.
        /// </summary>
        /// <param name="fromDate">Starting date range of the query.</param>
        /// <param name="toDate">Ending date range of the query.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>> GetActiveCustomersAsync(Instant fromDate, Instant toDate, CancellationToken? cancellationToken = null)
        {
            QueryFactory context = null;
            Query query = null;

            WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>> result = null;

            WhippetDataRowImportMap map = InternalObject.CreateImportMap();

            IEnumerable<dynamic> results = null;

            try
            {
                context = CreateQueryFactory<SqlServerCompiler>();

                query = context.Query(TableName);
                query = query.Where(map[nameof(InternalObject.Expired)].Column, false);
                query = query.WhereDate(map[nameof(InternalObject.LookupOn)].Column, ">=", fromDate.ToDateTimeUtc().ToString("yyyy-MM-dd"));
                query = query.WhereDate(map[nameof(InternalObject.LookupOn)].Column, "<=", toDate.ToDateTimeUtc().ToString("yyyy-MM-dd"));

                results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>(WhippetResult.Success, await ImportFromDynamicResultSetAsync(results));
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>(new WhippetResult(e), null);
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

        /// <summary>
        /// Retrieves all <see cref="MultichannelOrderManagerCustomer"/> objects that are active for the specified date range populating only the <see cref="MultichannelOrderManagerCustomer.CustomerId"/> field.
        /// </summary>
        /// <param name="fromDate">Starting date range of the query.</param>
        /// <param name="toDate">Ending date range of the query.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        public virtual WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>> GetActiveCustomerNumbers(Instant fromDate, Instant toDate)
        {
            return Task.Run(() => GetActiveCustomerNumbersAsync(fromDate, toDate)).Result;
        }

        /// <summary>
        /// Retrieves all <see cref="MultichannelOrderManagerCustomer"/> objects that are active for the specified date range populating only the <see cref="MultichannelOrderManagerCustomer.CustomerId"/> field.
        /// </summary>
        /// <param name="fromDate">Starting date range of the query.</param>
        /// <param name="toDate">Ending date range of the query.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>> GetActiveCustomerNumbersAsync(Instant fromDate, Instant toDate, CancellationToken? cancellationToken = null)
        {
            QueryFactory context = null;
            Query query = null;

            WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>> result = null;

            WhippetDataRowImportMap map = InternalObject.CreateImportMap();

            IEnumerable<dynamic> results = null;

            List<MultichannelOrderManagerCustomer> customerResults = null;

            try
            {
                context = CreateQueryFactory<SqlServerCompiler>();

                query = context.Query(TableName);
                query = query.Select(map[nameof(InternalObject.CustomerId)].Column);
                query = query.Where(map[nameof(InternalObject.Expired)].Column, false);
                query = query.WhereDate(map[nameof(InternalObject.LookupOn)].Column, ">=", fromDate.ToDateTimeUtc().ToString("yyyy-MM-dd"));
                query = query.WhereDate(map[nameof(InternalObject.LookupOn)].Column, "<=", toDate.ToDateTimeUtc().ToString("yyyy-MM-dd"));

                results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                if (results.Any() && results.First() is IEnumerable<KeyValuePair<string, object>>)
                {
                    customerResults = new List<MultichannelOrderManagerCustomer>(((IEnumerable<object>)(results)).Count());

                    foreach (IEnumerable<KeyValuePair<string, object>> resultItem in ((IEnumerable<object>)(results)))
                    {
                        customerResults.AddRange(resultItem.Select(r => new MultichannelOrderManagerCustomer(Guid.Empty, Convert.ToInt64(r.Value))));
                    }
                }

                result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>(WhippetResult.Success, customerResults == null ? new List<MultichannelOrderManagerCustomer>() : customerResults);
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>(new WhippetResult(e), null);
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

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        /// <param name="key">Unique key of the record to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        WhippetResultContainer<MultichannelOrderManagerCustomer> IWhippetRepository<MultichannelOrderManagerCustomer, Guid>.Get(System.Guid key)
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
        Task<WhippetResultContainer<MultichannelOrderManagerCustomer>> IWhippetRepository<MultichannelOrderManagerCustomer, Guid>.GetAsync(Guid key, CancellationToken? cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
