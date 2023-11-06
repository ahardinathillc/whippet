using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Athi.Whippet.Adobe.Magento.Data;
using Athi.Whippet.Adobe.Magento.Directory.Repositories.Extensions;

namespace Athi.Whippet.Adobe.Magento.Directory.Repositories
{
    /// <summary>
    /// Represents a data repository for mapping <see cref="RegionName"/> entity objects.
    /// </summary>
    public class RegionNameRepository : MagentoEntityRepository<RegionName>, IRegionNameRepository
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
        /// Initializes a new instance of the <see cref="RegionNameRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public RegionNameRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegionNameRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public RegionNameRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="regionNameKey">Unique ID of the entity.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="NotImplementedException" />
        public override WhippetResultContainer<RegionName> Get(uint regionNameKey)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not supported.
        /// </summary>
        /// <param name="regionNameKey">Unique ID of the entity.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="NotImplementedException" />
        public override Task<WhippetResultContainer<RegionName>> GetAsync(uint regionNameKey, CancellationToken? cancellationToken = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="regionNameKey">Unique ID of the entity.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public virtual WhippetResultContainer<RegionName> Get(RegionNameKey regionNameKey)
        {
            return Task.Run(() => GetAsync(regionNameKey)).Result;
        }

        /// <summary>
        /// Asynchronously gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="regionNameKey">Unique ID of the entity.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public virtual async Task<WhippetResultContainer<RegionName>> GetAsync(RegionNameKey regionNameKey, CancellationToken? cancellationToken = null)
        {
            IQuery query = Context.CreateGetRegionNameQuery(regionNameKey);
            IList<RegionName> queryResults = await query.ListAsync<RegionName>();

            return new WhippetResultContainer<RegionName>(WhippetResult.Success, queryResults.FirstOrDefault());
        }
    }
}
