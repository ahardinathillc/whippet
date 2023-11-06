using System;
using FluentNHibernate.Data;
using NodaTime;
using Athi.Whippet;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="MultichannelOrderManagerPostalCode"/> entity objects.
    /// </summary>
    public interface IMultichannelOrderManagerPostalCodeRepository : IWhippetEntityRepository<MultichannelOrderManagerPostalCode, long>, IWhippetQueryRepository<MultichannelOrderManagerPostalCode>, IWhippetExternalQueryRepository<MultichannelOrderManagerPostalCode, long>
    {
        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerPostalCode"/> objects for the specified <see cref="IMultichannelOrderManagerCountry"/>.
        /// </summary>
        /// <param name="country"><see cref="IMultichannelOrderManagerCountry"/> to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<MultichannelOrderManagerPostalCode>> GetPostalCodes(IMultichannelOrderManagerCountry country);

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerPostalCode"/> objects for the specified <see cref="IMultichannelOrderManagerCountry"/>.
        /// </summary>
        /// <param name="country"><see cref="IMultichannelOrderManagerCountry"/> to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerPostalCode>>> GetPostalCodesAsync(IMultichannelOrderManagerCountry country, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerPostalCode"/> objects for the specified <see cref="IMultichannelOrderManagerCountry"/>.
        /// </summary>
        /// <param name="stateProvince"><see cref="IMultichannelOrderManagerStateProvince"/> to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<MultichannelOrderManagerPostalCode>> GetPostalCodes(IMultichannelOrderManagerStateProvince stateProvince);

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerPostalCode"/> objects for the specified <see cref="IMultichannelOrderManagerCountry"/>.
        /// </summary>
        /// <param name="stateProvince"><see cref="IMultichannelOrderManagerStateProvince"/> to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerPostalCode>>> GetPostalCodesAsync(IMultichannelOrderManagerStateProvince stateProvince, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerPostalCode"/> objects that match the specified postal code.
        /// </summary>
        /// <param name="postalCode">Postal code value to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<MultichannelOrderManagerPostalCode>> GetPostalCodes(string postalCode);

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerPostalCode"/> objects that match the specified postal code.
        /// </summary>
        /// <param name="postalCode">Postal code value to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerPostalCode>>> GetPostalCodesAsync(string postalCode, CancellationToken? cancellationToken = null);

    }
}
