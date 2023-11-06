using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using CouchDB.Driver;
using CouchDB.Driver.ChangesFeed;
using CouchDB.Driver.ChangesFeed.Responses;
using CouchDB.Driver.DatabaseApiMethodOptions;
using CouchDB.Driver.Indexes;
using CouchDB.Driver.Local;
using CouchDB.Driver.Security;
using CouchDB.Driver.Types;
using CouchDB.Driver.Views;
using CouchDB.Driver.Extensions;
using Flurl.Http;
using Newtonsoft.Json;
using NHibernate;
using Athi.Whippet.Data.Database.NoSQL.Apache.CouchDB.Models;

namespace Athi.Whippet.Data.Database.NoSQL.Apache.CouchDB
{
    /// <summary>
    /// Base class for all repositories in Whippet that are stored in an Apache CouchDB data store. This class must be inherited.
    /// </summary>
    /// <typeparam name="TEntity"><see cref="IWhippetEntity"/> type that is stored in the CouchDB instance.</typeparam>
    public abstract class WhippetCouchDBRepository<TEntity> : ICouchDatabase<TEntity>, IOrderedQueryable<TEntity>, IEnumerable<TEntity>, IEnumerable, IOrderedQueryable, IQueryable, IQueryable<TEntity>, IWhippetEntityRepository<TEntity, WhippetNonNullableString>, IWhippetRepository<TEntity, WhippetNonNullableString>, IWhippetDetachedRepository<TEntity>, IDisposable, IWhippetCouchDBRepository<TEntity>, IWhippetRepository<TEntity, Guid>
        where TEntity : WhippetCouchDBEntity, IWhippetEntity, new()
    {
        // built-in views

        /// <summary>
        /// Retrieves all documents in the data store.
        /// </summary>
        private const string _ALL_DOCS = "_all_docs";
        
        private readonly ICouchDatabase<TEntity> _Database;

        private const int CHUNK_SIZE = 1000;

        private int _chunk;
        
        /// <summary>
        /// Specifies the chunk size when processing large batches of data. If zero or less than zero, the default size specified by <see cref="CHUNK_SIZE"/> will be used.
        /// </summary>
        public virtual int ChunkSize
        {
            get
            {
                if (_chunk <= 0)
                {
                    _chunk = CHUNK_SIZE;
                }

                return _chunk;
            }
            set
            {
                _chunk = Math.Abs(value);
            }
        }
        
        /// <summary>
        /// Gets the name of the current entity as its stored in the data store. This property is read-only.
        /// </summary>
        public virtual string Database
        {
            get
            {
                return _Database.Database;
            }
        }

        /// <summary>
        /// Security information pertaining to the current database connection. This property is read-only.
        /// </summary>
        public virtual ICouchSecurity Security
        {
            get
            {
                return _Database.Security;
            }
        }

        /// <summary>
        /// Represents a list of documents that are not output by views and can be used to hold configuration (or other information) that is required specifically on the local CouchDB instance. This property is read-only.
        /// </summary>
        /// <remarks>See <a href="https://docs.couchdb.org/en/stable/api/local.html">1.7. Local (non-replicating) Documents</a>.</remarks>
        public virtual ILocalDocuments LocalDocuments
        {
            get
            {
                return _Database.LocalDocuments;
            }
        }

        /// <summary>
        /// Gets the underlying type of the document stored in the data store. This property is read-only.
        /// </summary>
        public virtual Type ElementType
        {
            get
            {
                return _Database.ElementType;
            }
        }

        /// <summary>
        /// Gets the expression tree that is associated with the instance of <see cref="IQueryable"/>. This property is read-only.
        /// </summary>
        public virtual Expression Expression
        {
            get
            {
                return _Database.Expression;
            }
        }

        /// <summary>
        /// Gets the query provider that is associated with this data source. This property is read-only.
        /// </summary>
        public virtual IQueryProvider Provider
        {
            get
            {
                return _Database.Provider;
            }
        }

        /// <summary>
        /// Gets the hostname and port of where the database is located. This property is read-only.
        /// </summary>
        public Uri Hostname
        { get; protected set; }
        
        /// <summary>
        /// Gets the <see cref="AuthenticationHeaderValue"/> object containing the authentication information for processing raw HTTP requests with the CouchDB server. This property is read-only.
        /// </summary>
        public AuthenticationHeaderValue RawRequestAuthentication
        { get; protected set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetCouchDBRepository{TEntity}"/> class with no arguments.
        /// </summary>
        private WhippetCouchDBRepository()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhippetCouchDBRepository{TEntity}"/> class with the specified <see cref="ICouchDatabase{TSource}"/> object.
        /// </summary>
        /// <param name="dataStore"><see cref="ICouchDatabase{TSource}"/> object to initialize with.</param>
        /// <param name="hostname"><see cref="Uri"/> that contains the hostname and port of where the database is located.</param>
        /// <param name="authenticationValue"><see cref="AuthenticationHeaderValue"/> object containing the authentication information for processing raw HTTP requests with the CouchDB server.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected WhippetCouchDBRepository(ICouchDatabase<TEntity> dataStore, Uri hostname = null, AuthenticationHeaderValue authenticationValue = null)
            : this()
        {
            if (dataStore == null)
            {
                throw new ArgumentNullException(nameof(dataStore));
            }
            else
            {
                _Database = dataStore;
                Hostname = hostname;
                RawRequestAuthentication = authenticationValue;
            }
        }

        /// <summary>
        /// Returns all document IDs and keys from the current database.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query.</returns>
        protected virtual async Task<WhippetResultContainer<WhippetCouchAllDocsResponseModel>> GetAll()
        {
            if (Hostname == null)
            {
                throw new ArgumentNullException(nameof(Hostname));
            }
            else
            {
                WhippetResultContainer<WhippetCouchAllDocsResponseModel> result = null;
                Tuple<HttpClient, Uri> client = BuildAllDocumentsHttpClient();
                
                HttpResponseMessage response = null;

                string responseBody = null;

                try
                {
                    client.Item1.DefaultRequestHeaders.Authorization = RawRequestAuthentication;
                    
                    response = await client.Item1.GetAsync(client.Item2);
                    response.EnsureSuccessStatusCode();

                    responseBody = await response.Content.ReadAsStringAsync();

                    if (!String.IsNullOrWhiteSpace((responseBody)))
                    {
                        result = new WhippetResultContainer<WhippetCouchAllDocsResponseModel>(WhippetResult.Success, JsonConvert.DeserializeObject<WhippetCouchAllDocsResponseModel>(responseBody));
                    }
                    else
                    {
                        result = new WhippetResultContainer<WhippetCouchAllDocsResponseModel>(WhippetResult.Success, null);
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<WhippetCouchAllDocsResponseModel>(e);
                }
                finally
                {
                    if (response != null)
                    {
                        response.Dispose();
                        response = null;
                    }

                    if (client != null)
                    {
                        client.Item1.Dispose();
                        client = null;
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Creates a <see cref="Tuple{T1, T2}"/> containing an <see cref="HttpClient"/> and target <see cref="Uri"/> to the data store view for all documents.
        /// </summary>
        /// <returns><see cref="Tuple{T1, T2}"/> object.</returns>
        protected virtual Tuple<HttpClient, Uri> BuildAllDocumentsHttpClient()
        {
            HttpClient client = null;
            Uri target = null;
            StringBuilder builder = new StringBuilder(Hostname.ToString());

            if (!builder.ToString().EndsWith('/'))
            {
                builder.Append('/');
            }

            builder.Append(Database);
            builder.Append('/');
            builder.Append(_ALL_DOCS);

            target = new Uri(builder.ToString());

            client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = RawRequestAuthentication;

            return new Tuple<HttpClient, Uri>(client, target);
        }

        /// <summary>
        /// Adds the specified entity of type <typeparamref name="T"/> to the data store.
        /// </summary>
        /// <param name="document">Entity of type <typeparamref name="T"/> to add to the data store.</param>
        /// <param name="batch">If <see langword="true"/>, will add the document as part of a transaction and not commit the immediate operation.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><typeparamref name="T"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidOperationException" />
        public virtual async Task<TEntity> AddAsync(TEntity document, bool batch = false, CancellationToken cancellationToken = default)
        {
            return await _Database.AddAsync(document, batch, cancellationToken);
        }

        /// <summary>
        /// Adds the specified entity of type <typeparamref name="T"/> to the data store.
        /// </summary>
        /// <param name="document">Entity of type <typeparamref name="T"/> to add to the data store.</param>
        /// <param name="options">Options used to determine how the entity will be added to the data store.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><typeparamref name="T"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidOperationException" />
        public virtual async Task<TEntity> AddAsync(TEntity document, AddOptions options, CancellationToken cancellationToken = default)
        {
            return await _Database.AddAsync(document, options, cancellationToken);
        }

        /// <summary>
        /// Adds (or updates) the specified entity of type <typeparamref name="T"/> to the data store.
        /// </summary>
        /// <param name="document">Entity of type <typeparamref name="T"/> to add to the data store.</param>
        /// <param name="batch">If <see langword="true"/>, will add the document as part of a transaction and not commit the immediate operation.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><typeparamref name="T"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidOperationException" />
        public virtual async Task<TEntity> AddOrUpdateAsync(TEntity document, bool batch = false, CancellationToken cancellationToken = default)
        {
            return await _Database.AddOrUpdateAsync(document, batch, cancellationToken);
        }

        /// <summary>
        /// Adds (or updates) the specified entity of type <typeparamref name="T"/> to the data store.
        /// </summary>
        /// <param name="document">Entity of type <typeparamref name="T"/> to add to the data store.</param>
        /// <param name="options">Options used to determine how the entity will be added to the data store.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><typeparamref name="T"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidOperationException" />
        public virtual async Task<TEntity> AddOrUpdateAsync(TEntity document, AddOrUpdateOptions options, CancellationToken cancellationToken = default)
        {
            return await _Database.AddOrUpdateAsync(document, options, cancellationToken);
        }

        /// <summary>
        /// Adds (or updates) the specified entities of type <typeparamref name="T"/> to the data store.
        /// </summary>
        /// <param name="documents">Entities of type <typeparamref name="T"/> to add to the data store.</param>
        /// <param name="cancellationToken"></param>
        /// <returns><typeparamref name="T"/> object collection.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidOperationException" />
        public virtual async Task<IEnumerable<TEntity>> AddOrUpdateRangeAsync(IEnumerable<TEntity> documents, CancellationToken cancellationToken = default)
        {
            return await _Database.AddOrUpdateRangeAsync((documents is IList<TEntity>) ? ((IList<TEntity>)(documents)) : new List<TEntity>(documents), cancellationToken);
        }

        /// <summary>
        /// Adds (or updates) the specified entities of type <typeparamref name="T"/> to the data store.
        /// </summary>
        /// <param name="documents">Entities of type <typeparamref name="T"/> to add to the data store.</param>
        /// <param name="cancellationToken"></param>
        /// <returns><typeparamref name="T"/> object collection.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidOperationException" />
        async Task<IEnumerable<TEntity>> ICouchDatabase<TEntity>.AddOrUpdateRangeAsync(IList<TEntity> documents, CancellationToken cancellationToken)
        {
            return await AddOrUpdateRangeAsync(documents, cancellationToken);
        }

        /// <summary>
        /// Compacts the database, reducing its overall size.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        public virtual async Task CompactAsync(CancellationToken cancellationToken = default)
        {
            await _Database.CompactAsync(cancellationToken);
        }

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
        public virtual async Task<string> CreateIndexAsync(string name, Action<IIndexBuilder<TEntity>> indexBuilderAction, IndexOptions options = null, CancellationToken cancellationToken = default)
        {
            return await _Database.CreateIndexAsync(name, indexBuilderAction, options, cancellationToken);
        }

        /// <summary>
        /// Deletes the specified index from the data store.
        /// </summary>
        /// <param name="designDocument">Design JSON document.</param>
        /// <param name="name">Name of the index to delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidOperationException" />
        public virtual async Task DeleteIndexAsync(string designDocument, string name, CancellationToken cancellationToken = default)
        {
            await _Database.DeleteIndexAsync(designDocument, name, cancellationToken);
        }

        /// <summary>
        /// Deletes the specified index from the data store.
        /// </summary>
        /// <param name="indexInfo">Index information.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidOperationException" />
        public virtual async Task DeleteIndexAsync(IndexInfo indexInfo, CancellationToken cancellationToken = default)
        {
            await _Database.DeleteIndexAsync(indexInfo, cancellationToken);
        }

        /// <summary>
        /// Deletes the specified entities of type <typeparamref name="T"/> from the data store.
        /// </summary>
        /// <param name="documents"><see cref="IEnumerable{T}"/> collection of <typeparamref name="T"/> elements.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task DeleteRangeAsync(IEnumerable<TEntity> documents, CancellationToken cancellationToken = default)
        {
            await _Database.DeleteRangeAsync(documents, cancellationToken);
        }

        /// <summary>
        /// Deletes the specified entities of type <typeparamref name="T"/> from the data store.
        /// </summary>
        /// <param name="documentIds"><see cref="IEnumerable{T}"/> collection of <see cref="DocumentId"/> objects.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual async Task DeleteRangeAsync(IEnumerable<DocumentId> documentIds, CancellationToken cancellationToken = default)
        {
            await _Database.DeleteRangeAsync(documentIds, cancellationToken);
        }

        /// <summary>
        /// Downloads the specified <see cref="CouchAttachment"/> and wraps it in a <see cref="Stream"/> object.
        /// </summary>
        /// <param name="attachment"><see cref="CouchAttachment"/> object to download.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Stream"/> object containing the attachment.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<Stream> DownloadAttachmentAsStreamAsync(CouchAttachment attachment, CancellationToken cancellationToken = default)
        {
            return await _Database.DownloadAttachmentAsStreamAsync(attachment, cancellationToken);
        }

        /// <summary>
        /// Downloads the specified attachment to the local storage device.
        /// </summary>
        /// <param name="attachment"><see cref="CouchAttachment"/> object to download.</param>
        /// <param name="localFolderPath">Local folder path to download the file to.</param>
        /// <param name="localFileName">Local file name to name the downloaded file.</param>
        /// <param name="bufferSize">Buffer size to allow chunking of large data sets.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="string"/> representing the full path to the downloaded file.</returns>
        public virtual async Task<string> DownloadAttachmentAsync(CouchAttachment attachment, string localFolderPath, string localFileName = null, int bufferSize = 4096, CancellationToken cancellationToken = default)
        {
            return await _Database.DownloadAttachmentAsync(attachment, localFolderPath, localFileName, bufferSize, cancellationToken);
        }

        /// <summary>
        /// Commits the transaction to the data store.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        public virtual async Task EnsureFullCommitAsync(CancellationToken cancellationToken = default)
        {
            await _Database.EnsureFullCommitAsync(cancellationToken);
        }

        /// <summary>
        /// Finds the document with the specified document ID.
        /// </summary>
        /// <param name="docId">Document ID.</param>
        /// <param name="withConflicts">Specifies whether documents with conflicts should be considered in the search.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Entity of type <typeparamref name="T"/> (if found).</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidOperationException" />
        public virtual async Task<TEntity> FindAsync(string docId, bool withConflicts = false, CancellationToken cancellationToken = default)
        {
            return await _Database.FindAsync(docId, withConflicts, cancellationToken);
        }

        /// <summary>
        /// Finds the document with the specified document ID.
        /// </summary>
        /// <param name="docId">Document ID.</param>
        /// <param name="options">Options to apply to the search.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Entity of type <typeparamref name="T"/> (if found).</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidOperationException" />
        public virtual async Task<TEntity> FindAsync(string docId, FindOptions options, CancellationToken cancellationToken = default)
        {
            return await _Database.FindAsync(docId, options, cancellationToken);
        }

        /// <summary>
        /// Locates all documents of type <typeparamref name="T"/> that match one or more of the contained document IDs.
        /// </summary>
        /// <param name="docIds">Collection of document IDs used in the query.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <typeparamref name="T"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<IEnumerable<TEntity>> FindManyAsync(IReadOnlyCollection<string> docIds, CancellationToken cancellationToken)
        {
            return await _Database.FindManyAsync(docIds, cancellationToken);
        }

        /// <summary>
        /// Locates all documents of type <typeparamref name="T"/> that match one or more of the contained document IDs.
        /// </summary>
        /// <param name="docIds">Collection of document IDs used in the query.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <typeparamref name="T"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        async Task<List<TEntity>> ICouchDatabase<TEntity>.FindManyAsync(IReadOnlyCollection<string> docIds, CancellationToken cancellationToken)
        {
            IEnumerable<TEntity> list = await FindManyAsync(docIds, cancellationToken);
            return (list is List<TEntity>) ? ((List<TEntity>)(list)) : new List<TEntity>(list);
        }

        /// <summary>
        /// Gets all changes that have taken place in the document store for type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="options">Options to apply to the changes feed.</param>
        /// <param name="filter">Filter to apply to the changes feed.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="ChangesFeedResponse{TSource}"/> object.</returns>
        public virtual async Task<ChangesFeedResponse<TEntity>> GetChangesAsync(ChangesFeedOptions options = null, ChangesFeedFilter filter = null, CancellationToken cancellationToken = default)
        {
            return await _Database.GetChangesAsync(options, filter, cancellationToken);
        }

        /// <summary>
        /// Returns an <see cref="IAsyncEnumerable{T}"/> of continuous changes in the data store.
        /// </summary>
        /// <param name="options">Options to apply to the changes feed.</param>
        /// <param name="filter">Filter to apply to the changes feed.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="IAsyncEnumerable{T}"/> object.</returns>
        public IAsyncEnumerable<ChangesFeedResponseResult<TEntity>> GetContinuousChangesAsync(ChangesFeedOptions options, ChangesFeedFilter filter, CancellationToken cancellationToken)
        {
            return _Database.GetContinuousChangesAsync(options, filter, cancellationToken);
        }

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
        public virtual async Task<CouchViewList<TKey, TValue, TEntity>> GetDetailedViewAsync<TKey, TValue>(string design, string view, CouchViewOptions<TKey> options = null, CancellationToken cancellationToken = default)
        {
            return await _Database.GetDetailedViewAsync<TKey, TValue>(design, view, options, cancellationToken);
        }

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
        public virtual async Task<CouchViewList<TKey, TValue, TEntity>[]> GetDetailedViewQueryAsync<TKey, TValue>(string design, string view, IList<CouchViewOptions<TKey>> queries, CancellationToken cancellationToken = default)
        {
            return await _Database.GetDetailedViewQueryAsync<TKey, TValue>(design, view, queries, cancellationToken);
        }

        /// <summary>
        /// Gets the <see cref="IEnumerator{T}"/> used to iterate over each item in the collection.
        /// </summary>
        /// <returns><see cref="IEnumerator{T}"/> object.</returns>
        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
        {
            return _Database.GetEnumerator();
        }

        /// <summary>
        /// Gets the <see cref="IEnumerator"/> used to iterate over each item in the collection.
        /// </summary>
        /// <returns><see cref="IEnumerator"/> object.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<TEntity>)(this)).GetEnumerator();
        }

        /// <summary>
        /// Retrieves all indexes in the database.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="IndexInfo"/> objects.</returns>
        public virtual async Task<IEnumerable<IndexInfo>> GetIndexesAsync(CancellationToken cancellationToken = default)
        {
            return await _Database.GetIndexesAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves all indexes in the database.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="List{T}"/> collection of <see cref="IndexInfo"/> objects.</returns>
        async Task<List<IndexInfo>> ICouchDatabase<TEntity>.GetIndexesAsync(CancellationToken cancellationToken)
        {
            IEnumerable<IndexInfo> list = await GetIndexesAsync(cancellationToken);
            return (list is List<IndexInfo>) ? ((List<IndexInfo>)(list)) : new List<IndexInfo>(list);
        }

        /// <summary>
        /// Retrieves information about the current data store.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns></returns>
        public virtual async Task<CouchDatabaseInfo> GetInfoAsync(CancellationToken cancellationToken = default)
        {
            return await _Database.GetInfoAsync(cancellationToken);
        }

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
        public virtual async Task<IEnumerable<CouchView<TKey, TValue, TEntity>>> GetViewAsync<TKey, TValue>(string design, string view, CouchViewOptions<TKey> options, CancellationToken cancellationToken)
        {
            return await _Database.GetViewAsync<TKey, TValue>(design, view, options, cancellationToken);
        }

        /// <summary>
        /// Retrieves thew view that matches the specified name with all of its entries.
        /// </summary>
        /// <typeparam name="TKey">Entry key.</typeparam>
        /// <typeparam name="TValue">Entry value.</typeparam>
        /// <param name="design">Design document.</param>
        /// <param name="view">Name of the view to search for.</param>
        /// <param name="options">Options to apply to the view.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="List{T}"/> collection of <see cref="CouchView{TKey, TValue, TDoc}"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidOperationException" />
        async Task<List<CouchView<TKey, TValue, TEntity>>> ICouchDatabase<TEntity>.GetViewAsync<TKey, TValue>(string design, string view, CouchViewOptions<TKey> options, CancellationToken cancellationToken)
        {
            return await _Database.GetViewAsync<TKey, TValue>(design, view, options, cancellationToken);
        }

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
        public virtual async Task<IEnumerable<CouchView<TKey, TValue, TEntity>>[]> GetViewQueryAsync<TKey, TValue>(string design, string view, IEnumerable<CouchViewOptions<TKey>> queries, CancellationToken cancellationToken)
        {
            return await _Database.GetViewQueryAsync<TKey, TValue>(design, view, (queries is IList<CouchViewOptions<TKey>>) ? ((IList<CouchViewOptions<TKey>>)(queries)) : new List<CouchViewOptions<TKey>>(queries), cancellationToken);
        }

        /// <summary>
        /// Retrieves all views that match the specified name with all of its entries.
        /// </summary>
        /// <typeparam name="TKey">Entry key.</typeparam>
        /// <typeparam name="TValue">Entry value.</typeparam>
        /// <param name="design">Design document.</param>
        /// <param name="view">Name of the view to search for.</param>
        /// <param name="queries">Queries used to retrieve the views.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="List{T}"/> collection of <see cref="CouchView{TKey, TValue, TDoc}"/> objects.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidOperationException" />
        async Task<List<CouchView<TKey, TValue, TEntity>>[]> ICouchDatabase<TEntity>.GetViewQueryAsync<TKey, TValue>(string design, string view, IList<CouchViewOptions<TKey>> queries, CancellationToken cancellationToken)
        {
            int count = 0;
            int index = 0;

            List<CouchView<TKey, TValue, TEntity>>[] newList = null;

            IEnumerable<CouchView<TKey, TValue, TEntity>>[] oldList = await GetViewQueryAsync<TKey, TValue>(design, view, queries, cancellationToken);

            if (oldList != null && oldList.Length > 0)
            {
                if (!oldList.TryGetNonEnumeratedCount(out count))
                {
                    count = oldList.Count();
                }

                newList = new List<CouchView<TKey, TValue, TEntity>>[count];

                foreach (IEnumerable<CouchView<TKey, TValue, TEntity>> entry in oldList)
                {
                    if (index < count)
                    {
                        newList[index] = (entry is List<CouchView<TKey, TValue, TEntity>>) ? (List<CouchView<TKey, TValue, TEntity>>)(entry) : new List<CouchView<TKey, TValue, TEntity>>(entry);
                    }

                    index++;
                }
            }

            return newList;
        }

        /// <summary>
        /// Creates a new <see cref="IFlurlRequest"/> object.
        /// </summary>
        /// <returns><see cref="IFlurlRequest"/> object.</returns>
        public virtual IFlurlRequest NewRequest()
        {
            return _Database.NewRequest();
        }

        /// <summary>
        /// Executes the specified query using Mango JSON.
        /// </summary>
        /// <param name="mangoQueryJson">Mango query statement to execute.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="IEnumerable{T}"/> containing the results of the query.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidOperationException" />
        public virtual async Task<IEnumerable<TEntity>> QueryAsync(string mangoQueryJson, CancellationToken cancellationToken)
        {
            return await _Database.QueryAsync(mangoQueryJson, cancellationToken);
        }

        /// <summary>
        /// Executes the specified query using Mango JSON.
        /// </summary>
        /// <param name="mangoQueryJson">Mango query statement to execute.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="List{T}"/> containing the results of the query.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidOperationException" />
        async Task<List<TEntity>> ICouchDatabase<TEntity>.QueryAsync(string mangoQueryJson, CancellationToken cancellationToken)
        {
            IEnumerable<TEntity> list = await QueryAsync(mangoQueryJson, cancellationToken);
            return (list is List<TEntity>) ? ((List<TEntity>)(list)) : new List<TEntity>(list);
        }

        /// <summary>
        /// Executes the specified query using the specified Mango query object.
        /// </summary>
        /// <param name="mangoQuery">Mango query object to execute.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="List{T}"/> containing the results of the query.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="InvalidOperationException" />
        async Task<List<TEntity>> ICouchDatabase<TEntity>.QueryAsync(object mangoQuery, CancellationToken cancellationToken)
        {
            return await _Database.QueryAsync(mangoQuery, cancellationToken);
        }

        /// <summary>
        /// Removes the specified document from the data store.
        /// </summary>
        /// <param name="document">Document of type <typeparamref name="T"/> to remove.</param>
        /// <param name="batch">If <see langword="true"/>, operation will be added to the transaction.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        public async Task RemoveAsync(TEntity document, bool batch = false, CancellationToken cancellationToken = default)
        {
            await _Database.RemoveAsync(document, batch, cancellationToken);
        }

        /// <summary>
        /// Creates a new instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to save in the data store.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        WhippetResult IWhippetDetachedRepository<TEntity>.Create(TEntity item)
        {
            return Task.Run(() => ((IWhippetDetachedRepository<TEntity>)(this)).CreateAsync(item)).Result;
        }

        /// <summary>
        /// Creates a new instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to save in the data store.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        WhippetResult IWhippetRepository<TEntity, WhippetNonNullableString>.Create(TEntity item)
        {
            return ((IWhippetDetachedRepository<TEntity>)(this)).Create(item);
        }

        /// <summary>
        /// Creates a new instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to save in the data store.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        async Task<WhippetResult> IWhippetRepository<TEntity, WhippetNonNullableString>.CreateAsync(TEntity item, CancellationToken? cancellationToken)
        {
            return await ((IWhippetDetachedRepository<TEntity>)(this)).CreateAsync(item, cancellationToken);
        }

        /// <summary>
        /// Asynchronously creates a new instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to save in the data store.</param>
        /// <param name="cancellationToken">Flag to signal to the <see cref="Task{TResult}"/> to stop at the next earliest convenience.</param>
        /// <returns><see cref="Task{TResult}"/> object which contains the result of the domain object operation stored in a <see cref="WhippetResult"/>.</returns>
        async Task<WhippetResult> IWhippetDetachedRepository<TEntity>.CreateAsync(TEntity item, CancellationToken? cancellationToken)
        {
            WhippetResult result = WhippetResult.Success;
            TEntity newItem = null;

            try
            {
                newItem = await AddAsync(item);
                result = new WhippetResult(WhippetResultSeverity.Success, resultObject: newItem);
            }
            catch (Exception e)
            {
                result = new WhippetResult(e);
            }

            return result;
        }

        /// <summary>
        /// Updates an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to update in the data store.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        WhippetResult IWhippetDetachedRepository<TEntity>.Update(TEntity item)
        {
            return Task.Run(() => ((IWhippetDetachedRepository<TEntity>)(this)).UpdateAsync(item)).Result;
        }

        /// <summary>
        /// Updates an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to update in the data store.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        WhippetResult IWhippetRepository<TEntity, WhippetNonNullableString>.Update(TEntity item)
        {
            return ((IWhippetDetachedRepository<TEntity>)(this)).Update(item);
        }

        /// <summary>
        /// Updates an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to update in the data store.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        async Task<WhippetResult> IWhippetRepository<TEntity, WhippetNonNullableString>.UpdateAsync(TEntity item, CancellationToken? cancellationToken)
        {
            return await ((IWhippetDetachedRepository<TEntity>)(this)).UpdateAsync(item);
        }

        /// <summary>
        /// Asynchronously updates an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to update in the data store.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        async Task<WhippetResult> IWhippetDetachedRepository<TEntity>.UpdateAsync(TEntity item, CancellationToken? cancellationToken)
        {
            WhippetResult result = WhippetResult.Success;
            TEntity newItem = null;

            try
            {
                newItem = await AddOrUpdateAsync(item);
                result = new WhippetResult(WhippetResultSeverity.Success, resultObject: newItem);
            }
            catch (Exception e)
            {
                result = new WhippetResult(e);
            }

            return result;
        }

        /// <summary>
        /// Deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to delete in the data store.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        WhippetResult IWhippetDetachedRepository<TEntity>.Delete(TEntity item)
        {
            return Task.Run(() => ((IWhippetDetachedRepository<TEntity>)(this)).DeleteAsync(item)).Result;
        }

        /// <summary>
        /// Deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to delete in the data store.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        WhippetResult IWhippetRepository<TEntity, WhippetNonNullableString>.Delete(TEntity item)
        {
            return ((IWhippetDetachedRepository<TEntity>)(this)).Delete(item);
        }

        /// <summary>
        /// Deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to delete in the data store.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        async Task<WhippetResult> IWhippetRepository<TEntity, WhippetNonNullableString>.DeleteAsync(TEntity item, CancellationToken? cancellationToken)
        {
            return await ((IWhippetDetachedRepository<TEntity>)(this)).DeleteAsync(item);
        }

        /// <summary>
        /// Deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to delete in the data store.</param>
        /// <param name="hardDelete">If <see langword="true"/>, will remove the entry from the data store. Otherwise, will mark the record as deleted. Note that this only applies to entities that implement the <see cref="IWhippetSoftDeleteEntity"/> interface. If the entity does not implement this interface, it will be treated as a hard delete.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        WhippetResult IWhippetDetachedRepository<TEntity>.Delete(TEntity item, bool hardDelete)
        {
            return Task.Run(() => ((IWhippetDetachedRepository<TEntity>)(this)).DeleteAsync(item)).Result;
        }

        /// <summary>
        /// Deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to delete in the data store.</param>
        /// <param name="hardDelete">If <see langword="true"/>, will remove the entry from the data store. Otherwise, will mark the record as deleted. Note that this only applies to entities that implement the <see cref="IWhippetSoftDeleteEntity"/> interface. If the entity does not implement this interface, it will be treated as a hard delete.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        WhippetResult IWhippetRepository<TEntity, WhippetNonNullableString>.Delete(TEntity item, bool hardDelete)
        {
            return ((IWhippetDetachedRepository<TEntity>)(this)).Delete(item, hardDelete);
        }

        /// <summary>
        /// Asynchronously deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to delete in the data store.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        async Task<WhippetResult> IWhippetDetachedRepository<TEntity>.DeleteAsync(TEntity item, CancellationToken? cancellationToken)
        {
            WhippetResult result = WhippetResult.Success;

            try
            {
                await RemoveAsync(item);
                result = new WhippetResult(WhippetResultSeverity.Success);
            }
            catch (Exception e)
            {
                result = new WhippetResult(e);
            }

            return result;
        }

        /// <summary>
        /// Asynchronously deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to delete in the data store.</param>
        /// <param name="hardDelete">If <see langword="true"/>, will remove the entry from the data store. Otherwise, will mark the record as deleted. Note that this only applies to entities that implement the <see cref="IWhippetSoftDeleteEntity"/> interface. If the entity does not implement this interface, it will be treated as a hard delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        async Task<WhippetResult> IWhippetDetachedRepository<TEntity>.DeleteAsync(TEntity item, bool hardDelete, CancellationToken? cancellationToken)
        {
            return await ((IWhippetDetachedRepository<TEntity>)(this)).DeleteAsync(item, cancellationToken);
        }

        /// <summary>
        /// Asynchronously deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to delete in the data store.</param>
        /// <param name="hardDelete">If <see langword="true"/>, will remove the entry from the data store. Otherwise, will mark the record as deleted. Note that this only applies to entities that implement the <see cref="IWhippetSoftDeleteEntity"/> interface. If the entity does not implement this interface, it will be treated as a hard delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        async Task<WhippetResult> IWhippetRepository<TEntity, WhippetNonNullableString>.DeleteAsync(TEntity item, bool hardDelete, CancellationToken? cancellationToken)
        {
            return await ((IWhippetDetachedRepository<TEntity>)(this)).DeleteAsync(item, hardDelete, cancellationToken);
        }

        /// <summary>
        /// Gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <typeparam name="TKey">Type of key the entity uses.</typeparam>
        /// <param name="key">Unique identifier of the item to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        WhippetResultContainer<TEntity> IWhippetDetachedRepository<TEntity>.Get<TKey>(TKey key)
        {
            return Task.Run(() => ((IWhippetDetachedRepository<TEntity>)(this)).GetAsync(key)).Result;
        }

        /// <summary>
        /// Gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="key">Unique identifier of the item to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        WhippetResultContainer<TEntity> IWhippetRepository<TEntity, WhippetNonNullableString>.Get(WhippetNonNullableString key)
        {
            return Task.Run(() => ((IWhippetDetachedRepository<TEntity>)(this)).GetAsync(key)).Result;
        }

        /// <summary>
        /// Retrieves all items of <typeparamref name="TEntity"/> type in the data store.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding items (if any).</returns>
        WhippetResultContainer<IEnumerable<TEntity>> IWhippetDetachedRepository<TEntity>.GetAll()
        {
            return Task.Run(() => ((IWhippetDetachedRepository<TEntity>)(this)).GetAllAsync()).Result;
        }

        /// <summary>
        /// Retrieves all items of <typeparamref name="TEntity"/> type in the data store.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding items (if any).</returns>
        WhippetResultContainer<IEnumerable<TEntity>> IWhippetRepository<TEntity, WhippetNonNullableString>.GetAll()
        {
            return ((IWhippetDetachedRepository<TEntity>)(this)).GetAll();
        }

        /// <summary>
        /// Asynchronously gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="key">Unique identifier of the item to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <typeparam name="TKey">Type of key the entity uses.</typeparam>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        async Task<WhippetResultContainer<TEntity>> IWhippetDetachedRepository<TEntity>.GetAsync<TKey>(TKey key, CancellationToken? cancellationToken)
        {
            WhippetResultContainer<TEntity> result = new WhippetResultContainer<TEntity>(WhippetResult.Success, null);
            TEntity item = null;

            try
            {
                item = await FindAsync(Convert.ToString(key), cancellationToken: cancellationToken.GetValueOrDefault());
                result = new WhippetResultContainer<TEntity>(WhippetResult.Success, item);
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<TEntity>(e);
            }

            return result;
        }

        /// <summary>
        /// Asynchronously gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="key">Unique identifier of the item to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        async Task<WhippetResultContainer<TEntity>> IWhippetRepository<TEntity, WhippetNonNullableString>.GetAsync(WhippetNonNullableString key, CancellationToken? cancellationToken)
        {
            return await ((IWhippetDetachedRepository<TEntity>)(this)).GetAsync(key, cancellationToken);
        }

        /// <summary>
        /// Asynchronously retrieves all items of <typeparamref name="TEntity"/> type in the data store.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        async Task<WhippetResultContainer<IEnumerable<TEntity>>> IWhippetDetachedRepository<TEntity>.GetAllAsync(CancellationToken? cancellationToken)
        {
            WhippetResultContainer<IEnumerable<TEntity>> result = new WhippetResultContainer<IEnumerable<TEntity>>(WhippetResult.Success, Enumerable.Empty<TEntity>());
            IEnumerable<TEntity> entities = null;

            try
            {
                entities = await (from entity in _Database select entity).ToListAsync();
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<IEnumerable<TEntity>>(e);
            }

            return result;
        }

        /// <summary>
        /// Asynchronously retrieves all items of <typeparamref name="TEntity"/> type in the data store.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        async Task<WhippetResultContainer<IEnumerable<TEntity>>> IWhippetRepository<TEntity, WhippetNonNullableString>.GetAllAsync(CancellationToken? cancellationToken)
        {
            return await ((IWhippetDetachedRepository<TEntity>)(this)).GetAllAsync(cancellationToken);
        }

        /// <summary>
        /// Commits all changes to the data store for underlying data stores that perform change queries in batches. By default, this method has no implementation; however, it may be overridden in derived classes to perform the underlying commit.
        /// </summary>
        void IWhippetRepository<TEntity, WhippetNonNullableString>.Commit()
        {
            ((IWhippetDetachedRepository<TEntity>)(this)).Commit();
        }

        /// <summary>
        /// Commits all changes to the data store for underlying data stores that perform change queries in batches. By default, this method has no implementation; however, it may be overridden in derived classes to perform the underlying commit.
        /// </summary>
        void IWhippetDetachedRepository<TEntity>.Commit()
        {
            Task.Run(() => ((IWhippetDetachedRepository<TEntity>)(this)).CommitAsync(default(CancellationToken)));
        }

        /// <summary>
        /// Commits all changes to the data store for underlying data stores that perform change queries in batches. By default, this method has no implementation; however, it may be overridden in derived classes to perform the underlying commit.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        async Task IWhippetDetachedRepository<TEntity>.CommitAsync(CancellationToken cancellationToken)
        {
            await EnsureFullCommitAsync(cancellationToken);
        }

        /// <summary>
        /// Commits all changes to the data store for underlying data stores that perform change queries in batches. By default, this method has no implementation; however, it may be overridden in derived classes to perform the underlying commit.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        async Task IWhippetRepository<TEntity, WhippetNonNullableString>.CommitAsync(CancellationToken cancellationToken)
        {
            await ((IWhippetDetachedRepository<TEntity>)(this)).CommitAsync(cancellationToken);
        }

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        /// <param name="entity"><typeparamref name="TEntity"/> to refresh.</param>
        /// <exception cref="NotImplementedException"></exception>
        void IWhippetRepository<TEntity, WhippetNonNullableString>.RefreshEntityContext(TEntity entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        /// <param name="entity"><typeparamref name="TEntity"/> to refresh.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        /// <exception cref="NotImplementedException"></exception>
        Task IWhippetRepository<TEntity, WhippetNonNullableString>.RefreshEntityContextAsync(TEntity entity, CancellationToken? cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Begins a transaction scope for the database event.
        /// </summary>
        /// <returns><see cref="ITransaction"/> object that represents a handle to the transaction.</returns>
        /// <exception cref="NotImplementedException"></exception>
        ITransaction IWhippetEntityRepository<TEntity, WhippetNonNullableString>.BeginTransaction()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Begins a transaction scope for database event.
        /// </summary>
        /// <param name="isolationLevel">Isolation level to apply to the transaction.</param>
        /// <returns><see cref="ITransaction"/> object that represents a handle to the transaction.</returns>
        /// <exception cref="NotImplementedException"></exception>
        ITransaction IWhippetEntityRepository<TEntity, WhippetNonNullableString>.BeginTransaction(IsolationLevel isolationLevel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Begins a transaction scope for database event.
        /// </summary>
        /// <returns><see cref="ITransaction"/> object that represents a handle to the transaction.</returns>
        /// <exception cref="NotImplementedException"></exception>
        ITransaction IWhippetEntityRepository<TEntity, WhippetNonNullableString>.BeginStatelessTransaction()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Begins a transaction scope for database event.
        /// </summary>
        /// <param name="isolationLevel">Isolation level to apply to the transaction.</param>
        /// <returns><see cref="ITransaction"/> object that represents a handle to the transaction.</returns>
        /// <exception cref="NotImplementedException"></exception>
        ITransaction IWhippetEntityRepository<TEntity, WhippetNonNullableString>.BeginStatelessTransaction(IsolationLevel isolationLevel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// When overridden in a derived class, releases resources used from memory.
        /// </summary>
        public virtual void Dispose()
        { }

        /// <summary>
        /// Creates a new instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to save in the data store.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        WhippetResult IWhippetRepository<TEntity, Guid>.Create(TEntity item)
        {
            return Task.Run(() => ((IWhippetRepository<TEntity, Guid>)(this)).CreateAsync(item)).Result;
        }

        /// <summary>
        /// Asynchronously creates a new instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to save in the data store.</param>
        /// <param name="cancellationToken">Flag to signal to the <see cref="Task{TResult}"/> to stop at the next earliest convenience.</param>
        /// <returns><see cref="Task{TResult}"/> object which contains the result of the domain object operation stored in a <see cref="WhippetResult"/>.</returns>
        async Task<WhippetResult> IWhippetRepository<TEntity, Guid>.CreateAsync(TEntity item, CancellationToken? cancellationToken)
        {
            return await ((IWhippetDetachedRepository<TEntity>)(this)).CreateAsync(item, cancellationToken);
        }

        /// <summary>
        /// Updates an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to update in the data store.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        WhippetResult IWhippetRepository<TEntity, Guid>.Update(TEntity item)
        {
            return Task.Run(() => ((IWhippetDetachedRepository<TEntity>)(this)).UpdateAsync(item)).Result;
        }

        /// <summary>
        /// Asynchronously updates an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to update in the data store.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        async Task<WhippetResult> IWhippetRepository<TEntity, Guid>.UpdateAsync(TEntity item, CancellationToken? cancellationToken)
        {
            return await ((IWhippetDetachedRepository<TEntity>)(this)).UpdateAsync(item, cancellationToken);
        }

        /// <summary>
        /// Deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to delete in the data store.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        WhippetResult IWhippetRepository<TEntity, Guid>.Delete(TEntity item)
        {
            return Task.Run(() => ((IWhippetDetachedRepository<TEntity>)(this)).DeleteAsync(item)).Result;
        }

        /// <summary>
        /// Deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to delete in the data store.</param>
        /// <param name="hardDelete">If <see langword="true"/>, will remove the entry from the data store. Otherwise, will mark the record as deleted. Note that this only applies to entities that implement the <see cref="IWhippetSoftDeleteEntity"/> interface. If the entity does not implement this interface, it will be treated as a hard delete.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        WhippetResult IWhippetRepository<TEntity, Guid>.Delete(TEntity item, bool hardDelete)
        {
            return Task.Run(() => ((IWhippetDetachedRepository<TEntity>)(this)).DeleteAsync(item)).Result;
        }

        /// <summary>
        /// Asynchronously deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to delete in the data store.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        async Task<WhippetResult> IWhippetRepository<TEntity, Guid>.DeleteAsync(TEntity item, CancellationToken? cancellationToken)
        {
            return await ((IWhippetDetachedRepository<TEntity>)(this)).DeleteAsync(item, cancellationToken);
        }

        /// <summary>
        /// Asynchronously deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TEntity"/> to delete in the data store.</param>
        /// <param name="hardDelete">If <see langword="true"/>, will remove the entry from the data store. Otherwise, will mark the record as deleted. Note that this only applies to entities that implement the <see cref="IWhippetSoftDeleteEntity"/> interface. If the entity does not implement this interface, it will be treated as a hard delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        async Task<WhippetResult> IWhippetRepository<TEntity, Guid>.DeleteAsync(TEntity item, bool hardDelete, CancellationToken? cancellationToken)
        {
            return await ((IWhippetDetachedRepository<TEntity>)(this)).DeleteAsync(item, cancellationToken);
        }

        /// <summary>
        /// Gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="key">Unique identifier of the item to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        WhippetResultContainer<TEntity> IWhippetRepository<TEntity, Guid>.Get(Guid key)
        {
            return Task.Run(() => ((IWhippetDetachedRepository<TEntity>)(this)).GetAsync(key)).Result;
        }

        /// <summary>
        /// Retrieves all items of <typeparamref name="TEntity"/> type in the data store.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding items (if any).</returns>
        WhippetResultContainer<IEnumerable<TEntity>> IWhippetRepository<TEntity, Guid>.GetAll()
        {
            return Task.Run(() => ((IWhippetDetachedRepository<TEntity>)(this)).GetAllAsync()).Result;
        }

        /// <summary>
        /// Asynchronously gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="key">Unique identifier of the item to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        async Task<WhippetResultContainer<TEntity>> IWhippetRepository<TEntity, Guid>.GetAsync(Guid key, CancellationToken? cancellationToken)
        {
            return await ((IWhippetDetachedRepository<TEntity>)(this)).GetAsync(key, cancellationToken);
        }

        /// <summary>
        /// Asynchronously retrieves all items of <typeparamref name="TEntity"/> type in the data store.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        async Task<WhippetResultContainer<IEnumerable<TEntity>>> IWhippetRepository<TEntity, Guid>.GetAllAsync(CancellationToken? cancellationToken)
        {
            return await ((IWhippetDetachedRepository<TEntity>)(this)).GetAllAsync(cancellationToken);
        }

        /// <summary>
        /// Commits all changes to the data store for underlying data stores that perform change queries in batches. By default, this method has no implementation; however, it may be overridden in derived classes to perform the underlying commit.
        /// </summary>
        void IWhippetRepository<TEntity, Guid>.Commit()
        {
            Task.WaitAll(Task.Run(() => ((IWhippetRepository<TEntity, Guid>)(this)).Commit()));
        }

        /// <summary>
        /// Commits all changes to the data store for underlying data stores that perform change queries in batches. By default, this method has no implementation; however, it may be overridden in derived classes to perform the underlying commit.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        async Task IWhippetRepository<TEntity, Guid>.CommitAsync(CancellationToken cancellationToken)
        {
            await ((IWhippetDetachedRepository<TEntity>)(this)).CommitAsync(cancellationToken);
        }

        /// <summary>
        /// For repositories that maintain a context state, evicts the specified entity from the context instance.
        /// </summary>
        /// <param name="entity"><typeparamref name="TEntity"/> object to evict from the context.</param>
        void IWhippetRepository<TEntity, Guid>.RefreshEntityContext(TEntity entity)
        {
            Task.WaitAll(Task.Run(() => ((IWhippetRepository<TEntity, Guid>)(this)).RefreshEntityContext(entity)));
        }

        /// <summary>
        /// For repositories that maintain a context state, evicts the specified entity from the context instance.
        /// </summary>
        /// <param name="entity"><typeparamref name="TEntity"/> object to evict from the context.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        /// <exception cref="InvalidOperationException" />
        Task IWhippetRepository<TEntity, Guid>.RefreshEntityContextAsync(TEntity entity, CancellationToken? cancellationToken)
        {
            throw new InvalidOperationException();
        }
    }
}
