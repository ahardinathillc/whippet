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
    /// Represents a data repository for managing <see cref="SalesforceAccount"/> entity objects.
    /// </summary>
    public interface ISalesforceAccountRepository : IWhippetEntityRepository<SalesforceAccount, SalesforceReference>, IWhippetRepository<SalesforceAccount, SalesforceReference>, IWhippetQueryRepository<SalesforceAccount>
    {
        /// <summary>
        /// Retrieves all <see cref="SalesforceAccount"/> objects with the specified account name.
        /// </summary>
        /// <param name="accountName">Account name of the <see cref="SalesforceAccount"/>.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        WhippetResultContainer<IEnumerable<SalesforceAccount>> GetByName(string accountName);

        /// <summary>
        /// Retrieves all <see cref="SalesforceAccount"/> objects with the specified account name.
        /// </summary>
        /// <param name="accountName">Account name of the <see cref="SalesforceAccount"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        Task<WhippetResultContainer<IEnumerable<SalesforceAccount>>> GetByNameAsync(string accountName, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Retrieves all <see cref="SalesforceAccount"/> objects that contain the specified account name or search criteria.
        /// </summary>
        /// <param name="accountName">Account name of the <see cref="SalesforceAccount"/> or search criteria.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        WhippetResultContainer<IEnumerable<SalesforceAccount>> GetLikeName(string accountName);

        /// <summary>
        /// Retrieves all <see cref="SalesforceAccount"/> objects that contain the specified account name or search criteria.
        /// </summary>
        /// <param name="accountName">Account name of the <see cref="SalesforceAccount"/> or search criteria.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        Task<WhippetResultContainer<IEnumerable<SalesforceAccount>>> GetLikeNameAsync(string accountName, CancellationToken? cancellationToken = null);
    }
}
