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
    /// Represents a data repository for managing <see cref="SalesforceLead"/> entity objects.
    /// </summary>
    public interface ISalesforceLeadRepository : IWhippetEntityRepository<SalesforceLead, SalesforceReference>, IWhippetRepository<SalesforceLead, SalesforceReference>, IWhippetQueryRepository<SalesforceLead>
    {
        /// <summary>
        /// Retrieves all <see cref="SalesforceLead"/> objects based on the <see cref="SalesforceLead.LastName"/> value.
        /// </summary>
        /// <param name="lastName"><see cref="SalesforceLead.LastName"/> value to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        WhippetResultContainer<IEnumerable<SalesforceLead>> GetByLastName(string lastName);

        /// <summary>
        /// Retrieves all <see cref="SalesforceLead"/> objects based on the <see cref="SalesforceLead.LastName"/> value.
        /// </summary>
        /// <param name="lastName"><see cref="SalesforceLead.LastName"/> value to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        Task<WhippetResultContainer<IEnumerable<SalesforceLead>>> GetByLastNameAsync(string lastName, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Retrieves the <see cref="SalesforceLead"/> object with the specified first and last name.
        /// </summary>
        /// <param name="firstName">First name.</param>
        /// <param name="lastName">Last name.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        WhippetResultContainer<IEnumerable<SalesforceLead>> GetByName(string firstName, string lastName);

        /// <summary>
        /// Retrieves the <see cref="SalesforceLead"/> object with the specified first and last name.
        /// </summary>
        /// <param name="firstName">First name.</param>
        /// <param name="lastName">Last name.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        Task<WhippetResultContainer<IEnumerable<SalesforceLead>>> GetByNameAsync(string firstName, string lastName, CancellationToken? cancellationToken = null);
    }
}
