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
    /// Represents a data repository for managing <see cref="SalesforceOpportunity"/> entity objects.
    /// </summary>
    public interface ISalesforceOpportunityRepository : IWhippetEntityRepository<SalesforceOpportunity, SalesforceReference>, IWhippetRepository<SalesforceOpportunity, SalesforceReference>, IWhippetQueryRepository<SalesforceOpportunity>
    {
        /// <summary>
        /// Retrieves all <see cref="SalesforceOpportunity"/> objects with the specified opportunity name.
        /// </summary>
        /// <param name="opportunityName">Opportunity name of the <see cref="SalesforceOpportunity"/>.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        WhippetResultContainer<IEnumerable<SalesforceOpportunity>> GetByName(string opportunityName);

        /// <summary>
        /// Retrieves all <see cref="SalesforceOpportunity"/> objects with the specified opportunity name.
        /// </summary>
        /// <param name="opportunityName">Opportunity name of the <see cref="SalesforceOpportunity"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        Task<WhippetResultContainer<IEnumerable<SalesforceOpportunity>>> GetByNameAsync(string opportunityName, CancellationToken? cancellationToken = null);
    }
}
