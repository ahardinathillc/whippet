using System;
using FluentNHibernate.Data;
using NodaTime;
using Athi.Whippet;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="MultichannelOrderManagerCounty"/> entity objects.
    /// </summary>
    public interface IMultichannelOrderManagerCountyRepository : IWhippetEntityRepository<MultichannelOrderManagerCounty, long>, IWhippetQueryRepository<MultichannelOrderManagerCounty>, IWhippetExternalQueryRepository<MultichannelOrderManagerCounty, long>
    {
        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerCounty"/> objects for the specified <see cref="IMultichannelOrderManagerCountry"/>.
        /// </summary>
        /// <param name="country"><see cref="IMultichannelOrderManagerCountry"/> to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<MultichannelOrderManagerCounty>> Get(IMultichannelOrderManagerCountry country);

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerCounty"/> objects for the specified <see cref="IMultichannelOrderManagerCountry"/>.
        /// </summary>
        /// <param name="country"><see cref="IMultichannelOrderManagerCountry"/> to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerCounty>>> GetAsync(IMultichannelOrderManagerCountry country, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerCounty"/> objects for the specified <see cref="IMultichannelOrderManagerCountry"/>.
        /// </summary>
        /// <param name="stateProvince"><see cref="IMultichannelOrderManagerStateProvince"/> to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<MultichannelOrderManagerCounty>> Get(IMultichannelOrderManagerStateProvince stateProvince);

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerCounty"/> objects for the specified <see cref="IMultichannelOrderManagerCountry"/>.
        /// </summary>
        /// <param name="stateProvince"><see cref="IMultichannelOrderManagerStateProvince"/> to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerCounty>>> GetAsync(IMultichannelOrderManagerStateProvince stateProvince, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets the <see cref="MultichannelOrderManagerCounty"/> object with the specified three digit code.
        /// </summary>
        /// <param name="countyCode">Three-digit county code of the county.</param>
        /// <param name="stateAbbreviation">State abbreviation.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<MultichannelOrderManagerCounty> GetCountyByCode(string countyCode, string stateAbbreviation);

        /// <summary>
        /// Gets the <see cref="MultichannelOrderManagerCounty"/> object with the specified three digit code.
        /// </summary>
        /// <param name="countyCode">Three-digit county code of the county.</param>
        /// <param name="stateAbbreviation">State abbreviation.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<MultichannelOrderManagerCounty>> GetCountyByCodeAsync(string countyCode, string stateAbbreviation, CancellationToken? cancellationToken = null);
    }
}
