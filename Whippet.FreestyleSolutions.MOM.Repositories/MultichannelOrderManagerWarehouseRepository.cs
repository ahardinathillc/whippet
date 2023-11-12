using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Data;
using NHibernate;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;
using Athi.Whippet.Data;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Repositories
{
    /// <summary>
    /// Represents a data repository for managing <see cref="MultichannelOrderManagerWarehouse"/> entity objects.
    /// </summary>
    public class MultichannelOrderManagerWarehouseRepository : MultichannelOrderManagerRepositoryBase<MultichannelOrderManagerWarehouse, long>, IMultichannelOrderManagerWarehouseRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerWarehouseRepository"/> class with the specified <see cref="IDbConnection"/> object.
        /// </summary>
        /// <param name="connection"><see cref="IDbConnection"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerWarehouseRepository(IDbConnection connection)
            : base(connection)
        { }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerWarehouse"/> objects.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        public virtual WhippetResultContainer<IEnumerable<MultichannelOrderManagerWarehouse>> GetWarehouses()
        {
            return Task.Run(() => GetWarehousesAsync()).Result;
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerWarehouse"/> objects.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        public virtual async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerWarehouse>>> GetWarehousesAsync(CancellationToken? cancellationToken = null)
        {
            QueryFactory context = null;
            Query query = null;

            WhippetResultContainer<IEnumerable<MultichannelOrderManagerWarehouse>> result = null;

            WhippetDataRowImportMap map = InternalObject.CreateImportMap();

            IEnumerable<dynamic> results = null;

            try
            {
                context = CreateQueryFactory<SqlServerCompiler>();
                query = context.Query(TableName);

                results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerWarehouse>>(WhippetResult.Success, await ImportFromDynamicResultSetAsync(results));
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerWarehouse>>(new WhippetResult(e), null);
            }
            finally
            {
                if (context != null)
                {
                    context.Dispose();
                    context = null;
                }
            }

            return result;
        }

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        /// <param name="key">Unique key of the record to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        WhippetResultContainer<MultichannelOrderManagerWarehouse> IWhippetRepository<MultichannelOrderManagerWarehouse, Guid>.Get(System.Guid key)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        /// <param name="key">Unique key of the record to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        Task<WhippetResultContainer<MultichannelOrderManagerWarehouse>> IWhippetRepository<MultichannelOrderManagerWarehouse, Guid>.GetAsync(Guid key, CancellationToken? cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}