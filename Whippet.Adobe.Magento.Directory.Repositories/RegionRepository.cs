using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Athi.Whippet.Adobe.Magento.Data;

namespace Athi.Whippet.Adobe.Magento.Directory.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="Region"/> entity objects.
    /// </summary>
    public class RegionRepository : MagentoEntityRepository<Region>, IRegionRepository
    {
        /// <summary>
        /// Gets the REST bearer token for the API server. This property is read-only.
        /// </summary>
        public string BearerToken
        {
            get
            {
                return String.Empty;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegionRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public RegionRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegionRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public RegionRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="regionId">Unique ID of the entity.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public override WhippetResultContainer<Region> Get(uint regionId)
        {
            return Task.Run(() => GetAsync(regionId)).Result;
        }

        /// <summary>
        /// Asynchronously gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="regionId">Unique ID of the entity.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public override async Task<WhippetResultContainer<Region>> GetAsync(uint regionId, CancellationToken? cancellationToken = null)
        {
            IList<Region> queryResults = await Context.QueryOver<Region>()
                .Where(sr => sr.ID == regionId)
                .ListAsync();

            return new WhippetResultContainer<Region>(WhippetResult.Success, queryResults.FirstOrDefault());
        }
    }
}
