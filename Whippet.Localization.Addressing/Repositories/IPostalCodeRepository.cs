using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Localization.Addressing.Repositories
{
    /// <summary>
    /// Represents a data repository for managing <see cref="PostalCode"/> entity objects.
    /// </summary>
    public interface IPostalCodeRepository : IWhippetEntityRepository<PostalCode, Guid>, IWhippetRepository<PostalCode, Guid>, IWhippetQueryRepository<PostalCode>
    {
        /// <summary>
        /// Gets the <see cref="PostalCode"/> objects with the specified value.
        /// </summary>
        /// <param name="value">Value of the <see cref="PostalCode"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<PostalCode>> Get(string value);

        /// <summary>
        /// Gets the <see cref="PostalCode"/> objects with the specified value.
        /// </summary>
        /// <param name="value">Value of the <see cref="PostalCode"/> object to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        Task<WhippetResultContainer<IEnumerable<PostalCode>>> GetAsync(string value, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets the <see cref="PostalCode"/> objects with the specified value.
        /// </summary>
        /// <param name="value">Value of the <see cref="PostalCode"/> object to retrieve.</param>
        /// <param name="city">City that the <see cref="PostalCode"/> is assigned to.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<PostalCode>> Get(string value, ICity city);

        /// <summary>
        /// Gets the <see cref="PostalCode"/> objects with the specified value.
        /// </summary>
        /// <param name="value">Value of the <see cref="PostalCode"/> object to retrieve.</param>
        /// <param name="city">City that the <see cref="PostalCode"/> is assigned to.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        Task<WhippetResultContainer<IEnumerable<PostalCode>>> GetAsync(string value, ICity city, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets the <see cref="PostalCode"/> objects for the specified city.
        /// </summary>
        /// <param name="city">City that the <see cref="PostalCode"/> is assigned to.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<PostalCode>> Get(ICity city);

        /// <summary>
        /// Gets the <see cref="PostalCode"/> objects for the specified city.
        /// </summary>
        /// <param name="city">City that the <see cref="PostalCode"/> is assigned to.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        Task<WhippetResultContainer<IEnumerable<PostalCode>>> GetAsync(ICity city, CancellationToken? cancellationToken = null);
    }
}
