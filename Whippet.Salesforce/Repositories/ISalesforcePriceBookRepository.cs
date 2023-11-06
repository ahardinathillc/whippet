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
    /// Represents a data repository for managing <see cref="SalesforcePriceBook"/> entity objects.
    /// </summary>
    public interface ISalesforcePriceBookRepository : IWhippetEntityRepository<SalesforcePriceBook, SalesforceReference>, IWhippetRepository<SalesforcePriceBook, SalesforceReference>, IWhippetQueryRepository<SalesforcePriceBook>
    {
        /// <summary>
        /// Retrieves all <see cref="SalesforcePriceBook"/> objects with the specified price book name.
        /// </summary>
        /// <param name="priceBookName">Price Book name of the <see cref="SalesforcePriceBook"/>.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        WhippetResultContainer<IEnumerable<SalesforcePriceBook>> GetByName(string priceBookName);

        /// <summary>
        /// Retrieves all <see cref="SalesforcePriceBook"/> objects with the specified price book name.
        /// </summary>
        /// <param name="priceBookName">Price Book name of the <see cref="SalesforcePriceBook"/>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        Task<WhippetResultContainer<IEnumerable<SalesforcePriceBook>>> GetByNameAsync(string priceBookName, CancellationToken? cancellationToken = null);
    }
}
