using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Net.Http.Headers;
using System.Reflection;
using Nito.AsyncEx;
using CouchDB.Driver;
using Newtonsoft.Json;
using Athi.Whippet.Data.Database.NoSQL.Apache.CouchDB;
using Athi.Whippet.Data.Database.NoSQL.Apache.CouchDB.Models;
using Athi.Whippet.Json.Newtonsoft;
using Athi.Whippet.Threading.Tasks.Extensions;

namespace Athi.Whippet.Oswald.Integrations.Adobe.Magento.Taxes.Cache.Repositories
{
    /// <summary>
    /// Represents an Apache CouchDB repository for <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> objects.
    /// </summary>
    public class MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryRepository : WhippetCouchDBRepository<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>, IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryRepository"/> class with the specified <see cref="ICouchDatabase{TSource}"/> that provides a database context.
        /// </summary>
        /// <param name="databaseContext"><see cref="ICouchDatabase{TSource}"/> object that provides a database context.</param>
        /// <param name="hostname"><see cref="Uri"/> that contains the hostname and port of where the database is located.</param>
        /// <param name="authenticationValue"><see cref="AuthenticationHeaderValue"/> object containing the authentication information for processing raw HTTP requests with the CouchDB server.</param>
        /// <exception cref="ArgumentNullException" />
        public MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntryRepository(ICouchDatabase<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry> databaseContext, Uri hostname = null, AuthenticationHeaderValue authenticationValue = null)
            : base(databaseContext, hostname, authenticationValue)
        { }

        /// <summary>
        /// Returns all <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> objects for the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>> GetEntriesForCache(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache)
        {
            ArgumentNullException.ThrowIfNull(cache);
            return Task.Run(() => GetEntriesForCacheAsync(cache)).Result;
        }

