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
    /// Represents a data repository for mapping <see cref="MultichannelOrderManagerCountry"/> entity objects.
    /// </summary>
    public interface IMultichannelOrderManagerCountryRepository : IWhippetEntityRepository<MultichannelOrderManagerCountry, long>, IWhippetQueryRepository<MultichannelOrderManagerCountry>, IWhippetExternalQueryRepository<MultichannelOrderManagerCountry, long>
    {
        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerCountry"/> objects.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<MultichannelOrderManagerCountry>> GetCountries();

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerCountry"/> objects.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerCountry>>> GetCountriesAsync(CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets the <see cref="MultichannelOrderManagerCountry"/> object with the specified abbreviation.
        /// </summary>
        /// <param name="abbreviation">Two-letter ISO abbreviation of the country.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<MultichannelOrderManagerCountry> GetCountryByAbbreviation(string abbreviation);

        /// <summary>
        /// Gets the <see cref="MultichannelOrderManagerCountry"/> object with the specified abbreviation.
        /// </summary>
        /// <param name="abbreviation">Two-letter ISO abbreviation of the country.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<MultichannelOrderManagerCountry>> GetCountryByAbbreviationAsync(string abbreviation, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets the <see cref="MultichannelOrderManagerCountry"/> object with the specified three digit code.
        /// </summary>
        /// <param name="countryCode">Three-digit country code of the country.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<MultichannelOrderManagerCountry> GetCountryByCode(string countryCode);

        /// <summary>
        /// Gets the <see cref="MultichannelOrderManagerCountry"/> object with the specified three digit code.
        /// </summary>
        /// <param name="countryCode">Three-digit country code of the country.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<MultichannelOrderManagerCountry>> GetCountryByCodeAsync(string countryCode, CancellationToken? cancellationToken = null);
    }
}
