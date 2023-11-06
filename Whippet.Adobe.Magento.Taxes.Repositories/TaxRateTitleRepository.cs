using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Taxes.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="TaxRateTitle"/> entity objects.
    /// </summary>
    public class TaxRateTitleRepository : MagentoEntityRepository<TaxRateTitle>, ITaxRateTitleRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRateTitleRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public TaxRateTitleRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxRateTitleRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public TaxRateTitleRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Gets the <see cref="TaxRateTitle"/> object with the specified ID.
        /// </summary>
        /// <param name="key"><see cref="TaxRateTitle"/> ID.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        public virtual WhippetResultContainer<TaxRateTitle> Get(int key)
        {
            return Get(Convert.ToUInt32(key));
        }

        /// <summary>
        /// Gets the <see cref="TaxRateTitle"/> with the specified ID.
        /// </summary>
        /// <param name="key">Entity ID.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public virtual async Task<WhippetResultContainer<TaxRateTitle>> GetAsync(int key, CancellationToken? cancellationToken = null)
        {
            return await GetAsync(Convert.ToUInt32(key), cancellationToken); 
        }
    }
}
