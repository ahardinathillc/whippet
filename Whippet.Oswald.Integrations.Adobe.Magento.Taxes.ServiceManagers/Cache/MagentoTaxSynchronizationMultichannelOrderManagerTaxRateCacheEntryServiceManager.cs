using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Nito.AsyncEx;
using Org.BouncyCastle.Tls;
using Athi.Whippet.Threading.Tasks.Extensions;
using Athi.Whippet.Collections.Extensions;
using Athi.Whippet.Collections.Concurrent.Extensions;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.Services;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Queries;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Commands;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Handlers.Commands;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Handlers.Queries;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.Repositories;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.Extensions;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> domain objects.
    /// </summary>
    public class MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryServiceManager : ServiceManager
    {
        /// <summary>
        /// Gets the <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryRepository EntryRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryServiceManager"/> class with the specified <see cref=""/>
        /// </summary>
        /// <param name="entryRepository"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryServiceManager(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryRepository entryRepository)
            : base()
        {
            if (entryRepository == null)
            {
                throw new ArgumentNullException(nameof(entryRepository));
            }
            else
            {
                EntryRepository = entryRepository;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryServiceManager"/> class with the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="entryRepository"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryRepository"/> object to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryServiceManager(IWhippetServiceContext serviceLocator, IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryRepository entryRepository)
            : base(serviceLocator)
        {
            if (entryRepository == null)
            {
                throw new ArgumentNullException(nameof(entryRepository));
            }
            else
            {
                EntryRepository = entryRepository;
            }
        }

        /// <summary>
        /// Gets the total number of entries in the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<long>> GetEntryCount(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            else
            {
                WhippetResultContainer<long> result = null;
                
                GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCountQueryHandler handler = null;
                WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>> countResult = null;

                handler = new GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCountQueryHandler(EntryRepository);
                countResult = await handler.HandleAsync(new GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCountQuery(cache));

                if (countResult.IsSuccess)
                {
                    result = new WhippetResultContainer<long>(WhippetResult.Success, countResult.Item.LongCount());
                }
                else
                {
                    result = new WhippetResultContainer<long>(countResult.Exception);
                }
                
                return result;
            }            
        }
        
        /// <summary>
        /// Gets the <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> based on the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>> GetEntry(Guid id)
        {
            GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryByIdQueryHandler handler = new GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryByIdQueryHandler(EntryRepository);
            WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>> result = await handler.HandleAsync(new GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryByIdQuery(id));
            return new WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Gets all <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> objects for the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>>> GetEntries(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            else
            {
                GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntriesForCacheQueryHandler handler = new GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntriesForCacheQueryHandler(EntryRepository);
                WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>> result = await handler.HandleAsync(new GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntriesForCacheQuery(cache));
                return new WhippetResultContainer<IEnumerable<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Creates a payload of <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> objects to return to a caller for processing.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> to retrieve entries from.</param>
        /// <param name="startingIndex">Starting index in <paramref name="cache"/> at which the payload should begin.</param>
        /// <param name="count">Number of items in <paramref name="cache"/> to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public virtual async Task<WhippetResultContainer<IEnumerable<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>>> GetPayload(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache, int startingIndex, int count)
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
                GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryPayloadQueryHandler handler = new GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryPayloadQueryHandler(EntryRepository);
                WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>> result = await handler.HandleAsync(new GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryPayloadQuery(cache, startingIndex, count));
                return new WhippetResultContainer<IEnumerable<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>>(result.Result, result.Item);
            }
        }
        
        /// <summary>
        /// Creates a new Magento tax rate cache entry.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> object to register in the data store.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> object.</returns>
        public virtual async Task<WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>> CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry cache, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommand> handler = new CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommandHandler(EntryRepository);

                try
                {
                    result = await handler.HandleAsync(new CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommand(cache.ToMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry()));

                    if (result.IsSuccess)
                    {
                        await EntryRepository.CommitAsync(cancellationToken);
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>(result, cache);
            }
        }

        /// <summary>
        /// Updates an existing Magento tax rate cache entry.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> object to update in the data store.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>> UpdateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry cache, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<UpdateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommand> handler = new UpdateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommandHandler(EntryRepository);

                try
                {
                    result = await handler.HandleAsync(new UpdateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommand(cache.ToMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry()));

                    if (result.IsSuccess)
                    {
                        await EntryRepository.CommitAsync(cancellationToken);
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>(result, cache);
            }
        }

        /// <summary>
        /// Deletes an existing Magento tax rate cache entry.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> object to delete in the data store.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>> DeleteMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry cache, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<DeleteMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommand> handler = new DeleteMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommandHandler(EntryRepository);

                try
                {
                    result = await handler.HandleAsync(new DeleteMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCommand(cache.ToMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry()));

                    if (result.IsSuccess)
                    {
                        await EntryRepository.CommitAsync(cancellationToken);
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>(result, cache);
            }
        }

        /// <summary>
        /// Deletes all <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> objects for the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object to delete entries for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the total number of rows deleted.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<long>> DeleteMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntries(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            else
            {
                DeleteAllMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntriesCommandHandler handler = new DeleteAllMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntriesCommandHandler(EntryRepository);
                WhippetResult result = await handler.HandleAsync(new DeleteAllMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntriesCommand(cache));

                return new WhippetResultContainer<long>(result, Convert.ToInt64(result.ResultObject));
            }
        }

        /// <summary>
        /// Determines if the cache needs refreshing.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<bool>> CacheNeedsRefreshing(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            else
            {
                GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCountQueryHandler handler = null;
                WhippetResultContainer<bool> result = null;
                WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>> countResult = null;

                handler = new GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCountQueryHandler(EntryRepository);
                countResult = await handler.HandleAsync(new GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCountQuery(cache));

                if (countResult.IsSuccess)
                {
                    result = new WhippetResultContainer<bool>(WhippetResult.Success, countResult.Item.LongCount() > 0);
                }
                else
                {
                    result = new WhippetResultContainer<bool>(countResult.Exception);
                }
                
                return result;
            }            
        }
        
        /// <summary>
        /// Determines if the internal <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> needs refreshing based on the specified number of entries from the external buffer cache.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object.</param>
        /// <param name="externalCacheEntryCount">Number of records from the external buffer cache.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public virtual async Task<WhippetResultContainer<bool>> CacheNeedsRefreshing(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache, long externalCacheEntryCount)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            else if (externalCacheEntryCount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(externalCacheEntryCount));
            }
            else
            {
                GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCountQueryHandler handler = null;
                WhippetResultContainer<bool> result = null;
                WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>> countResult = null;

                if (externalCacheEntryCount > 0)
                {
                    handler = new GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCountQueryHandler(EntryRepository);
                    countResult = await handler.HandleAsync(new GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntryCountQuery(cache));

                    if (countResult.IsSuccess)
                    {
                        result = new WhippetResultContainer<bool>(WhippetResult.Success, countResult.Item.LongCount() != externalCacheEntryCount);
                    }
                    else
                    {
                        result = new WhippetResultContainer<bool>(countResult.Exception);
                    }
                }
                
                return result;
            }
        }

        /// <summary>
        /// Assigns an <see cref="IMultichannelOrderManagerServer"/> to all entries in the specified <see cref="IEnumerable{T}"/> collection of <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> objects.
        /// </summary>
        /// <param name="exports"><see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> objects to fix.</param>
        /// <param name="momServer"><see cref="IMultichannelOrderManagerServer"/> object to assign.</param>
        /// <param name="momTaxServer"><see cref="IMultichannelOrderManagerServer"/> object that is the origin of the tax data that populates each entry. If <see langword="null"/>, <paramref name="momServer"/> will be used.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>>> AssignMultichannelOrderManagerServer(IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry> exports, IMultichannelOrderManagerServer momServer, IMultichannelOrderManagerServer momTaxServer = null)
        {
            if (exports == null)
            {
                throw new ArgumentNullException(nameof(exports));
            }
            else if (momServer == null)
            {
                throw new ArgumentNullException(nameof(momServer));
            }
            else
            {
                ConcurrentBag<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry> taxRates = null;
                AsyncCollection<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry> asyncTaxRates = null;

                WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>> result = null;

                ParallelOptions pOptions = null;

                int capacity = 0;

                if (exports.Any())
                {
                    try
                    {
                        if (!exports.TryGetNonEnumeratedCount(out capacity))
                        {
                            capacity = exports.Count();
                        }

                        taxRates = new ConcurrentBag<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>();
                        asyncTaxRates = new AsyncCollection<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>(taxRates, capacity);

                        pOptions = new ParallelOptions();
                        pOptions = pOptions.DetermineOptimalCoreCount();

                        if (momTaxServer == null)
                        {
                            momTaxServer = momServer;
                        }

                        await Parallel.ForEachAsync<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>(exports, pOptions, async (export, cancellationToken) =>
                        {
                            export.MultichannelOrderManagerSourceServer = momTaxServer;

                            export.Country.Server = momServer.ToMultichannelOrderManagerServer();
                            export.Country.Warehouse.Server = momServer.ToMultichannelOrderManagerServer();
                            export.StateProvince.Server = momServer.ToMultichannelOrderManagerServer();
                            export.StateProvince.Country.Server = momServer.ToMultichannelOrderManagerServer();
                            export.StateProvince.Warehouse.Server = momServer.ToMultichannelOrderManagerServer();
                            export.PostalCode.Server = momServer.ToMultichannelOrderManagerServer();
                            export.PostalCode.Warehouse.Server = momServer.ToMultichannelOrderManagerServer();
                            export.PostalCode.County.Server = momServer.ToMultichannelOrderManagerServer();
                            export.PostalCode.County.Warehouse.Server = momServer.ToMultichannelOrderManagerServer();
                            export.PostalCode.County.StateProvince.Server = momServer.ToMultichannelOrderManagerServer();
                            export.PostalCode.County.StateProvince.Warehouse.Server = momServer.ToMultichannelOrderManagerServer();
                            export.PostalCode.County.StateProvince.Country.Server = momServer.ToMultichannelOrderManagerServer();
                            export.PostalCode.County.StateProvince.Country.Warehouse.Server = momServer.ToMultichannelOrderManagerServer();
                            export.PostalCode.County.Country.Server = momServer.ToMultichannelOrderManagerServer();
                            export.PostalCode.County.Country.Warehouse.Server = momServer.ToMultichannelOrderManagerServer();

                            await asyncTaxRates.AddAsync(export);
                        });

                        result = new WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>>(WhippetResult.Success, taxRates);
                    }
                    catch (Exception e)
                    {
                        result = new WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>>(e);
                    }
                }

                return result;
            }
        }
        
        /// <summary>
        /// Fixes up missing warehouse data in the specified <see cref="IEnumerable{T}"/> collection of <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> objects.
        /// </summary>
        /// <param name="exports"><see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> objects to fix.</param>
        /// <param name="warehouses"><see cref="IMultichannelOrderManagerWarehouse"/> collection.</param>
        /// <param name="defaultWarehouse">Default <see cref="IMultichannelOrderManagerWarehouse"/> to assign if value could not be found.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>>> FixUpMissingWarehouses(IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry> exports, IEnumerable<IMultichannelOrderManagerWarehouse> warehouses, IMultichannelOrderManagerWarehouse defaultWarehouse)
        {
            if (exports == null)
            {
                throw new ArgumentNullException(nameof(exports));
            }
            else if (warehouses == null)
            {
                throw new ArgumentNullException(nameof(warehouses));
            }
            else if (defaultWarehouse == null)
            {
                throw new ArgumentNullException(nameof(defaultWarehouse));
            }
            else
            {
                int capacity = 0;

                ConcurrentBag<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry> taxRates = null;
                AsyncCollection<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry> asyncTaxRates = null;

                WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>> result = null;

                ParallelOptions pOptions = null;

                IList<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry> filteredExports = null;
                IList<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry> goodExports = null;

                try
                {
                    if (exports.Any())
                    {
                        if (!exports.TryGetNonEnumeratedCount(out capacity))
                        {
                            capacity = exports.Count();
                        }

                        taxRates = new ConcurrentBag<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>();
                        asyncTaxRates = new AsyncCollection<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>(taxRates, capacity);

                        filteredExports = new List<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>(capacity);
                        goodExports = new List<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>(capacity);

                        pOptions = new ParallelOptions();
                        pOptions = pOptions.DetermineOptimalCoreCount();

                        filteredExports.AddRange((
                            from e in exports
                            where (
                                ((e.Country.Warehouse == null) || (e.Country.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.Country.Warehouse.Code))) 
                                    || ((e.StateProvince.Warehouse == null) || (e.StateProvince.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.StateProvince.Warehouse.Code)) || (e.StateProvince.Country.Warehouse == null) || (e.StateProvince.Country.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.StateProvince.Country.Warehouse.Code)))
                                    || ((e.PostalCode.Warehouse == null) || (e.PostalCode.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.Warehouse.Code)) || (e.PostalCode.County.Warehouse == null) || (e.PostalCode.County.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.Warehouse.Code)))
                                    || ((e.PostalCode.County.StateProvince.Warehouse == null) || (e.PostalCode.County.StateProvince.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Warehouse.Code)) || (e.PostalCode.County.StateProvince.Warehouse == null) || (e.PostalCode.County.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.Warehouse.Code)))
                                    || ((e.PostalCode.County.Country.Warehouse == null) || (e.PostalCode.County.Country.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.Country.Warehouse.Code)) || (e.PostalCode.County.Country.Warehouse == null) || (e.PostalCode.County.Country.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.Country.Warehouse.Code)))
                                    || ((e.PostalCode.County.StateProvince.Warehouse == null) || (e.PostalCode.County.StateProvince.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Warehouse.Code)) || (e.PostalCode.County.StateProvince.Warehouse == null) || (e.PostalCode.County.StateProvince.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Warehouse.Code)))
                                    || ((e.PostalCode.County.StateProvince.Country.Warehouse == null) || (e.PostalCode.County.StateProvince.Country.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Country.Warehouse.Code)) || (e.PostalCode.County.StateProvince.Country.Warehouse == null) || (e.PostalCode.County.StateProvince.Country.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Country.Warehouse.Code)))
                                )
                            select e
                        ).AsParallel());

                        goodExports.AddRange((
                            from e in exports
                            where (
                                !((e.Country.Warehouse == null) || (e.Country.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.Country.Warehouse.Code))) 
                                    || ((e.StateProvince.Warehouse == null) || (e.StateProvince.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.StateProvince.Warehouse.Code)) || (e.StateProvince.Country.Warehouse == null) || (e.StateProvince.Country.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.StateProvince.Country.Warehouse.Code)))
                                    || ((e.PostalCode.Warehouse == null) || (e.PostalCode.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.Warehouse.Code)) || (e.PostalCode.County.Warehouse == null) || (e.PostalCode.County.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.Warehouse.Code)))
                                    || ((e.PostalCode.County.StateProvince.Warehouse == null) || (e.PostalCode.County.StateProvince.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Warehouse.Code)) || (e.PostalCode.County.StateProvince.Warehouse == null) || (e.PostalCode.County.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.Warehouse.Code)))
                                    || ((e.PostalCode.County.Country.Warehouse == null) || (e.PostalCode.County.Country.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.Country.Warehouse.Code)) || (e.PostalCode.County.Country.Warehouse == null) || (e.PostalCode.County.Country.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.Country.Warehouse.Code)))
                                    || ((e.PostalCode.County.StateProvince.Warehouse == null) || (e.PostalCode.County.StateProvince.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Warehouse.Code)) || (e.PostalCode.County.StateProvince.Warehouse == null) || (e.PostalCode.County.StateProvince.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Warehouse.Code)))
                                    || ((e.PostalCode.County.StateProvince.Country.Warehouse == null) || (e.PostalCode.County.StateProvince.Country.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Country.Warehouse.Code)) || (e.PostalCode.County.StateProvince.Country.Warehouse == null) || (e.PostalCode.County.StateProvince.Country.Warehouse.WarehouseID == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Country.Warehouse.Code)))                                    
                                ) && !filteredExports.Contains(e)
                            select e
                        ).AsParallel());

                        await Parallel.ForEachAsync<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>(filteredExports, pOptions, async (export, cancellationToken) =>
                        {
                            IMultichannelOrderManagerWarehouse countryWarehouse = null;
                            IMultichannelOrderManagerWarehouse stateProvinceWarehouse = null;
                            IMultichannelOrderManagerWarehouse countyWarehouse = null;
                            IMultichannelOrderManagerWarehouse postalCodeWarehouse = null;
                            
                            countryWarehouse = (from w in warehouses where (w.ID == export.Country.Warehouse.ID) || String.Equals(w.Code?.Trim(), export.Country.Warehouse.Code?.Trim()) select w).FirstOrDefault(defaultWarehouse);
                            stateProvinceWarehouse = (from w in warehouses where (w.ID == export.StateProvince.Warehouse.ID) || String.Equals(w.Code?.Trim(), export.StateProvince.Warehouse.Code?.Trim()) select w).FirstOrDefault(defaultWarehouse);
                            countyWarehouse = (from w in warehouses where (w.ID == export.PostalCode.County.Warehouse.ID) || String.Equals(w.Code?.Trim(), export.PostalCode.County.Warehouse.Code?.Trim()) select w).FirstOrDefault(defaultWarehouse);
                            postalCodeWarehouse = (from w in warehouses where (w.ID == export.PostalCode.Warehouse.ID) || String.Equals(w.Code?.Trim(), export.PostalCode.Warehouse.Code?.Trim()) select w).FirstOrDefault(defaultWarehouse);

                            export.Country.Warehouse = countryWarehouse.ToMultichannelOrderManagerWarehouse();
                            export.StateProvince.Country.Warehouse = countryWarehouse.ToMultichannelOrderManagerWarehouse();
                            export.PostalCode.Country.Warehouse = countryWarehouse.ToMultichannelOrderManagerWarehouse();
                            export.PostalCode.County.Country.Warehouse = countryWarehouse.ToMultichannelOrderManagerWarehouse();
                            export.PostalCode.County.StateProvince.Country.Warehouse = countryWarehouse.ToMultichannelOrderManagerWarehouse();

                            export.StateProvince.Warehouse = stateProvinceWarehouse.ToMultichannelOrderManagerWarehouse();
                            export.PostalCode.StateProvince.Warehouse = stateProvinceWarehouse.ToMultichannelOrderManagerWarehouse();
                            export.PostalCode.County.StateProvince.Warehouse = stateProvinceWarehouse.ToMultichannelOrderManagerWarehouse();

                            export.PostalCode.County.Warehouse = countyWarehouse.ToMultichannelOrderManagerWarehouse();
                            
                            export.PostalCode.Warehouse = postalCodeWarehouse.ToMultichannelOrderManagerWarehouse();
                            
                            
                            await asyncTaxRates.AddAsync(export);
                        });

                        result = new WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>>(WhippetResult.Success, goodExports.Concat(taxRates));
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>>(e);
                }

                return result;
            }
        }
                
        /// <summary>
        /// Fixes up missing geographical data in the specified <see cref="IEnumerable{T}"/> collection of <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> objects.
        /// </summary>
        /// <param name="exports"><see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> objects to fix.</param>
        /// <param name="countries"><see cref="IMultichannelOrderManagerCountry"/> collection.</param>
        /// <param name="defaultCountry">Default <see cref="IMultichannelOrderManagerCountry"/> to assign if value could not be found.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>>> FixUpMissingCountries(IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry> exports, IEnumerable<IMultichannelOrderManagerCountry> countries, IMultichannelOrderManagerCountry defaultCountry)
        {
            if (exports == null)
            {
                throw new ArgumentNullException(nameof(exports));
            }
            else if (countries == null)
            {
                throw new ArgumentNullException(nameof(countries));
            }
            else if (defaultCountry == null)
            {
                throw new ArgumentNullException(nameof(defaultCountry));
            }
            else
            {
                int capacity = 0;

                ConcurrentBag<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry> taxRates = null;
                AsyncCollection<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry> asyncTaxRates = null;

                WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>> result = null;

                ParallelOptions pOptions = null;

                IList<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry> filteredExports = null;
                IList<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry> goodExports = null;

                try
                {
                    if (exports.Any())
                    {
                        if (!exports.TryGetNonEnumeratedCount(out capacity))
                        {
                            capacity = exports.Count();
                        }

                        taxRates = new ConcurrentBag<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>();
                        asyncTaxRates = new AsyncCollection<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>(taxRates, capacity);

                        filteredExports = new List<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>(capacity);
                        goodExports = new List<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>(capacity);

                        pOptions = new ParallelOptions();
                        pOptions = pOptions.DetermineOptimalCoreCount();

                        filteredExports.AddRange((
                            from e in exports
                            where (
                                (e.Country == null) || (e.Country.CountryId == 0) || (String.IsNullOrWhiteSpace(e.Country.CountryCode)) || String.IsNullOrWhiteSpace(e.Country.Name) || String.IsNullOrWhiteSpace(e.Country.ISO2) || String.IsNullOrWhiteSpace(e.Country.ISO3) || String.IsNullOrWhiteSpace(e.Country.ISONumber))
                                  || ((e.StateProvince.Country == null) || (e.StateProvince.Country.CountryId == 0) || (String.IsNullOrWhiteSpace(e.StateProvince.Country.CountryCode)) || String.IsNullOrWhiteSpace(e.StateProvince.Country.Name) || String.IsNullOrWhiteSpace(e.StateProvince.Country.ISO2) || String.IsNullOrWhiteSpace(e.StateProvince.Country.ISO3) || String.IsNullOrWhiteSpace(e.StateProvince.Country.ISONumber))
                                  || ((e.PostalCode.Country == null) || (e.PostalCode.Country.CountryId == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.Country.CountryCode)) || String.IsNullOrWhiteSpace(e.PostalCode.Country.Name) || String.IsNullOrWhiteSpace(e.PostalCode.Country.ISO2) || String.IsNullOrWhiteSpace(e.PostalCode.Country.ISO3) || String.IsNullOrWhiteSpace(e.PostalCode.Country.ISONumber))
                                  || ((e.PostalCode.County.Country == null) || (e.PostalCode.County.Country.CountryId == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.Country.CountryCode)) || String.IsNullOrWhiteSpace(e.PostalCode.County.Country.Name) || String.IsNullOrWhiteSpace(e.PostalCode.County.Country.ISO2) || String.IsNullOrWhiteSpace(e.PostalCode.County.Country.ISO3) || String.IsNullOrWhiteSpace(e.PostalCode.County.Country.ISONumber))
                                  || ((e.PostalCode.County.StateProvince.Country == null) || (e.PostalCode.County.StateProvince.Country.CountryId == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Country.CountryCode)) || String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Country.Name) || String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Country.ISO2) || String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Country.ISO3) || String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Country.ISONumber))
                            select e
                        ).AsParallel());

                        goodExports.AddRange((
                            from e in exports
                            where !(((e.Country == null) || (e.Country.CountryId == 0) || (String.IsNullOrWhiteSpace(e.Country.CountryCode)) || String.IsNullOrWhiteSpace(e.Country.Name) || String.IsNullOrWhiteSpace(e.Country.ISO2) || String.IsNullOrWhiteSpace(e.Country.ISO3) || String.IsNullOrWhiteSpace(e.Country.ISONumber))
                                    || ((e.StateProvince.Country == null) || (e.StateProvince.Country.CountryId == 0) || (String.IsNullOrWhiteSpace(e.StateProvince.Country.CountryCode)) || String.IsNullOrWhiteSpace(e.StateProvince.Country.Name) || String.IsNullOrWhiteSpace(e.StateProvince.Country.ISO2) || String.IsNullOrWhiteSpace(e.StateProvince.Country.ISO3) || String.IsNullOrWhiteSpace(e.StateProvince.Country.ISONumber))
                                    || ((e.PostalCode.Country == null) || (e.PostalCode.Country.CountryId == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.Country.CountryCode)) || String.IsNullOrWhiteSpace(e.PostalCode.Country.Name) || String.IsNullOrWhiteSpace(e.PostalCode.Country.ISO2) || String.IsNullOrWhiteSpace(e.PostalCode.Country.ISO3) || String.IsNullOrWhiteSpace(e.PostalCode.Country.ISONumber))
                                    || ((e.PostalCode.County.Country == null) || (e.PostalCode.County.Country.CountryId == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.Country.CountryCode)) || String.IsNullOrWhiteSpace(e.PostalCode.County.Country.Name) || String.IsNullOrWhiteSpace(e.PostalCode.County.Country.ISO2) || String.IsNullOrWhiteSpace(e.PostalCode.County.Country.ISO3) || String.IsNullOrWhiteSpace(e.PostalCode.County.Country.ISONumber))
                                    || ((e.PostalCode.County.StateProvince.Country == null) || (e.PostalCode.County.StateProvince.Country.CountryId == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Country.CountryCode)) || String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Country.Name) || String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Country.ISO2) || String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Country.ISO3) || String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Country.ISONumber))
                                ) && !filteredExports.Contains(e)
                            select e
                        ).AsParallel());

                        await Parallel.ForEachAsync<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>(filteredExports, pOptions, async (export, cancellationToken) =>
                        {
                            IMultichannelOrderManagerCountry country = null;

                            country = (
                                from c in countries
                                where (export.Country.CountryId == c.ID || String.Equals(export.Country.CountryCode?.Trim(), c.CountryCode?.Trim()))
                                      || (export.PostalCode.Country.CountryId == c.ID || String.Equals(export.PostalCode.Country.CountryCode?.Trim(), c.CountryCode?.Trim()))
                                      || (export.PostalCode.StateProvince.Country.CountryId == c.ID || String.Equals(export.PostalCode.StateProvince.Country.CountryCode?.Trim(), c.CountryCode?.Trim()))
                                      || (export.PostalCode.County.Country.CountryId == c.ID || String.Equals(export.PostalCode.County.Country.CountryCode?.Trim(), c.CountryCode?.Trim()))
                                      || (export.PostalCode.County.StateProvince.Country.CountryId == c.ID || String.Equals(export.PostalCode.County.StateProvince.Country.CountryCode?.Trim(), c.CountryCode?.Trim()))
                                      || (export.StateProvince.Country.CountryId == c.ID || String.Equals(export.StateProvince.Country.CountryCode?.Trim(), c.CountryCode?.Trim()))
                                select c).FirstOrDefault(defaultCountry);

                            export.PostalCode.Country = country.ToMultichannelOrderManagerCountry();
                            export.PostalCode.StateProvince.Country = country.ToMultichannelOrderManagerCountry();
                            export.PostalCode.County.Country = country.ToMultichannelOrderManagerCountry();
                            export.PostalCode.County.StateProvince.Country = country.ToMultichannelOrderManagerCountry();
                            export.StateProvince.Country = country.ToMultichannelOrderManagerCountry();
                            export.Country = country.ToMultichannelOrderManagerCountry();

                            await asyncTaxRates.AddAsync(export);
                        });

                        result = new WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>>(WhippetResult.Success, goodExports.Concat(taxRates));
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>>(e);
                }

                return result;
            }
        }
        
        /// <summary>
        /// Fixes up missing geographical data in the specified <see cref="IEnumerable{T}"/> collection of <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> objects.
        /// </summary>
        /// <param name="exports"><see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> objects to fix.</param>
        /// <param name="counties"><see cref="IMultichannelOrderManagerCounty"/> collection.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>>> FixUpMissingCounties(IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry> exports, IEnumerable<IMultichannelOrderManagerCounty> counties)
        {
            if (exports == null)
            {
                throw new ArgumentNullException(nameof(exports));
            }
            else if (counties == null)
            {
                throw new ArgumentNullException(nameof(counties));
            }
            else
            {
                int capacity = 0;

                ConcurrentBag<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry> taxRates = null;
                AsyncCollection<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry> asyncTaxRates = null;

                WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>> result = null;

                ParallelOptions pOptions = null;

                IList<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry> filteredExports = null;
                IList<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry> goodExports = null;

                try
                {
                    if (exports.Any())
                    {
                        if (!exports.TryGetNonEnumeratedCount(out capacity))
                        {
                            capacity = exports.Count();
                        }

                        taxRates = new ConcurrentBag<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>();
                        asyncTaxRates = new AsyncCollection<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>(taxRates, capacity);

                        filteredExports = new List<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>(capacity);
                        goodExports = new List<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>(capacity);

                        pOptions = new ParallelOptions();
                        pOptions = pOptions.DetermineOptimalCoreCount();

                        filteredExports.AddRange((
                            from e in exports
                            where (e.PostalCode.County == null) || (e.PostalCode.County.CountyId == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.CountyCode)) || String.IsNullOrWhiteSpace(e.PostalCode.County.Name)
                            select e
                        ).AsParallel());

                        goodExports.AddRange((
                            from e in exports
                            where !((e.PostalCode.County == null) || (e.PostalCode.County.CountyId == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.CountyCode)) || String.IsNullOrWhiteSpace(e.PostalCode.County.Name)) 
                                  && !filteredExports.Contains(e)
                            select e
                        ).AsParallel());

                        await Parallel.ForEachAsync<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>(filteredExports, pOptions, async (export, cancellationToken) =>
                        {
                            IMultichannelOrderManagerCounty county = null;

                            county = (
                                from c in counties
                                where (export.PostalCode.County.CountyId == c.CountyId || String.Equals(export.PostalCode.County.CountyCode?.Trim(), c.CountyCode?.Trim()))
                                select c).FirstOrDefault();

                            if (county != null)
                            {
                                export.PostalCode.County = county.ToMultichannelOrderManagerCounty();
                            }

                            await asyncTaxRates.AddAsync(export);
                        });

                        result = new WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>>(WhippetResult.Success, goodExports.Concat(taxRates));
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>>(e);
                }

                return result;
            }
        }
        
        /// <summary>
        /// Fixes up missing geographical data in the specified <see cref="IEnumerable{T}"/> collection of <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> objects.
        /// </summary>
        /// <param name="exports"><see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> objects to fix.</param>
        /// <param name="states"><see cref="IMultichannelOrderManagerStateProvince"/> collection.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>>> FixUpMissingStates(IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry> exports, IEnumerable<IMultichannelOrderManagerStateProvince> states)
        {
            if (exports == null)
            {
                throw new ArgumentNullException(nameof(exports));
            }
            else if (states == null)
            {
                throw new ArgumentNullException(nameof(states));
            }
            else
            {
                int capacity = 0;

                ConcurrentBag<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry> taxRates = null;
                AsyncCollection<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry> asyncTaxRates = null;

                WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>> result = null;

                ParallelOptions pOptions = null;

                IList<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry> filteredExports = null;
                IList<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry> goodExports = null;

                try
                {
                    if (exports.Any())
                    {
                        if (!exports.TryGetNonEnumeratedCount(out capacity))
                        {
                            capacity = exports.Count();
                        }

                        taxRates = new ConcurrentBag<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>();
                        asyncTaxRates = new AsyncCollection<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>(taxRates, capacity);

                        filteredExports = new List<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>(capacity);
                        goodExports = new List<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>(capacity);

                        pOptions = new ParallelOptions();
                        pOptions = pOptions.DetermineOptimalCoreCount();

                        filteredExports.AddRange((
                            from e in exports
                            where (
                                (e.StateProvince == null) || (e.StateProvince.ID == 0) || (String.IsNullOrWhiteSpace(e.StateProvince.Name)) || String.IsNullOrWhiteSpace(e.StateProvince.Abbreviation) 
                                    || (e.PostalCode.StateProvince == null) || (e.PostalCode.StateProvince.ID == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.StateProvince.Name)) || String.IsNullOrWhiteSpace(e.PostalCode.StateProvince.Abbreviation)
                                    || (e.PostalCode.County.StateProvince == null) || (e.PostalCode.County.StateProvince.ID == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Name)) || String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Abbreviation)
                            ) 
                            select e
                        ).AsParallel());

                        goodExports.AddRange((
                            from e in exports
                            where !(
                                (e.StateProvince == null) || (e.StateProvince.ID == 0) || (String.IsNullOrWhiteSpace(e.StateProvince.Name)) || String.IsNullOrWhiteSpace(e.StateProvince.Abbreviation) 
                                || (e.PostalCode.StateProvince == null) || (e.PostalCode.StateProvince.ID == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.StateProvince.Name)) || String.IsNullOrWhiteSpace(e.PostalCode.StateProvince.Abbreviation)
                                || (e.PostalCode.County.StateProvince == null) || (e.PostalCode.County.StateProvince.ID == 0) || (String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Name)) || String.IsNullOrWhiteSpace(e.PostalCode.County.StateProvince.Abbreviation)
                                && !filteredExports.Contains(e) 
                            ) 
                            select e
                        ).AsParallel());                        
                        
                        if (filteredExports.Count > 0)
                        {
                            await Parallel.ForEachAsync<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>(filteredExports, pOptions, async (export, cancellationToken) =>
                            {
                                IMultichannelOrderManagerStateProvince state = null;

                                state = (from s in states where ((s.ID == export.StateProvince.ID) || (s.ID == export.PostalCode.StateProvince.ID) || (export.PostalCode.County.StateProvince.ID == s.ID)) select s).FirstOrDefault();
                                
                                if (state != null)
                                {
                                    export.StateProvince = state.ToMultichannelOrderManagerStateProvince();
                                    export.PostalCode.StateProvince = state.ToMultichannelOrderManagerStateProvince();
                                    export.PostalCode.County.StateProvince = state.ToMultichannelOrderManagerStateProvince();
                                }

                                await asyncTaxRates.AddAsync(export);
                            });
                        }              
                        
                        result = new WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>>(WhippetResult.Success, goodExports.Concat(taxRates));
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>>(e);
                }

                return result;
            }
        }
        
        /// <summary>
        /// Fixes up missing geographical data in the specified <see cref="IEnumerable{T}"/> collection of <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> objects.
        /// </summary>
        /// <param name="exports"><see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> objects to fix.</param>
        /// <param name="postalCodes"><see cref="IMultichannelOrderManagerPostalCode"/> collection.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>>> FixUpMissingPostalCodes(IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry> exports, IEnumerable<IMultichannelOrderManagerPostalCode> postalCodes)
        {
            if (exports == null)
            {
                throw new ArgumentNullException(nameof(exports));
            }
            else if (postalCodes == null)
            {
                throw new ArgumentNullException(nameof(postalCodes));
            }
            else
            {
                int capacity = 0;

                ConcurrentBag<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry> taxRates = null;
                AsyncCollection<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry> asyncTaxRates = null;

                WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>> result = null;

                ParallelOptions pOptions = null;

                IList<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry> filteredExports = null;
                IList<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry> goodExports = null;

                try
                {
                    if (exports.Any())
                    {
                        if (!exports.TryGetNonEnumeratedCount(out capacity))
                        {
                            capacity = exports.Count();
                        }

                        taxRates = new ConcurrentBag<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>();
                        asyncTaxRates = new AsyncCollection<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>(taxRates, capacity);

                        filteredExports = new List<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>(capacity);
                        goodExports = new List<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>(capacity);

                        pOptions = new ParallelOptions();
                        pOptions = pOptions.DetermineOptimalCoreCount();

                        filteredExports.AddRange((
                            from e in exports
                            where (e.PostalCode.ID == 0) || String.IsNullOrWhiteSpace(e.PostalCode.PostalCode)
                            select e
                        ).AsParallel());

                        goodExports.AddRange((
                            from e in exports
                            where !((e.PostalCode.ID == 0) || String.IsNullOrWhiteSpace(e.PostalCode.PostalCode))
                                && !filteredExports.Contains(e) 
                            select e
                        ).AsParallel());                        
                        
                        if (filteredExports.Count > 0)
                        {
                            await Parallel.ForEachAsync<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>(filteredExports, pOptions, async (export, cancellationToken) =>
                            {
                                IMultichannelOrderManagerPostalCode postalCode = null;

                                postalCode = (from p in postalCodes where (p.ID == export.StateProvince.ID) || String.Equals(p.PostalCode?.Trim(), export.PostalCode.PostalCode?.Trim(), StringComparison.InvariantCultureIgnoreCase) select p).FirstOrDefault();
                                
                                if (postalCode != null)
                                {
                                    export.PostalCode = postalCode.ToMultichannelOrderManagerPostalCode();
                                }

                                await asyncTaxRates.AddAsync(export);
                            });
                        }              
                        
                        result = new WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>>(WhippetResult.Success, goodExports.Concat(taxRates));
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry>>(e);
                }

                return result;
            }
        }
        
        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (EntryRepository != null)
            {
                EntryRepository.Dispose();
                EntryRepository = null;
            }

            base.Dispose();
        }
    }
}
