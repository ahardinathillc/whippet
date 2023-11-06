using System;
using System.Collections.Concurrent;
using System.Data;
using System.Threading;
using Nito.AsyncEx;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;
using Athi.Whippet.Data;
using Athi.Whippet.Data.Database.Microsoft;
using Athi.Whippet.Data.SqlKata;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Exports.Repositories
{
    /// <summary>
    /// Represents a data repository for managing <see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> entity objects.
    /// </summary>
    public class MultichannelOrderManagerFlattenedTaxRateExportRepository : SqlKataExternalEntityRepository<MultichannelOrderManagerFlattenedTaxRateExport, MultichannelOrderManagerFlattenedTaxRateExportSearchCriteria>, IWhippetEntityRepository<MultichannelOrderManagerFlattenedTaxRateExport, MultichannelOrderManagerFlattenedTaxRateExportSearchCriteria>, IDisposable, IMultichannelOrderManagerFlattenedTaxRateExportRepository
    {
        protected readonly MultichannelOrderManagerFlattenedTaxRateExport InternalObject;

        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerFlattenedTaxRateExportRepository"/> class with the specified <see cref="IDbConnection"/> object.
        /// </summary>
        /// <param name="connection"><see cref="IDbConnection"/> to initialize with.</param>
        /// <param name="tableViewName">Table or view name that contains the export information. If <see cref="String.Empty"/> or <see langword="null"/>, the default value is used.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerFlattenedTaxRateExportRepository(IDbConnection connection, string tableViewName = null)
            : base(connection)
        {
            InternalObject = !String.IsNullOrWhiteSpace(tableViewName) ? new MultichannelOrderManagerFlattenedTaxRateExport(tableViewName) : new MultichannelOrderManagerFlattenedTaxRateExport();
        }

        /// <summary>
        /// Asynchronously gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="key">Unique identifier of the item to retrieve.</param>
        /// <returns><see cref="Task{TResult}"/> object which encapsulates a <see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        public override async Task<WhippetResultContainer<MultichannelOrderManagerFlattenedTaxRateExport>> GetAsync(MultichannelOrderManagerFlattenedTaxRateExportSearchCriteria key, CancellationToken? cancellationToken = null)
        {
            QueryFactory context = null;
            Query query = null;

            WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>> result = null;
            WhippetResultContainer<MultichannelOrderManagerFlattenedTaxRateExport> singleResult = null;

            WhippetDataRowImportMap map = InternalObject.CreateImportMap();

            IEnumerable<dynamic> results = null;

            List<string> orderColumns = null;

            try
            {
                context = CreateQueryFactory<SqlServerCompiler>();
                query = context.Query(((IWhippetEntityExternalDataRowImportMapper)(InternalObject)).ExternalTableName);

                orderColumns = new List<string>();

                if (key.Country != null && (key.Country.CountryId > 0))
                {
                    query = query.Where(InternalObject.ImportMap[nameof(InternalObject.Country)].Column, "=", key.Country.CountryId);
                    orderColumns.Add(InternalObject.ImportMap[nameof(InternalObject.Country)].Column);
                }

                if (key.StateProvince != null && (key.StateProvince.ID > 0))
                {
                    query = query.Where(InternalObject.ImportMap[nameof(InternalObject.StateProvince)].Column, "=", key.StateProvince.ID);
                    orderColumns.Add(InternalObject.ImportMap[nameof(InternalObject.StateProvince)].Column);
                }

                if (key.PostalCode != null && !String.IsNullOrWhiteSpace(key.PostalCode.PostalCode))
                {
                    query = query.Where(InternalObject.ImportMap[nameof(InternalObject.PostalCode)].Column, "=", key.PostalCode.PostalCode);
                    orderColumns.Add(InternalObject.ImportMap[nameof(InternalObject.PostalCode)].Column);
                }

                if (key.TaxServices.HasValue)
                {
                    if (key.TaxServices.Value)
                    {
                        query = query.WhereTrue(InternalObject.ImportMap[nameof(InternalObject.TaxServices)].Column);
                    }
                    else
                    {
                        query = query.WhereFalse(InternalObject.ImportMap[nameof(InternalObject.TaxServices)].Column);
                    }
                }

                if (key.TaxShipping.HasValue)
                {
                    if (key.TaxServices.Value)
                    {
                        query = query.WhereTrue(InternalObject.ImportMap[nameof(InternalObject.TaxShipping)].Column);
                    }
                    else
                    {
                        query = query.WhereFalse(InternalObject.ImportMap[nameof(InternalObject.TaxShipping)].Column);
                    }
                }

                if (orderColumns.Count > 0)
                {
                    query = query.OrderBy(orderColumns.ToArray());
                }

                results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>(WhippetResult.Success, await ImportFromDynamicResultSetAsync(results));

                result.ThrowIfFailed();
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>(new WhippetResult(e), null);
            }
            finally
            {
                if (context != null)
                {
                    context.Dispose();
                    context = null;
                }
            }

            if (result.IsSuccess)
            {
                singleResult = new WhippetResultContainer<MultichannelOrderManagerFlattenedTaxRateExport>(result.Result, result.Item.FirstOrDefault());
            }
            else
            {
                singleResult = new WhippetResultContainer<MultichannelOrderManagerFlattenedTaxRateExport>(result.Exception);
            }

            return singleResult;
        }

        /// <summary>
        /// Retrieves all <see cref="MultichannelOrderManagerFlattenedTaxRateExport"/> objects in the data store.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        public override async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>> GetAllAsync(CancellationToken? cancellationToken = null)
        {
            QueryFactory context = null;
            Query query = null;

            WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>> result = null;

            IEnumerable<dynamic> results = null;

            List<string> orderColumns = null;

            try
            {
                orderColumns = new List<string>();
                context = CreateQueryFactory<SqlServerCompiler>();
                query = context.Query(((IWhippetEntityExternalDataRowImportMapper)(InternalObject)).ExternalTableName);

                orderColumns.Add(InternalObject.ImportMap[nameof(InternalObject.Country)].Column);
                orderColumns.Add(InternalObject.ImportMap[nameof(InternalObject.StateProvince)].Column);
                orderColumns.Add(InternalObject.ImportMap[nameof(InternalObject.PostalCode)].Column);

                query = query.OrderBy(orderColumns.ToArray());
                query = query.Distinct();

                results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>(WhippetResult.Success, await ImportFromDynamicResultSetAsync(results));

                result.ThrowIfFailed();

                // now squash any duplicates

                result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>(result.Result, result.Item);
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>>(new WhippetResult(e), null);
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
        WhippetResultContainer<MultichannelOrderManagerFlattenedTaxRateExport> IWhippetRepository<MultichannelOrderManagerFlattenedTaxRateExport, Guid>.Get(Guid key)
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
        Task<WhippetResultContainer<MultichannelOrderManagerFlattenedTaxRateExport>> IWhippetRepository<MultichannelOrderManagerFlattenedTaxRateExport, Guid>.GetAsync(Guid key, CancellationToken? cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates an <see cref="IEnumerable{T}"/> collection of <typeparamref name="TEntity"/> objects from the specified <see langword="dynamic"/> result set.
        /// </summary>
        /// <param name="resultSet"><see cref="IEnumerable{T}"/> result set of <see langword="dynamic"/> objects.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override async Task<IEnumerable<MultichannelOrderManagerFlattenedTaxRateExport>> ImportFromDynamicResultSetAsync(IEnumerable<dynamic> resultSet, CancellationToken cancellationToken = default(CancellationToken))
        {
            ConcurrentBag<MultichannelOrderManagerFlattenedTaxRateExport> items = new ConcurrentBag<MultichannelOrderManagerFlattenedTaxRateExport>();
            AsyncCollection<MultichannelOrderManagerFlattenedTaxRateExport> asyncItems = new AsyncCollection<MultichannelOrderManagerFlattenedTaxRateExport>(items);

            if (resultSet != null && resultSet.Any())
            {
                await Parallel.ForEachAsync<dynamic>(resultSet, async (item, cancellationToken) =>
                {
                    MultichannelOrderManagerFlattenedTaxRateExport c = new MultichannelOrderManagerFlattenedTaxRateExport();
                    c.ImportObject(item);

                    await asyncItems.AddAsync(c);
                });
            }

            return new SortedSet<MultichannelOrderManagerFlattenedTaxRateExport>(items, MultichannelOrderManagerFlattenedTaxRateExport.MultichannelOrderManagerFlattenedTaxRateExportComparer.Instance);
        }

        /// <summary>
        /// Creates a new <see cref="WhippetSqlServerConnection"/> object.
        /// </summary>
        /// <param name="connectionString">Connection string.</param>
        /// <returns><see cref="IDbConnection"/> object.</returns>
        /// <exception cref="ArgumentNullException" />
        protected override IDbConnection CreateConnection(string connectionString)
        {
            return new WhippetSqlServerConnection(connectionString);
        }
    }
}
