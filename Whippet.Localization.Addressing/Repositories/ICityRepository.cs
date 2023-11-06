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
    /// Represents a data repository for managing <see cref="City"/> entity objects.
    /// </summary>
    public interface ICityRepository : IWhippetEntityRepository<City, Guid>, IWhippetRepository<City, Guid>, IWhippetQueryRepository<City>
    {
        /// <summary>
        /// Gets all <see cref="City"/> objects with the specified name.
        /// </summary>
        /// <param name="name">Name of the <see cref="City"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<City>> Get(string name);

        /// <summary>
        /// Gets all <see cref="City"/> objects with the specified name.
        /// </summary>
        /// <param name="name">Name of the <see cref="City"/> object to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        Task<WhippetResultContainer<IEnumerable<City>>> GetAsync(string name, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets the <see cref="City"/> object with the specified name and parent <see cref="IStateProvince"/>.
        /// </summary>
        /// <param name="name">Name of the <see cref="City"/> object to retrieve.</param>
        /// <param name="stateProvince"><see cref="IStateProvince"/> the city belongs to.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<City> Get(string name, IStateProvince stateProvince);

        /// <summary>
        /// Gets the <see cref="City"/> object with the specified name and parent <see cref="IStateProvince"/>.
        /// </summary>
        /// <param name="name">Name of the <see cref="City"/> object to retrieve.</param>
        /// <param name="stateProvince"><see cref="IStateProvince"/> the city belongs to.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        Task<WhippetResultContainer<City>> GetAsync(string name, IStateProvince stateProvince, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets all <see cref="City"/> objects that belong to the specified <see cref="IStateProvince"/>.
        /// </summary>
        /// <param name="stateProvince"><see cref="IStateProvince"/> to retrieve cities for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<City>> Get(IStateProvince stateProvince);

        /// <summary>
        /// Gets all <see cref="City"/> objects that belong to the specified <see cref="IStateProvince"/>.
        /// </summary>
        /// <param name="stateProvince"><see cref="IStateProvince"/> to retrieve cities for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<City>>> GetAsync(IStateProvince stateProvince, CancellationToken? cancellationToken = null);
    }
}
