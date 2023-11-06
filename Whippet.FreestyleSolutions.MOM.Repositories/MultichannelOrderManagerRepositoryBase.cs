using System;
using System.Collections.Concurrent;
using System.Data;
using Nito.AsyncEx;
using Athi.Whippet.Data;
using Athi.Whippet.Data.Database.Microsoft;
using Athi.Whippet.Data.SqlKata;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Repositories
{
    /// <summary>
    /// Base class for all Multichannel Order Manager repositories. This class must be inherited.
    /// </summary>
    /// <typeparam name="TEntity">Type of entity stored in the repository.</typeparam>
    /// <typeparam name="TKey">Type of key used to index <typeparamref name="TEntity"/> in the data store.</typeparam>
    public abstract class MultichannelOrderManagerRepositoryBase<TEntity, TKey> : SqlKataExternalEntityRepository<TEntity, TKey>, IWhippetEntityRepository<TEntity, TKey>, IDisposable
        where TEntity : MultichannelOrderManagerEntity, IWhippetEntityExternalDataRowImportMapper, IMultichannelOrderManagerEntity, new()
        where TKey : struct
    {
        /// <summary>
        /// Gets a read-only instance of the entity stored in the repository.
        /// </summary>
        protected readonly TEntity InternalObject;

        /// <summary>
        /// Gets the name of the database table the entity is stored in. This property is read-only.
        /// </summary>
        protected virtual string TableName
        {
            get
            {
                return InternalObject.ExternalTableName;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerRepositoryBase{TEntity, TKey}"/> class with the specified <see cref="IDbConnection"/> object.
        /// </summary>
        /// <param name="connection"><see cref="IDbConnection"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected MultichannelOrderManagerRepositoryBase(IDbConnection connection)
            : base(connection)
        {
            InternalObject = new TEntity();
        }

        /// <summary>
        /// Creates an <see cref="IEnumerable{T}"/> collection of <typeparamref name="TEntity"/> objects from the specified <see langword="dynamic"/> result set.
        /// </summary>
        /// <param name="resultSet"><see cref="IEnumerable{T}"/> result set of <see langword="dynamic"/> objects.</param>
        /// <param name="cancellationToken"></param>
        /// <returns><see cref="IEnumerable{T}"/> collection of the specified type.</returns>
        protected override async Task<IEnumerable<TEntity>> ImportFromDynamicResultSetAsync(IEnumerable<dynamic> resultSet, CancellationToken cancellationToken = default(CancellationToken))
        {
            ConcurrentBag<TEntity> items = new ConcurrentBag<TEntity>();
            AsyncCollection<TEntity> asyncItems = new AsyncCollection<TEntity>(items);

            if (resultSet != null && resultSet.Any())
            {
                await Parallel.ForEachAsync<dynamic>(resultSet, async (item, cancellationToken) =>
                {
                    TEntity c = new TEntity();
                    c.ImportObject(item);

                    await asyncItems.AddAsync(c);
                });
            }

            return items;
        }

        /// <summary>
        /// Creates a new <see cref="WhippetSqlServerConnection"/> object.
        /// </summary>
        /// <param name="connectionString">Connection string.</param>
        /// <returns><see cref="IDbConnection"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        protected override IDbConnection CreateConnection(string connectionString)
        {
            WhippetSqlServerConnection connection = ((WhippetSqlServerConnection)(Connection)).Clone<WhippetSqlServerConnection>();
            connection.ConnectionString = connectionString;

            return connection;
        }
    }
}
