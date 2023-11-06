using System;
using NodaTime;
using FluentNHibernate.Data;
using Athi.Whippet;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="MultichannelOrderManagerCustomer"/> entity objects.
    /// </summary>
    public interface IMultichannelOrderManagerCustomerRepository : IWhippetEntityRepository<MultichannelOrderManagerCustomer, long>, IWhippetQueryRepository<MultichannelOrderManagerCustomer>, IWhippetExternalQueryRepository<MultichannelOrderManagerCustomer, long>
    {
        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerCustomer"/> objects that are companies, specifically entities that have no <see cref="MultichannelOrderManagerCustomer.FirstName"/> and <see cref="MultichannelOrderManagerCustomer.LastName"/>.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>> GetCompanies();

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerCustomer"/> objects that are companies, specifically entities that have no <see cref="MultichannelOrderManagerCustomer.FirstName"/> and <see cref="MultichannelOrderManagerCustomer.LastName"/>.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>> GetCompaniesAsync(CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets the <see cref="MultichannelOrderManagerCustomer"/> objects that is a company and matches the specified name.
        /// </summary>
        /// <param name="companyName">Name of the company to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<MultichannelOrderManagerCustomer> GetCompany(string companyName);

        /// <summary>
        /// Gets the <see cref="MultichannelOrderManagerCustomer"/> objects that is a company and matches the specified name.
        /// </summary>
        /// <param name="companyName">Name of the company to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        Task<WhippetResultContainer<MultichannelOrderManagerCustomer>> GetCompanyAsync(string companyName, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerCustomer"/> objects that have the specified company name.
        /// </summary>
        /// <param name="companyName">Company name to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>> GetCustomersForCompany(string companyName);

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerCustomer"/> objects that have the specified company name.
        /// </summary>
        /// <param name="companyName">Company name to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>> GetCustomersForCompanyAsync(string companyName, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Retrieves all <see cref="MultichannelOrderManagerCustomer"/> objects with the optional first and last name filter(s).
        /// </summary>
        /// <param name="firstName">Optional first name filter. If wildcard characters are used, a SQL LIKE operation will be performed.</param>
        /// <param name="lastName">Optional last name filter. If wildcard characters are used, a SQL LIKE operation will be performed.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>> GetCustomers(string firstName = null, string lastName = null);

        /// <summary>
        /// Retrieves all <see cref="MultichannelOrderManagerCustomer"/> objects with the optional first and last name filter(s).
        /// </summary>
        /// <param name="firstName">Optional first name filter. If wildcard characters are used, a SQL LIKE operation will be performed.</param>
        /// <param name="lastName">Optional last name filter. If wildcard characters are used, a SQL LIKE operation will be performed.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>> GetCustomersAsync(string firstName = null, string lastName = null, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Retrieves all <see cref="MultichannelOrderManagerCustomer"/> objects with the specified <see cref="MultichannelOrderManagerCustomer.CustomerId"/> values.
        /// </summary>
        /// <param name="customerIds"><see cref="MultichannelOrderManagerCustomer.CustomerId"/> values to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException"></exception>
        WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>> GetCustomers(IEnumerable<long> customerIds);

        /// <summary>
        /// Retrieves all <see cref="MultichannelOrderManagerCustomer"/> objects with the specified <see cref="MultichannelOrderManagerCustomer.CustomerId"/> values.
        /// </summary>
        /// <param name="customerIds"><see cref="MultichannelOrderManagerCustomer.CustomerId"/> values to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>> GetCustomersAsync(IEnumerable<long> customerIds, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Retrieves all <see cref="MultichannelOrderManagerCustomer"/> objects with the specified <see cref="MultichannelOrderManagerCustomer.ZipCode"/> value.
        /// </summary>
        /// <param name="postalCode">Postal code to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException"></exception>
        WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>> GetCustomersByPostalCode(string postalCode);

        /// <summary>
        /// Retrieves all <see cref="MultichannelOrderManagerCustomer"/> objects with the specified <see cref="MultichannelOrderManagerCustomer.ZipCode"/> value.
        /// </summary>
        /// <param name="postalCode">Postal code to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>> GetCustomersByPostalCodeAsync(string postalCode, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Retrieves all <see cref="MultichannelOrderManagerCustomer"/> objects with the specified <see cref="MultichannelOrderManagerCustomer.Email"/> value.
        /// </summary>
        /// <param name="emailAddress">E-mail address to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException"></exception>
        WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>> GetCustomersByEmailAddress(string emailAddress);

        /// <summary>
        /// Retrieves all <see cref="MultichannelOrderManagerCustomer"/> objects with the specified <see cref="MultichannelOrderManagerCustomer.Email"/> value.
        /// </summary>
        /// <param name="emailAddress">E-mail address to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>> GetCustomersByEmailAddressAsync(string emailAddress, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Determines the total number of active customers for a specific date range.
        /// </summary>
        /// <param name="fromDate">Starting date range of the query.</param>
        /// <param name="toDate">Ending date range of the query.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        WhippetResultContainer<long> GetActiveCustomerCount(Instant fromDate, Instant toDate);

        /// <summary>
        /// Determines the total number of active customers for a specific date range.
        /// </summary>
        /// <param name="fromDate">Starting date range of the query.</param>
        /// <param name="toDate">Ending date range of the query.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        Task<WhippetResultContainer<long>> GetActiveCustomerCountAsync(Instant fromDate, Instant toDate, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Retrieves all <see cref="MultichannelOrderManagerCustomer"/> objects that are active for the specified date range.
        /// </summary>
        /// <param name="fromDate">Starting date range of the query.</param>
        /// <param name="toDate">Ending date range of the query.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>> GetActiveCustomers(Instant fromDate, Instant toDate);

        /// <summary>
        /// Retrieves all <see cref="MultichannelOrderManagerCustomer"/> objects that are active for the specified date range.
        /// </summary>
        /// <param name="fromDate">Starting date range of the query.</param>
        /// <param name="toDate">Ending date range of the query.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>> GetActiveCustomersAsync(Instant fromDate, Instant toDate, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Retrieves all <see cref="MultichannelOrderManagerCustomer"/> objects that are active for the specified date range populating only the <see cref="MultichannelOrderManagerCustomer.CustomerId"/> field.
        /// </summary>
        /// <param name="fromDate">Starting date range of the query.</param>
        /// <param name="toDate">Ending date range of the query.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>> GetActiveCustomerNumbers(Instant fromDate, Instant toDate);

        /// <summary>
        /// Retrieves all <see cref="MultichannelOrderManagerCustomer"/> objects that are active for the specified date range populating only the <see cref="MultichannelOrderManagerCustomer.CustomerId"/> field.
        /// </summary>
        /// <param name="fromDate">Starting date range of the query.</param>
        /// <param name="toDate">Ending date range of the query.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerCustomer>>> GetActiveCustomerNumbersAsync(Instant fromDate, Instant toDate, CancellationToken? cancellationToken = null);
    }
}
