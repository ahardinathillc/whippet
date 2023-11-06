using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Athi.Whippet.Data;
using Athi.Whippet.Security.EntityMappings.Tenants;
using Athi.Whippet.Security.EntityMappings.Extensions;
using Athi.Whippet.Security.Tenants.Extensions;

namespace Athi.Whippet.Security.Tenants.Repositories
{
    /// <summary>
    /// Repository for <see cref="WhippetTenant"/> objects.
    /// </summary>
    public class WhippetTenantRepository : WhippetEntityRepository<WhippetTenant>, IWhippetTenantRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetTenantRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an abstraction of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetTenantRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetTenantRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an abstraction of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless abstraction of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public WhippetTenantRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Creates the root tenant.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public virtual WhippetResultContainer<WhippetTenant> CreateRootTenant()
        {
            return Task.Run(() => CreateRootTenantAsync()).Result;
        }

        /// <summary>
        /// Creates the root tenant.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public virtual async Task<WhippetResultContainer<WhippetTenant>> CreateRootTenantAsync(CancellationToken? cancellationToken = null)
        {
            WhippetTenant rootTenant = null;

            WhippetResultContainer<WhippetTenant> result = null;
            WhippetResult queryResult = WhippetResult.Success;

            WhippetTenantMap tenantMap = null;

            Guid rootTenantId = Guid.Empty;

            int updatedRows = 0;

            rootTenant = WhippetTenant.Root.ToWhippetTenant();
            rootTenantId = rootTenant.ID;

            // check to see if one exists already

            result = await GetAsync(rootTenantId);

            if (result.IsSuccess)
            {
                if (!result.HasItem)
                {
                    // create the initial record
                    queryResult = await CreateAsync(rootTenant);

                    if (queryResult.IsSuccess)
                    {
                        try
                        {
                            await CommitAsync();

                            tenantMap = new WhippetTenantMap();
                            updatedRows = await tenantMap.CreateUpdateNonInteractiveTenantQuery(Context, rootTenant.ID, rootTenantId).ExecuteUpdateAsync();

                            rootTenant.ID = rootTenantId;
                        }
                        catch (Exception e)
                        {
                            result = new WhippetResultContainer<WhippetTenant>(new WhippetResult(e), rootTenant);
                        }
                    }
                    else
                    {
                        result = new WhippetResultContainer<WhippetTenant>(queryResult, rootTenant);
                    }
                }
            }

            return result;
        }
    }
}
