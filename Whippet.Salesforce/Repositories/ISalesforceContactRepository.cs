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
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.Salesforce.Repositories
{
    /// <summary>
    /// Represents a data repository for managing <see cref="SalesforceContact"/> entity objects.
    /// </summary>
    public interface ISalesforceContactRepository : IWhippetEntityRepository<SalesforceContact, SalesforceReference>, IWhippetRepository<SalesforceContact, SalesforceReference>, IWhippetQueryRepository<SalesforceContact>
    {
        /// <summary>
        /// Retrieves all <see cref="SalesforceContact"/> objects for the specified <see cref="ISalesforceAccount"/>.
        /// </summary>
        /// <param name="account"><see cref="ISalesforceAccount"/> object to get all <see cref="SalesforceContact"/> objects for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        WhippetResultContainer<IEnumerable<SalesforceContact>> GetAllForAccount(ISalesforceAccount account);

        /// <summary>
        /// Retrieves all <see cref="SalesforceContact"/> objects for the specified <see cref="ISalesforceAccount"/>.
        /// </summary>
        /// <param name="account"><see cref="ISalesforceAccount"/> object to get all <see cref="SalesforceContact"/> objects for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        Task<WhippetResultContainer<IEnumerable<SalesforceContact>>> GetAllForAccountAsync(ISalesforceAccount account, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Retrieves all <see cref="SalesforceContact"/> objects for the specified <see cref="ISalesforceAccount"/> based on the <see cref="SalesforceContact.LastName"/> value.
        /// </summary>
        /// <param name="account"><see cref="ISalesforceAccount"/> object to get all <see cref="SalesforceContact"/> objects for.</param>
        /// <param name="lastName"><see cref="SalesforceContact.LastName"/> value to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        WhippetResultContainer<IEnumerable<SalesforceContact>> GetByLastName(ISalesforceAccount account, string lastName);

        /// <summary>
        /// Retrieves all <see cref="SalesforceContact"/> objects for the specified <see cref="ISalesforceAccount"/> based on the <see cref="SalesforceContact.LastName"/> value.
        /// </summary>
        /// <param name="account"><see cref="ISalesforceAccount"/> object to get all <see cref="SalesforceContact"/> objects for.</param>
        /// <param name="lastName"><see cref="SalesforceContact.LastName"/> value to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        Task<WhippetResultContainer<IEnumerable<SalesforceContact>>> GetByLastNameAsync(ISalesforceAccount account, string lastName, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Retrieves the <see cref="SalesforceContact"/> object with the specified first and last name for the given <see cref="ISalesforceAccount"/>.
        /// </summary>
        /// <param name="account"><see cref="ISalesforceAccount"/> object.</param>
        /// <param name="firstName">First name.</param>
        /// <param name="lastName">Last name.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<SalesforceContact>> GetByName(ISalesforceAccount account, string firstName, string lastName);

        /// <summary>
        /// Retrieves the <see cref="SalesforceContact"/> object with the specified first and last name for the given <see cref="ISalesforceAccount"/>.
        /// </summary>
        /// <param name="account"><see cref="ISalesforceAccount"/> object.</param>
        /// <param name="firstName">First name.</param>
        /// <param name="lastName">Last name.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<SalesforceContact>>> GetByNameAsync(ISalesforceAccount account, string firstName, string lastName, CancellationToken? cancellationToken = null);
    }
}
