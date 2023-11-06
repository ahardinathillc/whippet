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
    /// Represents a data repository for managing <see cref="SalesforceProduct"/> entity objects.
    /// </summary>
    public interface ISalesforceProductRepository : IWhippetEntityRepository<SalesforceProduct, SalesforceReference>, IWhippetRepository<SalesforceProduct, SalesforceReference>, IWhippetQueryRepository<SalesforceProduct>
    {
        /// <summary>
        /// Retrieves all <see cref="SalesforceProduct"/> objects with the specified product SKU.
        /// </summary>
        /// <param name="sku">SKU of the <see cref="SalesforceProduct"/> object(s) to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        WhippetResultContainer<IEnumerable<SalesforceProduct>> GetByStockKeepingUnit(string sku);

        /// <summary>
        /// Retrieves all <see cref="SalesforceProduct"/> objects with the specified product SKU.
        /// </summary>
        /// <param name="sku">SKU of the <see cref="SalesforceProduct"/> object(s) to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        Task<WhippetResultContainer<IEnumerable<SalesforceProduct>>> GetByStockKeepingUnitAsync(string sku, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Retrieves all <see cref="SalesforceProduct"/> objects with the specified product name.
        /// </summary>
        /// <param name="productName">Name of the <see cref="SalesforceProduct"/>.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        WhippetResultContainer<IEnumerable<SalesforceProduct>> GetByName(string productName);

        /// <summary>
        /// Retrieves all <see cref="SalesforceProduct"/> objects with the specified product name.
        /// </summary>
        /// <param name="productName">Name of the <see cref="SalesforceProduct"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        Task<WhippetResultContainer<IEnumerable<SalesforceProduct>>> GetByNameAsync(string productName, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Retrieves all <see cref="SalesforceProduct"/> objects with the specified product external ID.
        /// </summary>
        /// <param name="externalID">External ID of the <see cref="SalesforceProduct"/>.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        WhippetResultContainer<IEnumerable<SalesforceProduct>> GetByExternalID(string externalID);

        /// <summary>
        /// Retrieves all <see cref="SalesforceProduct"/> objects with the specified product external ID.
        /// </summary>
        /// <param name="externalID">External ID of the <see cref="SalesforceProduct"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        Task<WhippetResultContainer<IEnumerable<SalesforceProduct>>> GetByExternalIDAsync(string externalID, CancellationToken? cancellationToken = null);
    }
}
