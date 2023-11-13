using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Criterion;
using Athi.Whippet.Threading.Tasks.Extensions;
using Athi.Whippet.Data;
using Athi.Whippet.Security.Tenants;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.EntityMappings;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.Repositories
{
    /// <summary>
    /// Represents a data repository for managing <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> objects.
    /// </summary>
    public class MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryRepository : WhippetEntityRepository<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>, IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <exception cref="ArgumentNullException" />
        public MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryRepository(ISession context)
            : base(context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryRepository"/> class with the specified <see cref="ISession"/> object which provides context for the NHibernate connection.
        /// </summary>
        /// <param name="context"><see cref="ISession"/> object which provides an override of the NHibernate context.</param>
        /// <param name="statelessContext"><see cref="IStatelessSession"/> object which provides a cacheless override of the NHibernate context. This context is primarily used for bulk operations.</param>
        /// <exception cref="ArgumentNullException" />
        public MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryRepository(ISession context, IStatelessSession statelessContext)
            : base(context, statelessContext)
        { }

        /// <summary>
        /// Gets the total number of entries for the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> to get the total number of entries for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual WhippetResultContainer<long> GetEntryCountForCache(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache)
        {
            ArgumentNullException.ThrowIfNull(cache);
            return Task.Run(() => GetEntryCountForCacheAsync(cache)).Result;
        }

        /// <summary>
        /// Gets the total number of entries for the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> to get the total number of entries for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<long>> GetEntryCountForCacheAsync(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache, CancellationToken? cancellationToken = null)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            else
            {
                long rowCount = await Context.QueryOver<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>()
                    .JoinQueryOver<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>(c => c.Cache)
                    .JoinQueryOver<MultichannelOrderManagerServer>(c => c.SourceServer)
                    .JoinQueryOver<WhippetTenant>(s => s.Tenant)
                    .RowCountInt64Async(cancellationToken.GetValueOrDefault());

                return new WhippetResultContainer<long>(WhippetResult.Success, rowCount);
            }
        }

        /// <summary>
        /// Gets a set amount of <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> objects from the specified starting index for an <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object.</param>
        /// <param name="startingIndex">Starting index from which to start collecting records.</param>
        /// <param name="count">Total number of records to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public virtual WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>> GetPayload(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache, int startingIndex, int count)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            else if (startingIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startingIndex));
            }
            else if (count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }
            else
            {
                return Task.Run(() => GetPayloadAsync(cache, startingIndex, count)).Result;
            }
        }

        /// <summary>
        /// Gets a set amount of <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> objects from the specified starting index for an <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object.</param>
        /// <param name="startingIndex">Starting index from which to start collecting records.</param>
        /// <param name="count">Total number of records to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>>> GetPayloadAsync(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache, int startingIndex, int count, CancellationToken? cancellationToken = null)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            else if (startingIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startingIndex));
            }
            else if (count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }
            else
            {
                MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry entryAlias = null;
                MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cacheAlias = null;
                MultichannelOrderManagerServer serverAlias = null;
                WhippetTenant tenantAlias = null;

                IList<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry> queryResults = await Context.QueryOver<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>(() => entryAlias)
                    .JoinAlias(c => c.Cache, () => cacheAlias)
                    .Where(() => cacheAlias.ID == cache.ID)
                    .JoinAlias(() => cacheAlias.SourceServer, () => serverAlias)
                    .JoinAlias(() => serverAlias.Tenant, () => tenantAlias)
                    .OrderByAlias(() => entryAlias.ID).Asc
                    .Skip(startingIndex)
                    .Take(count)
                    .ListAsync();

                return new WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>>(WhippetResult.Success, queryResults);
            }
        }
        
        /// <summary>
        /// Gets all <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> objects for the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> to get entries for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>> Get(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            else
            {
                return Task.Run(() => GetAsync(cache)).Result;
            }
        }

        /// <summary>
        /// Gets all <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> objects for the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> to get entries for.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>>> GetAsync(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache, CancellationToken? cancellationToken = null)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            else
            {
                IList<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry> queryResults = await Context.QueryOver<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>()
                    .JoinQueryOver<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache>(c => c.Cache)
                    .JoinQueryOver<MultichannelOrderManagerServer>(c => c.SourceServer)
                    .JoinQueryOver<WhippetTenant>(s => s.Tenant)
                    .ListAsync(cancellationToken.GetValueOrDefault());

                return new WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>>(WhippetResult.Success, queryResults);
            }
        }

        /// <summary>
        /// Deletes all <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> objects for the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> to delete all entries from.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<long> Delete(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            else
            {
                return Task.Run(() => Delete(cache)).Result;
            }
        }

        /// <summary>
        /// Deletes all <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> objects for the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> to delete all entries from.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<long>> DeleteAsync(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache, CancellationToken? cancellationToken = null)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            else
            {
                WhippetResultContainer<long> result = null;
                MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryMap entryMap = new MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryMap();

                ISQLQuery query = Context.CreateSQLQuery(String.Format("DELETE FROM {0} WHERE {1}='{2}'", entryMap.FullyQualifiedTableName, "Cache_id", cache.ID.ToString()));

                result = new WhippetResultContainer<long>(WhippetResult.Success, Convert.ToInt64(await query.UniqueResultAsync<long>(cancellationToken.GetValueOrDefault())));

                return result;
            }
        }
    }
}
