using System;
using System.Collections.Generic;
using NHibernate;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants;

namespace Athi.Whippet.SuperDuper.DigitalLibrary.Legacy.Repositories
{
    /// <summary>
    /// Repository for <see cref="LegacyDigitalLibraryServer"/> objects. 
    /// </summary>
    public class LegacyDigitalLibraryServerRepository : WhippetEntityRepository<LegacyDigitalLibraryServer>, ILegacyDigitalLibraryServerRepository, IWhippetTenantRepositoryFilter<LegacyDigitalLibraryServer, Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LegacyDigitalLibraryServerRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public LegacyDigitalLibraryServerRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="LegacyDigitalLibraryServerRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public LegacyDigitalLibraryServerRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Retrieves all items of <see cref="LegacyDigitalLibraryServer"/> type in the data store.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding items (if any).</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual WhippetResultContainer<IEnumerable<LegacyDigitalLibraryServer>> GetAll(IWhippetTenant tenant)
        {
            ArgumentNullException.ThrowIfNull(tenant);
            return Task.Run(() => GetAllAsync(tenant)).Result;
        }

        /// <summary>
        /// Asynchronously retrieves all items of <see cref="LegacyDigitalLibraryServer"/> type in the data store.
        /// </summary>
        /// <param name="tenant"><see cref="IWhippetTenant"/> object to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<LegacyDigitalLibraryServer>>> GetAllAsync(IWhippetTenant tenant, CancellationToken? cancellationToken = null)
        {
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            else
            {
                WhippetResultContainer<IEnumerable<LegacyDigitalLibraryServer>> result = null;
                IList<LegacyDigitalLibraryServer> queryResults = null;

                try
                {
                    queryResults = await Context.QueryOver<LegacyDigitalLibraryServer>()
                        .JoinQueryOver<WhippetTenant>(sddl => sddl.Tenant)
                        .Where(t => t.ID == tenant.ID)
                        .ListAsync();

                    result = new WhippetResultContainer<IEnumerable<LegacyDigitalLibraryServer>>(WhippetResult.Success, queryResults);
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<LegacyDigitalLibraryServer>>(e);
                }

                return result;
            }
        }
    }
}
