using System;
using System.Data;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace Athi.Whippet.Data.SqlKata
{
    /// <summary>
    /// Represents a generic repository that is independent of a backing data store. This repository is used for connecting to external data stores that are not contained within Whippet and require extra functionality in order to manipulate data. This class must be inherited.
    /// </summary>
    /// <typeparam name="TEntity">Type of entity stored in the repository.</typeparam>
    /// <typeparam name="TKey">Type of key used to index <typeparamref name="TEntity"/> in the data store.</typeparam>
    public abstract class SqlKataExternalEntityRepository<TEntity, TKey> : WhippetExternalEntityRepository<TEntity, TKey>, IWhippetEntityRepository<TEntity, TKey>, IDisposable
        where TEntity : WhippetEntity, IWhippetEntityExternalDataRowImportMapper, new()
        where TKey : struct
    {
        /// <summary>
        /// Represents the original connection string that was passed to the repository.
        /// </summary>
        private readonly string _ConnectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlKataExternalEntityRepository{TEntity, TKey}"/> class with the specified <see cref="IDbConnection"/> object.
        /// </summary>
        /// <param name="connection"><see cref="IDbConnection"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected SqlKataExternalEntityRepository(IDbConnection connection)
            : base(connection)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            else
            {
                _ConnectionString = connection.ConnectionString;
            }
        }

        /// <summary>
        /// Creates a new <see cref="QueryFactory"/> with the specified <see cref="Compiler"/>.
        /// </summary>
        /// <typeparam name="TDbCompiler"><see cref="Compiler"/> to use with the <see cref="QueryFactory"/>.</typeparam>
        /// <param name="timeout">Connection and command timeout.</param>
        /// <returns><see cref="QueryFactory"/> object.</returns>
        protected virtual QueryFactory CreateQueryFactory<TDbCompiler>(int timeout = 30) where TDbCompiler : Compiler, new()
        {
            return new QueryFactory(CreateConnection(_ConnectionString), new TDbCompiler(), timeout);
        }

        /// <summary>
        /// Creates a new <see cref="IDbConnection"/> object based on the originally supplied connection string.
        /// </summary>
        /// <returns><see cref="IDbConnection"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        protected virtual IDbConnection CreateConnection()
        {
            return CreateConnection(_ConnectionString);
        }

        /// <summary>
        /// Creates a new <see cref="IDbConnection"/> object based on the supplied <paramref name="connectionString"/>. This method must be overridden.
        /// </summary>
        /// <param name="connectionString">Connection string used to create the new <see cref="IDbConnection"/> object.</param>
        /// <returns><see cref="IDbConnection"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        protected abstract IDbConnection CreateConnection(string connectionString);
    }
}
