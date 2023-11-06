using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.EAV.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="StoreWebsite"/> entity objects.
    /// </summary>
    public class StoreWebsiteRepository : MagentoEntityRepository<StoreWebsite>, IStoreWebsiteRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StoreWebsiteRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public StoreWebsiteRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreWebsiteRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public StoreWebsiteRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="websiteId">Unique ID of the entity.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public override WhippetResultContainer<StoreWebsite> Get(uint websiteId)
        {
            return Get(ClampUnsignedInteger(websiteId));
        }

        /// <summary>
        /// Gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="websiteId">Unique ID of the entity.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public WhippetResultContainer<StoreWebsite> Get(ushort websiteId)
        {
            return Task.Run(() => GetAsync(websiteId)).Result;
        }

        /// <summary>
        /// Asynchronously gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="websiteId">Unique ID of the entity.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public override async Task<WhippetResultContainer<StoreWebsite>> GetAsync(uint websiteId, CancellationToken? cancellationToken = null)
        {
            return await GetAsync(ClampUnsignedInteger(websiteId), cancellationToken);
        }

        /// <summary>
        /// Asynchronously gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="websiteId">Unique ID of the entity.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public async Task<WhippetResultContainer<StoreWebsite>> GetAsync(ushort websiteId, CancellationToken? cancellationToken = null)
        {
            IList<StoreWebsite> queryResults = await Context.QueryOver<StoreWebsite>()
                .Where(sr => sr.WebsiteID == websiteId)
                .ListAsync();

            return new WhippetResultContainer<StoreWebsite>(WhippetResult.Success, queryResults.FirstOrDefault());
        }
    }
}
