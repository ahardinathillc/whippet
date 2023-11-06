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
    /// Represents a data repository for mapping <see cref="StoreGroup"/> entity objects.
    /// </summary>
    public class StoreGroupRepository : MagentoEntityRepository<StoreGroup>, IStoreGroupRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StoreGroupRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public StoreGroupRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreGroupRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public StoreGroupRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="groupId">Unique ID of the entity.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public override WhippetResultContainer<StoreGroup> Get(uint groupId)
        {
            return Get(ClampUnsignedInteger(groupId));
        }

        /// <summary>
        /// Gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="groupId">Unique ID of the entity.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public WhippetResultContainer<StoreGroup> Get(ushort groupId)
        {
            return Task.Run(() => GetAsync(groupId)).Result;
        }

        /// <summary>
        /// Asynchronously gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="groupId">Unique ID of the entity.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public override async Task<WhippetResultContainer<StoreGroup>> GetAsync(uint groupId, CancellationToken? cancellationToken = null)
        {
            return await GetAsync(ClampUnsignedInteger(groupId), cancellationToken);
        }

        /// <summary>
        /// Asynchronously gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="groupId">Unique ID of the entity.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public async Task<WhippetResultContainer<StoreGroup>> GetAsync(ushort groupId, CancellationToken? cancellationToken = null)
        {
            IList<StoreGroup> queryResults = await Context.QueryOver<StoreGroup>()
                .Where(sr => sr.GroupID == groupId)
                .ListAsync();

            return new WhippetResultContainer<StoreGroup>(WhippetResult.Success, queryResults.FirstOrDefault());
        }
    }
}
