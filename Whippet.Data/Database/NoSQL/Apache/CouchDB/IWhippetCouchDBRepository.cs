using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using CouchDB.Driver;
using CouchDB.Driver.ChangesFeed;
using CouchDB.Driver.ChangesFeed.Responses;
using CouchDB.Driver.DatabaseApiMethodOptions;
using CouchDB.Driver.Indexes;
using CouchDB.Driver.Local;
using CouchDB.Driver.Security;
using CouchDB.Driver.Types;
using CouchDB.Driver.Views;
using Flurl.Http;

namespace Athi.Whippet.Data.Database.NoSQL.Apache.CouchDB
{
    /// <summary>
    /// Represents a repository in Whippet that is stored in an Apache CouchDB data store.
    /// </summary>
    /// <typeparam name="TEntity"><see cref="IWhippetEntity"/> type that is stored in the CouchDB instance.</typeparam>
    public interface IWhippetCouchDBRepository<TEntity> : ICouchDatabase<TEntity>, IOrderedQueryable<TEntity>, IEnumerable<TEntity>, IEnumerable, IOrderedQueryable, IQueryable, IQueryable<TEntity>, IWhippetEntityRepository<TEntity, WhippetNonNullableString>, IWhippetRepository<TEntity, WhippetNonNullableString>, IWhippetDetachedRepository<TEntity>, IDisposable
        where TEntity : WhippetCouchDBEntity, IWhippetEntity, new()
    {
        /// <summary>
        /// Specifies the maximum request size for a large data set.
        /// </summary>
        int ChunkSize
        { get; set; }
        
        /// <summary>
        /// Gets the name of the current entity as its stored in the data store. This property is read-only.
        /// </summary>
        new string Database
        { get; }

        /// <summary>
        /// Gets the hostname and port of where the database is located. This property is read-only.
        /// </summary>
        public Uri Hostname
        { get; }
        
        /// <summary>
        /// Security information pertaining to the current database connection. This property is read-only.
        /// </summary>
        new ICouchSecurity Security
        { get; }

        /// <summary>
        /// Represents a list of documents that are not output by views and can be used to hold configuration (or other information) that is required specifically on the local CouchDB instance. This property is read-only.
        /// </summary>
        /// <remarks>See <a href="https://docs.couchdb.org/en/stable/api/local.html">1.7. Local (non-replicating) Documents</a>.</remarks>
        new ILocalDocuments LocalDocuments
        { get; }

        /// <summary>
        /// Gets the underlying type of the document stored in the data store. This property is read-only.
        /// </summary>
        new Type ElementType
        { get; }

        /// <summary>
        /// Gets the expression tree that is associated with the instance of <see cref="IQueryable"/>. This property is read-only.
        /// </summary>
        new Expression Expression
        { get; }

        /// <summary>
        /// Gets the query provider that is associated with this data source. This property is read-only.
        /// </summary>
        new IQueryProvider Provider
        { get; }

        /// <summary>
        /// Adds the specified entity of type <typeparamref name="T"/> to the data store.
        /// </summary>
        /// <param name="document">Entity of type <typeparamref name="T"/> to add to the data store.</param>
        /// <param name="batch">If <see langword="true"/>, will add the document as part of a transaction and not commit the immediate operation.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><typeparamref name="T"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidOperationException" />
        new Task<TEntity> AddAsync(TEntity document, bool batch = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds the specified entity of type <typeparamref name="T"/> to the data store.
        /// </summary>
        /// <param name="document">Entity of type <typeparamref name="T"/> to add to the data store.</param>
        /// <param name="options">Options used to determine how the entity will be added to the data store.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><typeparamref name="T"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidOperationException" />
        new Task<TEntity> AddAsync(TEntity document, AddOptions options, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds (or updates) the specified entity of type <typeparamref name="T"/> to the data store.
        /// </summary>
        /// <param name="document">Entity of type <typeparamref name="T"/> to add to the data store.</param>
        /// <param name="batch">If <see langword="true"/>, will add the document as part of a transaction and not commit the immediate operation.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><typeparamref name="T"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidOperationException" />
        new Task<TEntity> AddOrUpdateAsync(TEntity document, bool batch = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds (or updates) the specified entity of type <typeparamref name="T"/> to the data store.
        /// </summary>
        /// <param name="document">Entity of type <typeparamref name="T"/> to add to the data store.</param>
        /// <param name="options">Options used to determine how the entity will be added to the data store.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><typeparamref name="T"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidOperationException" />
        new Task<TEntity> AddOrUpdateAsync(TEntity document, AddOrUpdateOptions options, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds (or updates) the specified entities of type <typeparamref name="T"/> to the data store.
        /// </summary>
        /// <param name="documents">Entities of type <typeparamref name="T"/> to add to the data store.</param>
        /// <param name="cancellationToken"></param>
        /// <returns><typeparamref name="T"/> object collection.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidOperationException" />
        Task<IEnumerable<TEntity>> AddOrUpdateRangeAsync(IEnumerable<TEntity> documents, CancellationToken cancellationToken = default);

        /// <summary>
        /// Compacts the database, reducing its overall size.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        new Task CompactAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates an index for the documents in the data store.
        /// </summary>
        /// <param name="name">Name to assign the index.</param>
        /// <param name="indexBuilderAction"><see cref="Action{T1}"/> used to build the index.</param>
        /// <param name="options">Options to apply to the index.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="string"/> containing the index ID.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidOperationException" />
        new Task<string> CreateIndexAsync(string name, Action<IIndexBuilder<TEntity>> indexBuilderAction, IndexOptions options = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes the specified index from the data store.
        /// </summary>
        /// <param name="designDocument">Design JSON document.</param>
        /// <param name="name">Name of the index to delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidOperationException" />
        new Task DeleteIndexAsync(string designDocument, string name, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes the specified index from the data store.
        /// </summary>
        /// <param name="indexInfo">Index information.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidOperationException" />
        new Task DeleteIndexAsync(IndexInfo indexInfo, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes the specified entities of type <typeparamref name="T"/> from the data store.
        /// </summary>
        /// <param name="documents"><see cref="IEnumerable{T}"/> collection of <typeparamref name="T"/> elements.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        new Task DeleteRangeAsync(IEnumerable<TEntity> documents, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes the specified entities of type <typeparamref name="T"/> from the data store.
        /// </summary>
        /// <param name="documentIds"><see cref="IEnumerable{T}"/> collection of <see cref="DocumentId"/> objects.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        /// <exception cref="NotImplementedException"></exception>
        new Task DeleteRangeAsync(IEnumerable<DocumentId> documentIds, CancellationToken cancellationToken = default);

        /// <summary>
        /// Downloads the specified <see cref="CouchAttachment"/> and wraps it in a <see cref="Stream"/> object.
        /// </summary>
        /// <param name="attachment"><see cref="CouchAttachment"/> object to download.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Stream"/> object containing the attachment.</returns>
        /// <exception cref="ArgumentNullException" />
        new Task<Stream> DownloadAttachmentAsStreamAsync(CouchAttachment attachment, CancellationToken cancellationToken = default);

        /// <summary>
        /// Downloads the specified attachment to the local storage device.
        /// </summary>
        /// <param name="attachment"><see cref="CouchAttachment"/> object to download.</param>
        /// <param name="localFolderPath">Local folder path to download the file to.</param>
        /// <param name="localFileName">Local file name to name the downloaded file.</param>
        /// <param name="bufferSize">Buffer size to allow chunking of large data sets.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="string"/> representing the full path to the downloaded file.</returns>
        new Task<string> DownloadAttachmentAsync(CouchAttachment attachment, string localFolderPath, string localFileName = null, int bufferSize = 4096, CancellationToken cancellationToken = default);

        /// <summary>
        /// Commits the transaction to the data store.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        new Task EnsureFullCommitAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Finds the document with the specified document ID.
        /// </summary>
        /// <param name="docId">Document ID.</param>
        /// <param name="withConflicts">Specifies whether documents with conflicts should be considered in the search.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Entity of type <typeparamref name="T"/> (if found).</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidOperationException" />
        new Task<TEntity> FindAsync(string docId, bool withConflicts = false, CancellationToken cancellationToken = default);

        /// <summary>
        /// Finds the document with the specified document ID.
        /// </summary>
        /// <param name="docId">Document ID.</param>
        /// <param name="options">Options to apply to the search.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Entity of type <typeparamref name="T"/> (if found).</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidOperationException" />
        new Task<TEntity> FindAsync(string docId, FindOptions options, CancellationToken cancellationToken = default);

        /// <summary>
        /// Locates all documents of type <typeparamref name="T"/> that match one or more of the contained document IDs.
        /// </summary>
        /// <param name="docIds">Collection of document IDs used in the query.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <typeparamref name="T"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        new Task<IEnumerable<TEntity>> FindManyAsync(IReadOnlyCollection<string> docIds, CancellationToken cancellationToken);

        /// <summary>
        /// Gets all changes that have taken place in the document store for type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="options">Options to apply to the changes feed.</param>
        /// <param name="filter">Filter to apply to the changes feed.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ChangesFeedResponse{TSource}"/> object.</returns>
        new Task<ChangesFeedResponse<TEntity>> GetChangesAsync(ChangesFeedOptions options = null, ChangesFeedFilter filter = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns an <see cref="IAsyncEnumerable{T}"/> of continuous changes in the data store.
        /// </summary>
        /// <param name="options">Options to apply to the changes feed.</param>
        /// <param name="filter">Filter to apply to the changes feed.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="IAsyncEnumerable{T}"/> object.</returns>
        new IAsyncEnumerable<ChangesFeedResponseResult<TEntity>> GetContinuousChangesAsync(ChangesFeedOptions options, ChangesFeedFilter filter, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the specified view from the data store.
        /// </summary>
        /// <typeparam name="TKey">Type of key for the document.</typeparam>
        /// <typeparam name="TValue">Type of value for the document.</typeparam>
        /// <param name="design">Design document.</param>
        /// <param name="view">Name of the view to retrieve.</param>
        /// <param name="options">View options to apply to the view.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="CouchViewList{TKey, TValue, TDoc}"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidOperationException" />
        new Task<CouchViewList<TKey, TValue, TEntity>> GetDetailedViewAsync<TKey, TValue>(string design, string view, CouchViewOptions<TKey> options = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the specified views from the data store based on the specified query.
        /// </summary>
        /// <typeparam name="TKey">Type of key for the document.</typeparam>
        /// <typeparam name="TValue">Type of value for the document.</typeparam>
        /// <param name="design">Design document.</param>
        /// <param name="view">Name of the view to retrieve.</param>
        /// <param name="queries">Queries used to construct the views.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="CouchViewList{TKey, TValue, TDoc}"/> array.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidOperationException" />
        new Task<CouchViewList<TKey, TValue, TEntity>[]> GetDetailedViewQueryAsync<TKey, TValue>(string design, string view, IList<CouchViewOptions<TKey>> queries, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all indexes in the database.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="IndexInfo"/> objects.</returns>
        new Task<IEnumerable<IndexInfo>> GetIndexesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves information about the current data store.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns></returns>
        new Task<CouchDatabaseInfo> GetInfoAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all views that match the specified name.
        /// </summary>
        /// <typeparam name="TKey">Entry key.</typeparam>
        /// <typeparam name="TValue">Entry value.</typeparam>
        /// <param name="design">Design document.</param>
        /// <param name="view">Name of the view to search for.</param>
        /// <param name="options">Options to apply to the view.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="CouchView{TKey, TValue, TDoc}"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidOperationException" />
        new Task<IEnumerable<CouchView<TKey, TValue, TEntity>>> GetViewAsync<TKey, TValue>(string design, string view, CouchViewOptions<TKey> options, CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves all views that match the specified name with all of its entries.
        /// </summary>
        /// <typeparam name="TKey">Entry key.</typeparam>
        /// <typeparam name="TValue">Entry value.</typeparam>
        /// <param name="design">Design document.</param>
        /// <param name="view">Name of the view to search for.</param>
        /// <param name="queries">Queries used to retrieve the views.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="CouchView{TKey, TValue, TDoc}"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidOperationException" />
        new Task<IEnumerable<CouchView<TKey, TValue, TEntity>>[]> GetViewQueryAsync<TKey, TValue>(string design, string view, IEnumerable<CouchViewOptions<TKey>> queries, CancellationToken cancellationToken);

        /// <summary>
        /// Creates a new <see cref="IFlurlRequest"/> object.
        /// </summary>
        /// <returns><see cref="IFlurlRequest"/> object.</returns>
        new IFlurlRequest NewRequest();

        /// <summary>
        /// Executes the specified query using Mango JSON.
        /// </summary>
        /// <param name="mangoQueryJson">Mango query statement to execute.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="IEnumerable{T}"/> containing the results of the query.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidOperationException" />
        new Task<IEnumerable<TEntity>> QueryAsync(string mangoQueryJson, CancellationToken cancellationToken);

        /// <summary>
        /// Removes the specified document from the data store.
        /// </summary>
        /// <param name="document">Document of type <typeparamref name="T"/> to remove.</param>
        /// <param name="batch">If <see langword="true"/>, operation will be added to the transaction.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        new Task RemoveAsync(TEntity document, bool batch = false, CancellationToken cancellationToken = default);
    }
}