        /// <summary>
        /// Returns the first <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> object for the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> that has the specified record number.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object.</param>
        /// <param name="recordNumber">Record number to filter by.</param>
        /// <param name="count">Number of records to return.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>> GetEntriesForCache(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache, int recordNumber, int count)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            else
            {
                return Task.Run(() => GetEntriesForCacheAsync(cache, recordNumber, count, default(CancellationToken))).Result;
            }
        }
        
        /// <summary>
        /// Returns all <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> objects for the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>>> GetEntriesForCacheAsync(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache, CancellationToken? cancellationToken = null)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            else
            {
                WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>> result = null;
                WhippetResultContainer<WhippetCouchAllDocsResponseModel> allDocumentsResult = null;

                ConcurrentBag<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry> entries = null;
                AsyncCollection<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry> asyncEntries = null;

                List<string> documentIds = null;
                List<string> currentDocumentIdChunk = null;
                List<IEnumerable<string>> documentIdChunks = null;
                
                ParallelOptions pOptions = null;

                try
                {
                    allDocumentsResult = await base.GetAll();
                    allDocumentsResult.ThrowIfFailed();

                    if (allDocumentsResult.HasItem && allDocumentsResult.Item.TotalEntries > 0)
                    {
                        documentIds = new List<string>(allDocumentsResult.Item.TotalEntries);
                        //entries = new List<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>(allDocumentsResult.Item.TotalEntries);
                        
                        documentIds.AddRange(allDocumentsResult.Item.Entries.Select(doc => doc.ID).AsParallel());

                        // now divide it up into chunks

                        documentIdChunks = new List<IEnumerable<string>>(documentIds.Count);
                        currentDocumentIdChunk = new List<string>(ChunkSize);

                        for (int i = 0, chunkIndex = 1; i < documentIds.Count; i++, chunkIndex++)
                        {
                            if (chunkIndex >= ChunkSize || (i == (documentIds.Count - 1)))
                            {
                                currentDocumentIdChunk.Add(documentIds[i]);

                                if (i == (documentIds.Count - 1))
                                {
                                    documentIdChunks.Add(currentDocumentIdChunk);   // last element, add the list
                                }
                                else
                                {
                                    documentIdChunks.Add(currentDocumentIdChunk);
                                    currentDocumentIdChunk = new List<string>(ChunkSize);
                                    chunkIndex = 1;
                                }
                            }
                            else
                            {
                                currentDocumentIdChunk.Add(documentIds[i]);    
                            }
                        }
                        
                        entries = new ConcurrentBag<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>();
                        asyncEntries = new AsyncCollection<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>(entries, allDocumentsResult.Item.TotalEntries);

                        pOptions = pOptions.DetermineOptimalCoreCount();

                        await Parallel.ForEachAsync(documentIdChunks, pOptions, async (chunk, cancellationToken) =>
                        {
                            IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry> loadedEntries = await FindManyAsync(new List<string>(chunk), cancellationToken);

                            cancellationToken.ThrowIfCancellationRequested();

                            if (loadedEntries != null && loadedEntries.Any())
                            {
                                foreach (MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry entry in loadedEntries)
                                {
                                    await asyncEntries.AddAsync(entry, cancellationToken);
                                    cancellationToken.ThrowIfCancellationRequested();
                                }
                            }
                        });
                    }

                    result = new WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>>(WhippetResult.Success, entries == null
                        ? Enumerable.Empty<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>()
                        : entries
                    );
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>>(e);
                }

                return result;
            }
        }

        /// <summary>
        /// Returns the first <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> object for the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> that has the specified record number.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object.</param>
        /// <param name="recordNumber">Record number to filter by.</param>
        /// <param name="count">Number of records to return.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>>> GetEntriesForCacheAsync(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache, int recordNumber, int count, CancellationToken? cancellationToken = null)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            else
            {
                IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry> filteredResults = null;
                WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>> result = null;
                
                result = await GetEntriesForCacheAsync(cache, cancellationToken);

                if (result.IsSuccess && result.HasItem)
                {
                    filteredResults = (from r in result.Item where (r.RowNumber >= recordNumber && r.RowNumber <= (recordNumber + count)) select r).AsParallel();
                    result = new WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>>(result.Result, filteredResults);
                }
                
                return result;
            }
        }
        
        /// <summary>
        /// Returns the first <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> object for the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> that has the specified record number.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object.</param>
        /// <param name="recordNumber">Record number to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry> GetEntryByRecordNumber(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache, int recordNumber)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            else
            {
                return Task.Run(() => GetEntryByRecordNumberAsync(cache, recordNumber)).Result;
            }
        }
        
        /// <summary>
        /// Returns the first <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> object for the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> that has the specified record number.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object.</param>
        /// <param name="recordNumber">Record number to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>> GetEntryByRecordNumberAsync(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache, int recordNumber, CancellationToken? cancellationToken = null)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            else
            {
                const int BATCH_SIZE = 250;

                int currentBatchIndex = 0;

                WhippetResultContainer<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry> result = null;
                WhippetResultContainer<WhippetCouchAllDocsResponseModel> allDocumentsResult = null;

                MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry entry = null;
                List<string> documentIds = null;

                IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry> loadedEntries = null;

                try
                {
                    allDocumentsResult = await base.GetAll();
                    allDocumentsResult.ThrowIfFailed();

                    if (allDocumentsResult.HasItem && allDocumentsResult.Item.TotalEntries > 0)
                    {
                        documentIds = new List<string>(allDocumentsResult.Item.TotalEntries);
                        documentIds.AddRange(allDocumentsResult.Item.Entries.Select(doc => doc.ID).AsParallel());
                
                        for (currentBatchIndex = 0; currentBatchIndex < (allDocumentsResult.Item.TotalEntries + BATCH_SIZE); currentBatchIndex += BATCH_SIZE)
                        {
                            loadedEntries = await FindManyAsync(documentIds.Skip(currentBatchIndex).Take(BATCH_SIZE).ToList(), default(CancellationToken));

                            if (loadedEntries != null && loadedEntries.Any())
                            {
                                entry = loadedEntries.Where(le => le.CacheID == cache.ID && le.RowNumber == recordNumber).FirstOrDefault();

                                if (entry != null)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    result = new WhippetResultContainer<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>(WhippetResult.Success, entry);
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>(e);
                }

                return result;
            }
        }

        /// <summary>
        /// Deletes all <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> objects for the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<int> DeleteAllEntries(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            else
            {
                return Task.Run(() => DeleteAllEntriesAsync(cache)).Result;
            }
        }

        /// <summary>
        /// Deletes all <see cref="MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry"/> objects for the specified <see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/>.
        /// </summary>
        /// <param name="cache"><see cref="IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache"/> object.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<int>> DeleteAllEntriesAsync(IMagentoTaxSynchronizationMultichannelOrderManagerTaxRateCache cache, CancellationToken? cancellationToken = null)
        {
            if (cache == null)
            {
                throw new ArgumentNullException(nameof(cache));
            }
            else
            {
                WhippetResultContainer<int> result = null;
                WhippetResultContainer<IEnumerable<MagentoTaxSynchronizationMultichannelOrderManagerTaxRateCacheCouchDBEntry>> entries = null;

                int count = 0;

                try
                {
                    entries = await GetEntriesForCacheAsync(cache, cancellationToken);

                    if (entries.HasItem && entries.Item.Any())
                    {
                        if (!entries.Item.TryGetNonEnumeratedCount(out count))
                        {
                            count = entries.Item.Count();
                        }

                        await DeleteRangeAsync(entries.Item, cancellationToken.GetValueOrDefault());

                        result = new WhippetResultContainer<int>(WhippetResult.Success, count);
                    }
                    else
                    {
                        result = new WhippetResultContainer<int>(WhippetResult.Success, default(int));
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<int>(e);
                }

                return result;
            }
        }
    }
}
