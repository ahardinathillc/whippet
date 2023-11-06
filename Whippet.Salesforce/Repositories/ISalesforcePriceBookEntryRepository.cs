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
    /// Represents a data repository for managing <see cref="SalesforcePriceBookEntry"/> entity objects.
    /// </summary>
    public interface ISalesforcePriceBookEntryRepository : IWhippetEntityRepository<SalesforcePriceBookEntry, SalesforceReference>, IWhippetRepository<SalesforcePriceBookEntry, SalesforceReference>, IWhippetQueryRepository<SalesforcePriceBookEntry>
    {
        /// <summary>
        /// Retrieves all <see cref="SalesforcePriceBookEntry"/> objects with the specified <see cref="ISalesforcePriceBook"/> ID.
        /// </summary>
        /// <param name="priceBookId"><see cref="ISalesforcePriceBook"/> ID.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        WhippetResultContainer<IEnumerable<SalesforcePriceBookEntry>> GetForPriceBook(SalesforceReference priceBookId);

        /// <summary>
        /// Retrieves all <see cref="SalesforcePriceBookEntry"/> objects with the specified <see cref="ISalesforcePriceBook"/> ID.
        /// </summary>
        /// <param name="priceBookId"><see cref="ISalesforcePriceBook"/> ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        Task<WhippetResultContainer<IEnumerable<SalesforcePriceBookEntry>>> GetForPriceBookAsync(SalesforceReference priceBookId, CancellationToken? cancellationToken = null);
    }
}
