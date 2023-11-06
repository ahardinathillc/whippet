using System;
using FluentNHibernate.Data;
using NodaTime;
using Athi.Whippet;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="MultichannelOrderManagerStateProvince"/> entity objects.
    /// </summary>
    public interface IMultichannelOrderManagerStateProvinceRepository : IWhippetEntityRepository<MultichannelOrderManagerStateProvince, long>, IWhippetQueryRepository<MultichannelOrderManagerStateProvince>, IWhippetExternalQueryRepository<MultichannelOrderManagerStateProvince, long>
    {
        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerStateProvince"/> objects.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<MultichannelOrderManagerStateProvince>> GetStateProvinces();

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerStateProvince"/> objects.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerStateProvince>>> GetStateProvincesAsync(CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerStateProvince"/> objects for the specified <see cref="IMultichannelOrderManagerCountry"/>.
        /// </summary>
        /// <param name="country"><see cref="IMultichannelOrderManagerCountry"/> to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<MultichannelOrderManagerStateProvince>> GetStateProvinces(IMultichannelOrderManagerCountry country);

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerStateProvince"/> objects for the specified <see cref="IMultichannelOrderManagerCountry"/>.
        /// </summary>
        /// <param name="country"><see cref="IMultichannelOrderManagerCountry"/> to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerStateProvince>>> GetStateProvincesAsync(IMultichannelOrderManagerCountry country, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets the <see cref="MultichannelOrderManagerStateProvince"/> object with the specified <see cref="IMultichannelOrderManagerPostalCode"/>.
        /// </summary>
        /// <param name="postalCode"><see cref="IMultichannelOrderManagerPostalCode"/> object to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<MultichannelOrderManagerStateProvince> GetStateProvinceByPostalCode(IMultichannelOrderManagerPostalCode postalCode);

        /// <summary>
        /// Gets the <see cref="MultichannelOrderManagerStateProvince"/> object with the specified <see cref="IMultichannelOrderManagerPostalCode"/>.
        /// </summary>
        /// <param name="postalCode"><see cref="IMultichannelOrderManagerPostalCode"/> object to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<MultichannelOrderManagerStateProvince>> GetStateProvinceByPostalCodeAsync(IMultichannelOrderManagerPostalCode postalCode, CancellationToken? cancellationToken = null);
    }
}
