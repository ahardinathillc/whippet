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
    /// Represents a data repository for managing <see cref="InvariantAddress"/> entity objects.
    /// </summary>
    public interface IInvariantAddressRepository : IWhippetEntityRepository<InvariantAddress, Guid>, IWhippetRepository<InvariantAddress, Guid>, IWhippetQueryRepository<InvariantAddress>
    {
        /// <summary>
        /// Gets the <see cref="InvariantAddress"/> objects for the specified <see cref="ICity"/>.
        /// </summary>
        /// <param name="city"><see cref="ICity"/> to retrieve addresses for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<InvariantAddress>> Get(ICity city);

        /// <summary>
        /// Gets the <see cref="InvariantAddress"/> objects for the specified <see cref="ICity"/>.
        /// </summary>
        /// <param name="city"><see cref="ICity"/> to retrieve addresses for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<InvariantAddress>>> GetAsync(ICity city, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets the <see cref="InvariantAddress"/> objects for the specified <see cref="IPostalCode"/>.
        /// </summary>
        /// <param name="postalCode"><see cref="IPostalCode"/> to retrieve addresses for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<InvariantAddress>> Get(IPostalCode postalCode);

        /// <summary>
        /// Gets the <see cref="InvariantAddress"/> objects for the specified <see cref="IPostalCode"/>.
        /// </summary>
        /// <param name="postalCode"><see cref="IPostalCode"/> to retrieve addresses for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<InvariantAddress>>> GetAsync(IPostalCode postalCode, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets the <see cref="InvariantAddress"/> object with the specified parameters.
        /// </summary>
        /// <param name="lineOne">First line of the address.</param>
        /// <param name="lineTwo">Second line of the address.</param>
        /// <param name="lineThree">Third line of the address.</param>
        /// <param name="lineFour">Fourth line of the address.</param>
        /// <param name="city"><see cref="ICity"/> the address belongs to.</param>
        /// <param name="postalCode"><see cref="IPostalCode"/> to retrieve addresses for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<InvariantAddress> Get(string lineOne, string lineTwo, string lineThree, string lineFour, ICity city, IPostalCode postalCode);

        /// <summary>
        /// Gets the <see cref="InvariantAddress"/> object with the specified parameters.
        /// </summary>
        /// <param name="lineOne">First line of the address.</param>
        /// <param name="lineTwo">Second line of the address.</param>
        /// <param name="lineThree">Third line of the address.</param>
        /// <param name="lineFour">Fourth line of the address.</param>
        /// <param name="city"><see cref="ICity"/> the address belongs to.</param>
        /// <param name="postalCode"><see cref="IPostalCode"/> to retrieve addresses for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        Task<WhippetResultContainer<InvariantAddress>> GetAsync(string lineOne, string lineTwo, string lineThree, string lineFour, ICity city, IPostalCode postalCode, CancellationToken? cancellationToken = null);
    }
}
