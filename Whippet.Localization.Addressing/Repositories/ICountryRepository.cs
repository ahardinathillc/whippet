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
    /// Represents a data repository for managing <see cref="Country"/> entity objects.
    /// </summary>
    public interface ICountryRepository : IWhippetEntityRepository<Country, Guid>, IWhippetRepository<Country, Guid>, IWhippetQueryRepository<Country>
    {
        /// <summary>
        /// Gets the <see cref="Country"/> object with the specified name.
        /// </summary>
        /// <param name="name">Name of the <see cref="Country"/> object to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<Country> Get(string name);

        /// <summary>
        /// Gets the <see cref="Country"/> object with the specified name.
        /// </summary>
        /// <param name="name">Name of the <see cref="Country"/> object to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        Task<WhippetResultContainer<Country>> GetAsync(string name, CancellationToken? cancellationToken = null);
    }
}
