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
    /// Represents a data repository for managing <see cref="SalesforceCampaign"/> entity objects.
    /// </summary>
    public interface ISalesforceCampaignRepository : IWhippetEntityRepository<SalesforceCampaign, SalesforceReference>, IWhippetRepository<SalesforceCampaign, SalesforceReference>, IWhippetQueryRepository<SalesforceCampaign>
    {
        /// <summary>
        /// Retrieves all <see cref="SalesforceCampaign"/> objects with the specified campaign name.
        /// </summary>
        /// <param name="campaignName">Campaign name of the <see cref="SalesforceCampaign"/>.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        WhippetResultContainer<IEnumerable<SalesforceCampaign>> GetByName(string campaignName);

        /// <summary>
        /// Retrieves all <see cref="SalesforceCampaign"/> objects with the specified campaign name.
        /// </summary>
        /// <param name="campaignName">Campaign name of the <see cref="SalesforceCampaign"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        Task<WhippetResultContainer<IEnumerable<SalesforceCampaign>>> GetByNameAsync(string campaignName, CancellationToken? cancellationToken = null);
    }
}
