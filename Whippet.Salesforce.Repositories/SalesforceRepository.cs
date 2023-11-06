using System;
using System.Data;
using System.Text;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using Newtonsoft.Json.Linq;
using NHibernate;
using NodaTime;
using Salesforce.Common.Models.Json;
using Athi.Whippet;
using Athi.Whippet.Data;
using Athi.Whippet.Data.CQRS;

namespace Athi.Whippet.Salesforce.Repositories
{
    /// <summary>
    /// Base class for all Salesforce repositories. This class must be inherited.
    /// </summary>
    public abstract class SalesforceRepository<TSalesforceObject> : IWhippetExternalQueryRepository<TSalesforceObject, SalesforceReference>, IWhippetRepository<TSalesforceObject, Guid>, IWhippetEntityRepository<TSalesforceObject, SalesforceReference>
        where TSalesforceObject : class, ISalesforceObject, new()
    {
        private List<string> _availableProperties;

        /// <summary>
        /// Represents the ID column for all Salesforce objects.
        /// </summary>
        protected const string ObjectIdColumn = "id";

        /// <summary>
        /// Gets the <see cref="ISalesforceClient"/> which represents a connection to a Salesforce instance. This property is read-only.
        /// </summary>
        protected ISalesforceClient Client
        { get; private set; }

        /// <summary>
        /// Gets the default fields that are ignored in CREATE statements. This property is read-only.
        /// </summary>
        protected virtual IEnumerable<string> DefaultIgnoreFields
        {
            get
            {
                return new[]
                {
                    "IsDeleted",
                    "IsEmailBounced"
                };
            }
        }

        /// <summary>
        /// Gets a list of available properties for <typeparamref name="TSalesforceObject"/>. This property is read-only.
        /// </summary>
        protected IReadOnlyList<string> AvailableProperties
        {
            get
            {
                return AvailablePropertiesInternal.AsReadOnly();
            }
        }

        /// <summary>
        /// Gets the internal <see cref="List{T}"/> of available properties. This property is read-only.
        /// </summary>
        private List<string> AvailablePropertiesInternal
        {
            get
            {
                if (_availableProperties == null)
                {
                    _availableProperties = new List<string>();
                }

                return _availableProperties;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceRepository{TSalesforceObject}"/> class with no arguments.
        /// </summary>
        private SalesforceRepository()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesforceRepository{TSalesforceObject}"/> class with the specified <see cref="ISalesforceClient"/> object.
        /// </summary>
        /// <param name="client"><see cref="ISalesforceClient"/> object to initialize with.</param>
        /// <exception cref="Exception" />
        /// <exception cref="ArgumentNullException"></exception>
        public SalesforceRepository(ISalesforceClient client)
            : this()
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }
            else
            {
                WhippetResultContainer<IEnumerable<SalesforceEntityDefinition>> definitions = null;

                Client = client;
                definitions = GetEntityFieldDefinition(new TSalesforceObject().ExternalTableName);

                if (definitions.IsSuccess)
                {
                    if (definitions.HasItem)
                    {
                        AvailablePropertiesInternal.AddRange(definitions.Item.Select(d => d.QualifiedApiName));
                    }
                }
                else
                {
                    throw definitions.Exception;
                }
            }
        }

        /// <summary>
        /// Creates a new instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TSalesforceObject"/> to save in the data store.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResult Create(TSalesforceObject item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                return Task.Run(() => CreateAsync(item)).Result;
            }
        }

        /// <summary>
        /// Asynchronously creates a new instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TSalesforceObject"/> to save in the data store.</param>
        /// <param name="cancellationToken">Flag to signal to the <see cref="Task{TResult}"/> to stop at the next earliest convenience.</param>
        /// <returns><see cref="Task{TResult}"/> object which contains the result of the domain object operation stored in a <see cref="WhippetResult"/>.</returns>
        public abstract Task<WhippetResult> CreateAsync(TSalesforceObject item, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Updates an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TSalesforceObject"/> to update in the data store.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        public virtual WhippetResult Update(TSalesforceObject item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                return Task.Run(() => UpdateAsync(item)).Result;
            }
        }

        /// <summary>
        /// Asynchronously updates an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TSalesforceObject"/> to update in the data store.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        public abstract Task<WhippetResult> UpdateAsync(TSalesforceObject item, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TSalesforceObject"/> to delete in the data store.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        public virtual WhippetResult Delete(TSalesforceObject item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            else
            {
                return Task.Run(() => DeleteAsync(item)).Result;
            }
        }

        /// <summary>
        /// Deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TSalesforceObject"/> to delete in the data store.</param>
        /// <param name="hardDelete">This value is always ignored.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        WhippetResult IWhippetRepository<TSalesforceObject, Guid>.Delete(TSalesforceObject item, bool hardDelete)
        {
            return Delete(item);
        }

        /// <summary>
        /// Deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TSalesforceObject"/> to delete in the data store.</param>
        /// <param name="hardDelete">This value is always ignored.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        WhippetResult IWhippetRepository<TSalesforceObject, SalesforceReference>.Delete(TSalesforceObject item, bool hardDelete)
        {
            return Delete(item);
        }

        /// <summary>
        /// Asynchronously deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TSalesforceObject"/> to delete in the data store.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        public abstract Task<WhippetResult> DeleteAsync(TSalesforceObject item, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Asynchronously deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TSalesforceObject"/> to delete in the data store.</param>
        /// <param name="hardDelete">This value is always ignored.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        async Task<WhippetResult> IWhippetRepository<TSalesforceObject, Guid>.DeleteAsync(TSalesforceObject item, bool hardDelete, CancellationToken? cancellationToken)
        {
            return await DeleteAsync(item, cancellationToken);
        }

        /// <summary>
        /// Asynchronously deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TSalesforceObject"/> to delete in the data store.</param>
        /// <param name="hardDelete">This value is always ignored.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        async Task<WhippetResult> IWhippetRepository<TSalesforceObject, SalesforceReference>.DeleteAsync(TSalesforceObject item, bool hardDelete, CancellationToken? cancellationToken)
        {
            return await DeleteAsync(item, cancellationToken);
        }

        /// <summary>
        /// Deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TSalesforceObject"/> to delete in the data store.</param>
        /// <param name="hardDelete">If <see langword="true"/>, will permanently delete the record.</param>
        /// <returns><see cref="WhippetResult"/> object which contains the result of the domain object operation.</returns>
        WhippetResult IWhippetDetachedRepository<TSalesforceObject>.Delete(TSalesforceObject item, bool hardDelete)
        {
            return Delete(item);
        }

        /// <summary>
        /// Asynchronously deletes an existing instance of the specified item in the data store.
        /// </summary>
        /// <param name="item">Item of type <typeparamref name="TSalesforceObject"/> to delete in the data store.</param>
        /// <param name="hardDelete">This value is always ignored.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        async Task<WhippetResult> IWhippetDetachedRepository<TSalesforceObject>.DeleteAsync(TSalesforceObject item, bool hardDelete, CancellationToken? cancellationToken)
        {
            return await DeleteAsync(item, cancellationToken);
        }

        /// <summary>
        /// Gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="key">Unique identifier of the item to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{TSalesforceObject}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="NotImplementedException" />
        WhippetResultContainer<TSalesforceObject> IWhippetRepository<TSalesforceObject, Guid>.Get(Guid key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <typeparam name="TDetachedKey">Type of key the entity uses.</typeparam>
        /// <param name="key">Unique identifier of the item to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        WhippetResultContainer<TSalesforceObject> IWhippetDetachedRepository<TSalesforceObject>.Get<TDetachedKey>(TDetachedKey key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <typeparam name="TDetachedKey">Type of key the entity uses.</typeparam>
        /// <param name="key">Unique identifier of the item to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        Task<WhippetResultContainer<TSalesforceObject>> IWhippetDetachedRepository<TSalesforceObject>.GetAsync<TDetachedKey>(TDetachedKey key, CancellationToken? cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves all items of <typeparamref name="TSalesforceObject"/> type in the data store.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{TSalesforceObject}"/> containing the result of the domain object operation and the corresponding items (if any).</returns>
        public virtual WhippetResultContainer<IEnumerable<TSalesforceObject>> GetAll()
        {
            return Task.Run(() => GetAllAsync()).Result;
        }

        /// <summary>
        /// Asynchronously gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="key">Unique identifier of the item to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TSalesforceObject}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="NotImplementedException" />
        Task<WhippetResultContainer<TSalesforceObject>> IWhippetRepository<TSalesforceObject, Guid>.GetAsync(Guid key, CancellationToken? cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Asynchronously retrieves all items of <typeparamref name="TSalesforceObject"/> type in the data store.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TSalesforceObject}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public abstract Task<WhippetResultContainer<IEnumerable<TSalesforceObject>>> GetAllAsync(CancellationToken? cancellationToken = null);

        /// <summary>
        /// Gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="key">Unique identifier of the item to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public virtual WhippetResultContainer<TSalesforceObject> Get(SalesforceReference key)
        {
            return Task.Run(() => GetAsync(key)).Result;
        }

        /// <summary>
        /// Asynchronously gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="key">Unique identifier of the item to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public abstract Task<WhippetResultContainer<TSalesforceObject>> GetAsync(SalesforceReference key, CancellationToken? cancellationToken = null);

        /// <summary>
        /// Commits all changes to the data store for underlying data stores that perform change queries in batches. By default, this method has no implementation; however, it may be overridden in derived classes to perform the underlying commit.
        /// </summary>
        void IWhippetRepository<TSalesforceObject, Guid>.Commit()
        {
            return;
        }

        /// <summary>
        /// Commits all changes to the data store for underlying data stores that perform change queries in batches. By default, this method has no implementation; however, it may be overridden in derived classes to perform the underlying commit.
        /// </summary>
        void IWhippetRepository<TSalesforceObject, SalesforceReference>.Commit()
        {
            return;
        }

        /// <summary>
        /// Commits all changes to the data store for underlying data stores that perform change queries in batches. By default, this method has no implementation; however, it may be overridden in derived classes to perform the underlying commit.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        async Task IWhippetRepository<TSalesforceObject, Guid>.CommitAsync(CancellationToken cancellationToken)
        {
            await Task.Run(() => { return; });
        }

        /// <summary>
        /// Commits all changes to the data store for underlying data stores that perform change queries in batches. By default, this method has no implementation; however, it may be overridden in derived classes to perform the underlying commit.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        async Task IWhippetRepository<TSalesforceObject, SalesforceReference>.CommitAsync(CancellationToken cancellationToken)
        {
            await Task.Run(() => { return; });
        }

        /// <summary>
        /// Begins a transaction scope for NHibernate.
        /// </summary>
        /// <returns><see cref="ITransaction"/> object that represents a handle to the transaction.</returns>
        ITransaction IWhippetEntityRepository<TSalesforceObject, SalesforceReference>.BeginStatelessTransaction()
        {
            return null;
        }

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        /// <returns><see cref="ITransaction"/> object.</returns>
        /// <exception cref="NotImplementedException"></exception>
        ITransaction IWhippetEntityRepository<TSalesforceObject, SalesforceReference>.BeginTransaction()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        /// <param name="isolationLevel"><see cref="IsolationLevel"/> value.</param>
        /// <returns><see cref="ITransaction"/> object.</returns>
        /// <exception cref="NotImplementedException"></exception>
        ITransaction IWhippetEntityRepository<TSalesforceObject, SalesforceReference>.BeginTransaction(IsolationLevel isolationLevel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        /// <param name="isolationLevel"><see cref="IsolationLevel"/> value.</param>
        /// <returns><see cref="ITransaction"/> object.</returns>
        /// <exception cref="NotImplementedException"></exception>
        ITransaction IWhippetEntityRepository<TSalesforceObject, SalesforceReference>.BeginStatelessTransaction(IsolationLevel isolationLevel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Disposes of the current object and releases its resources from memory.
        /// </summary>
        public virtual void Dispose()
        {
            Client.Dispose();
            Client = null;
        }

        /// <summary>
        /// Gets an <see cref="ISalesforceObject"/>'s definition.
        /// </summary>
        /// <param name="entityType">Entity type.</param>
        /// <returns>List of <see cref="SalesforceEntityDefinition"/> entries that comprise the <see cref="ISalesforceObject"/> type.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        protected virtual WhippetResultContainer<IEnumerable<SalesforceEntityDefinition>> GetEntityFieldDefinition(string entityType)
        {
            if (String.IsNullOrWhiteSpace(entityType))
            {
                throw new ArgumentNullException(nameof(entityType));
            }
            else
            {
                return Task.Run(() => GetEntityFieldDefinitionAsync(entityType)).Result;
            }
        }

        /// <summary>
        /// Gets an <see cref="ISalesforceObject"/>'s definition.
        /// </summary>
        /// <param name="entityType">Entity type.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>List of <see cref="SalesforceEntityDefinition"/> entries that comprise the <see cref="ISalesforceObject"/> type.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        protected async virtual Task<WhippetResultContainer<IEnumerable<SalesforceEntityDefinition>>> GetEntityFieldDefinitionAsync(string entityType, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(entityType))
            {
                throw new ArgumentNullException(nameof(entityType));
            }
            else
            {
                WhippetResultContainer<IEnumerable<SalesforceEntityDefinition>> result = null;
                QueryResult<dynamic> queryResult;

                List<SalesforceEntityDefinition> defs = new List<SalesforceEntityDefinition>();

                string entityDefinitionId = null;
                string qualifiedApiName = null;
                string label = null;
                string durableId = null;
                string relationshipName = null;

                bool fieldHistoryIsTracked = default(bool);
                bool isIndexed = default(bool);

                Instant? lastUpdate = null;

                try
                {
                    queryResult = await Client.QueryAsync<dynamic>(String.Format("select EntityDefinitionId,QualifiedApiName,Label,DurableId,IsFieldHistoryTracked,IsIndexed,LastModifiedDate,RelationshipName from FieldDefinition where EntityDefinitionId='{0}'", entityType));

                    foreach (dynamic record in queryResult.Records)
                    {
                        entityDefinitionId = ((JToken)(record.EntityDefinitionId)).Value<string>();
                        qualifiedApiName = ((JToken)(record.QualifiedApiName)).Value<string>();
                        label = ((JToken)(record.Label)).Value<string>();
                        durableId = ((JToken)(record.DurableId)).Value<string>();
                        fieldHistoryIsTracked = ((JToken)(record.IsFieldHistoryTracked)).Value<bool>();
                        isIndexed = ((JToken)(record.IsIndexed)).Value<bool>();
                        relationshipName = ((JToken)(record.RelationshipName)).Value<string>();

                        defs.Add(new SalesforceEntityDefinition(entityDefinitionId, qualifiedApiName, label, durableId, fieldHistoryIsTracked, isIndexed, lastUpdate, relationshipName));
                    }

                    result = new WhippetResultContainer<IEnumerable<SalesforceEntityDefinition>>(WhippetResult.Success, defs);
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<SalesforceEntityDefinition>>(new WhippetResult(e), null);
                }

                return result;
            }
        }

        /// <summary>
        /// Generates a SOQL SELECT statement.
        /// </summary>
        /// <returns>SOSQL SELECT statement with no WHERE clause.</returns>
        protected virtual string GenerateSelect()
        {
            StringBuilder builder = new StringBuilder();
            TSalesforceObject obj = new TSalesforceObject();

            builder.Append("SELECT ");

            foreach (string field in AvailableProperties)
            {
                builder.Append(field);
                builder.Append(',');
            }

            builder = builder.Remove(builder.Length - 1, 1);
            builder.Append(' ');
            builder.Append("FROM");
            builder.Append(' ');
            builder.Append(obj.ExternalTableName);
            builder.Append(' ');

            return builder.ToString();
        }

        /// <summary>
        /// Generates a WHERE clause with a single equality clause.
        /// </summary>
        /// <param name="column">Field to filter by.</param>
        /// <param name="value">Value to filter by.</param>
        /// <param name="renameObjectIdToId">If <see langword="true"/>, will rename the column [ObjectId] to [id].</param>
        /// <returns>SOQL WHERE clause.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        protected virtual string GenerateWhereEquals(string column, string value, bool renameObjectIdToId = true)
        {
            if (String.IsNullOrWhiteSpace(column))
            {
                throw new ArgumentNullException(nameof(column));
            }
            else
            {
                StringBuilder builder = new StringBuilder();

                if (renameObjectIdToId && String.Equals(column.Trim(), "objectid", StringComparison.InvariantCultureIgnoreCase))
                {
                    column = ObjectIdColumn;
                }

                builder.Append("WHERE");
                builder.Append(' ');
                builder.Append(column);
                builder.Append("=");
                builder.Append('\'');
                builder.Append(value?.Replace("'", @"\'"));
                builder.Append('\'');

                return builder.ToString();
            }
        }

        /// <summary>
        /// Generates an AND clause with single equality clause.
        /// </summary>
        /// <param name="column">Field to filter by.</param>
        /// <param name="value">Value to filter by.</param>
        /// <param name="renameObjectIdToId">If <see langword="true"/>, will rename the column [ObjectId] to [id].</param>
        /// <returns>SOQL AND clause.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        protected virtual string GenerateAndEquals(string column, string value, bool renameObjectIdToId = true)
        {
            if (String.IsNullOrWhiteSpace(column))
            {
                throw new ArgumentNullException(nameof(column));
            }
            else
            {
                StringBuilder builder = new StringBuilder();

                if (renameObjectIdToId && String.Equals(column.Trim(), "objectid", StringComparison.InvariantCultureIgnoreCase))
                {
                    column = ObjectIdColumn;
                }

                builder.Append(" AND");
                builder.Append(' ');
                builder.Append(column);
                builder.Append("=");
                builder.Append('\'');
                builder.Append(value?.Replace("'", @"\'"));
                builder.Append('\'');

                return builder.ToString();
            }
        }

        /// <summary>
        /// Generates a LIKE clause with a single clause.
        /// </summary>
        /// <param name="column">Field to filter by.</param>
        /// <param name="value">Value to filter by.</param>
        /// <param name="renameObjectIdToId">If <see langword="true"/>, will rename the column [ObjectId] to [id].</param>
        /// <returns>SOQL LIKE clause.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        protected virtual string GenerateLike(string column, string value, bool renameObjectIdToId = true)
        {
            if (String.IsNullOrWhiteSpace(column))
            {
                throw new ArgumentNullException(nameof(column));
            }
            else
            {
                StringBuilder builder = new StringBuilder();

                if (renameObjectIdToId && String.Equals(column.Trim(), "objectid", StringComparison.InvariantCultureIgnoreCase))
                {
                    column = ObjectIdColumn;
                }

                builder.Append("WHERE");
                builder.Append(' ');
                builder.Append(column);
                builder.Append(" LIKE ");
                builder.Append('\'');

                if (!value.StartsWith('%'))
                {
                    value = '%' + value;
                }

                if (!value.EndsWith('%'))
                {
                    value = value + '%';
                }

                builder.Append(value?.Replace("'", @"\'"));
                builder.Append('\'');

                return builder.ToString();
            }
        }

        /// <summary>
        /// Determines if the specified property is available in the Salesforce instance.
        /// </summary>
        /// <param name="objectProperty">Property name on the C# object.</param>
        /// <returns><see langword="true"/> if the field is available and mapped; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        protected virtual bool FieldAvailable(string objectProperty)
        {
            if (String.IsNullOrWhiteSpace(objectProperty))
            {
                throw new ArgumentNullException(nameof(objectProperty));
            }
            else
            {
                TSalesforceObject obj = new TSalesforceObject();
                WhippetDataRowImportMap map = obj.CreateImportMap();

                return AvailableProperties.Contains(map[objectProperty].Column, StringComparer.InvariantCultureIgnoreCase);
            }
        }

        /// <summary>
        /// Creates a view model based on the specified <typeparamref name="TSalesforceObject"/>.
        /// </summary>
        /// <param name="obj"><typeparamref name="TSalesforceObject"/> object to create the view model from.</param>
        /// <param name="ignoreFields">Fields to ignore when generating the view model.</param>
        /// <param name="forcedFields">External fields that may not be present in the <see cref="AvailableProperties"/> list but are required for the view model.</param>
        /// <returns>View model that can be JSON serialized and submitted to Salesforce.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        protected virtual object CreateDynamicViewModel(TSalesforceObject obj, IEnumerable<string> ignoreFields = null, IEnumerable<string> forcedFields = null)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            else
            {
                dynamic viewModel = new ExpandoObject();

                DataTable table = obj.CreateDataTable();
                DataRow row = obj.CreateDataRow();

                int columnIndex = -1;

                List<string> properties = new List<string>(AvailableProperties);

                if (ignoreFields != null && ignoreFields.Any())
                {
                    foreach (string field in ignoreFields)
                    {
                        for (int i = 0; i < properties.Count; i++)
                        {
                            if (String.Equals(properties[i], field, StringComparison.InvariantCultureIgnoreCase))
                            {
                                properties.RemoveAt(i);
                                break;
                            }
                        }
                    }
                }

                if (forcedFields != null && forcedFields.Any())
                {
                    foreach (string field in forcedFields)
                    {
                        if (!(from f in properties where String.Equals(f, field, StringComparison.InvariantCultureIgnoreCase) select f).Any())
                        {
                            properties.Add(field);
                        }
                    }
                }

                foreach (string availablePropertyName in properties)
                {
                    columnIndex = -1;

                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        if (String.Equals(table.Columns[i].ColumnName, availablePropertyName, StringComparison.InvariantCultureIgnoreCase))
                        {
                            columnIndex = i;
                            break;
                        }
                    }

                    if ((columnIndex >= 0) && (row[columnIndex] != null) && (row[columnIndex] != DBNull.Value))
                    {
                        if (row[columnIndex] is string)
                        {
                            if (row[columnIndex].ToString().Contains("'"))
                            {
                                row[columnIndex] = row[columnIndex].ToString().Replace("'", @"\'");
                            }
                        }
                        else if (row[columnIndex] is Instant)
                        {
                            row[columnIndex] = ((Instant)(row[columnIndex])).ToDateTimeUtc();
                        }

                        ((IDictionary<string, object>)(viewModel))[availablePropertyName] = row[columnIndex];
                    }
                }

                return viewModel;
            }
        }

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        /// <param name="entity">Entity to refresh.</param>
        void IWhippetRepository<TSalesforceObject, SalesforceReference>.RefreshEntityContext(TSalesforceObject entity)
        { }

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        /// <param name="entity">Entity to refresh.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        async Task IWhippetRepository<TSalesforceObject, SalesforceReference>.RefreshEntityContextAsync(TSalesforceObject entity, CancellationToken? cancellationToken)
        {
            await Task.Run(() =>
            {
                return;
            });
        }

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        /// <param name="entity">Entity to refresh.</param>
        void IWhippetRepository<TSalesforceObject, Guid>.RefreshEntityContext(TSalesforceObject entity)
        { }

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        /// <param name="entity">Entity to refresh.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="Task"/> object.</returns>
        async Task IWhippetRepository<TSalesforceObject, Guid>.RefreshEntityContextAsync(TSalesforceObject entity, CancellationToken? cancellationToken)
        {
            await Task.Run(() =>
            {
                return;
            });
        }

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        void IWhippetDetachedRepository<TSalesforceObject>.Commit()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        Task IWhippetDetachedRepository<TSalesforceObject>.CommitAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

