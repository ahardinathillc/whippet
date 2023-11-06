using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using Athi.Whippet;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Localization.Addressing.Repositories
{
    /// <summary>
    /// Represents a data repository for managing <see cref="StateProvince"/> entity objects.
    /// </summary>
    public interface IStateProvinceRepository : IWhippetEntityRepository<StateProvince, Guid>, IWhippetRepository<StateProvince, Guid>, IWhippetQueryRepository<StateProvince>
    {
        /// <summary>
        /// Gets all <see cref="StateProvince"/> objects for the specified <see cref="ICountry"/>.
        /// </summary>
        /// <param name="country"><see cref="ICountry"/> object to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        WhippetResultContainer<IEnumerable<StateProvince>> GetAll(ICountry country);

        /// <summary>
        /// Gets all <see cref="StateProvince"/> objects for the specified <see cref="ICountry"/>.
        /// </summary>
        /// <param name="country"><see cref="ICountry"/> object to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        Task<WhippetResultContainer<IEnumerable<StateProvince>>> GetAllAsync(ICountry country, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets the <see cref="StateProvince"/> object with the specified name.
        /// </summary>
        /// <param name="name">Name of the <see cref="StateProvince"/> object to retrieve.</param>
        /// <param name="country"><see cref="ICountry"/> that the <see cref="StateProvince"/> is located in.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        WhippetResultContainer<StateProvince> Get(string name, ICountry country);

        /// <summary>
        /// Gets the <see cref="StateProvince"/> object with the specified name.
        /// </summary>
        /// <param name="name">Name of the <see cref="StateProvince"/> object to retrieve.</param>
        /// <param name="country"><see cref="ICountry"/> that the <see cref="StateProvince"/> is located in.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        Task<WhippetResultContainer<StateProvince>> GetAsync(string name, ICountry country, CancellationToken? cancellationToken = null);
    }
}
