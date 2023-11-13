using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Athi.Whippet.ServiceManagers;
using Athi.Whippet.ServiceManagers.NoSQL.Apache.CouchDB;
using Athi.Whippet.Services;
using Athi.Whippet.Data.CQRS;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Queries;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Commands;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Handlers.Commands;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers.Handlers.Queries;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.Repositories;
using Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.Extensions;
using CouchDB.Driver.Options;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.ServiceManagers
{
    /// <summary>
    /// Service manager for <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> domain objects.
    /// </summary>
    public class MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryServiceManager : CouchDBServiceManager, IServiceManager
    {
        /// <summary>
        /// Gets the <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryRepository"/> that queries are executed against. This property is read-only.
        /// </summary>
        protected virtual IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryRepository CouchDBEntryRepository
        { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryServiceManager"/> class with the specified <see cref="<see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryRepository"/> object.
        /// </summary>
        /// <param name="entryRepository"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryRepository"/> object.</param>
        /// <param name="options"><see cref="CouchOptions"/> used to configure the context.</param>
        /// <param name="chunkSize">Total number of records to consume per transaction when dealing with large amounts of data. If zero or less than zero, the default value will be used.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryServiceManager(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryRepository entryRepository, CouchOptions options, int chunkSize = 0)
            : base(options)
        {
            if (entryRepository == null)
            {
                throw new ArgumentNullException(nameof(entryRepository));
            }
            else
            {
                CouchDBEntryRepository = entryRepository;
                CouchDBEntryRepository.ChunkSize = chunkSize;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryServiceManager"/> class with the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryRepository"/> object.
        /// </summary>
        /// <param name="serviceLocator"><see cref="IWhippetServiceContext"/> object that serves as a service locator.</param>
        /// <param name="entryRepository"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryRepository"/> object to initialize with.</param>
        /// <param name="options"><see cref="CouchOptions"/> used to configure the context.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryServiceManager(IWhippetServiceContext serviceLocator, IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryRepository entryRepository, CouchOptions options)
            : base(serviceLocator, options)
        {
            if (entryRepository == null)
            {
                throw new ArgumentNullException(nameof(entryRepository));
            }
            else
            {
                CouchDBEntryRepository = entryRepository;
            }
        }

        /// <summary>
        /// Gets the <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> based on the specified ID.
        /// </summary>
        /// <param name="id">ID of the <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>> GetCouchDBEntry(Guid id)
        {
            GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryByIdQueryHandler handler = new GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryByIdQueryHandler(CouchDBEntryRepository);
            WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>> result = await handler.HandleAsync(new GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryByIdQuery(id));
            return new WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>(result.Result, result.Item.FirstOrDefault());
        }

        /// <summary>
        /// Gets all <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> objects for the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>>> GetEntries(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            else
            {
                GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntriesForCacheQueryHandler handler = new GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntriesForCacheQueryHandler(CouchDBEntryRepository);
                WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>> result = await handler.HandleAsync(new GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntriesForCacheQuery(cache));
                return new WhippetResultContainer<IEnumerable<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// Gets all <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> objects for the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object to filter by.</param>
        /// <param name="startingRecordNumber">Starting record number in the range of documents to retrieve.</param>
        /// <param name="count">Number of items to retrieve from <paramref name="startingRecordNumber"/>.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>>> GetEntries(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache, int startingRecordNumber, int count)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            else
            {
                GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntriesForCacheQueryHandler handler = new GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntriesForCacheQueryHandler(CouchDBEntryRepository);
                WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>> result = await handler.HandleAsync(new GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntriesForCacheQuery(cache, startingRecordNumber, count));
                return new WhippetResultContainer<IEnumerable<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>>(result.Result, result.Item);
            }
        }
        
        /// <summary>
        /// Gets the first instance of an <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> with the specified record number.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object to filter by.</param>
        /// <param name="recordNumber">Row number of the <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheEntry"/> to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the return value of the query, if any.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>> GetEntryByRecordNumber(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache, int recordNumber)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            else
            {
                GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryByRecordNumberQueryHandler handler = new GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryByRecordNumberQueryHandler(CouchDBEntryRepository);
                WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>> result = await handler.HandleAsync(new GetMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryByRecordNumberQuery(cache, recordNumber));
                return new WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>(result.Result, result.HasItem ? result.Item.FirstOrDefault() : null);
            }
        }

        /// <summary>
        /// Creates a new Magento tax rate entry entry.
        /// </summary>
        /// <param name="entry"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry> CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry entry)
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }
            else
            {
                return Task<WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>>.Run(() => CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryAsync(entry)).Result;
            }
        }

        /// <summary>
        /// Creates a new Magento tax rate entry entry.
        /// </summary>
        /// <param name="entry"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> object to register in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> object.</returns>
        public virtual async Task<WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>> CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryAsync(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry entry)
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommand> handler = new CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommandHandler(CouchDBEntryRepository);

                try
                {
                    result = await handler.HandleAsync(new CreateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommand(entry.ToMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry()));
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>(result, result.ResultObject as IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry);
            }
        }

        /// <summary>
        /// Updates an existing Magento tax rate entry entry.
        /// </summary>
        /// <param name="entry"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry> UpdateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry entry)
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }
            else
            {
                return Task<WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>>.Run(() => UpdateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryAsync(entry)).Result;
            }
        }

        /// <summary>
        /// Updates an existing Magento tax rate entry entry.
        /// </summary>
        /// <param name="entry"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> object to update in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the new <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>> UpdateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryAsync(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry entry)
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<UpdateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommand> handler = new UpdateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommandHandler(CouchDBEntryRepository);

                try
                {
                    result = await handler.HandleAsync(new UpdateMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommand(entry.ToMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry()));
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>(result, entry);
            }
        }

        /// <summary>
        /// Deletes an existing Magento tax rate entry entry.
        /// </summary>
        /// <param name="entry"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry> DeleteMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry entry)
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }
            else
            {
                return Task.Run(() => DeleteMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryAsync(entry)).Result;
            }
        }

        /// <summary>
        /// Deletes an existing Magento tax rate entry entry.
        /// </summary>
        /// <param name="entry"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> object to delete in the data store.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>> DeleteMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryAsync(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry entry)
        {
            if (entry == null)
            {
                throw new ArgumentNullException(nameof(entry));
            }
            else
            {
                WhippetResult result = WhippetResult.Success;

                IWhippetCommandHandler<DeleteMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommand> handler = new DeleteMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommandHandler(CouchDBEntryRepository);

                try
                {
                    result = await handler.HandleAsync(new DeleteMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryCommand(entry.ToMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry()));
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>(result, entry);
            }
        }

        /// <summary>
        /// Deletes all entries for the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object to delete all entries for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<int> DeleteAllMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntries(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            else
            {
                return Task.Run(() => DeleteAllMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntriesAsync(cache)).Result;
            }
        }

        /// <summary>
        /// Deletes all entries for the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object to delete all entries for.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<int>> DeleteAllMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntriesAsync(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            else
            {
                WhippetResult result = null;
                IWhippetCommandHandler<DeleteAllMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntriesCommand> handler = new DeleteAllMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntriesCommandHandler(CouchDBEntryRepository);

                try
                {
                    result = await handler.HandleAsync(new DeleteAllMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntriesCommand(cache));
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>(new WhippetResult(e), null);
                }

                return new WhippetResultContainer<int>(result, (result.ResultObject != null ? Convert.ToInt32(result.ResultObject) : default(int)));
            }
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public override void Dispose()
        {
            if (CouchDBEntryRepository != null)
            {
                CouchDBEntryRepository.Dispose();
                CouchDBEntryRepository = null;
            }

            base.Dispose();
        }
    }
}
