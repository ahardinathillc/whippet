using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Data;
using System.Linq;
using System.Text;
using NHibernate;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;
using Athi.Whippet.Data;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Repositories
{
    /// <summary>
    /// Represents a data repository for managing <see cref="MultichannelOrderManagerCounty"/> entity objects.
    /// </summary>
    public class MultichannelOrderManagerCountyRepository : MultichannelOrderManagerRepositoryBase<MultichannelOrderManagerCounty, long>, IMultichannelOrderManagerCountyRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerCountyRepository"/> class with the specified <see cref="IDbConnection"/> object.
        /// </summary>
        /// <param name="connection"><see cref="IDbConnection"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerCountyRepository(IDbConnection connection)
            : base(connection)
        { }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerCounty"/> objects.
        /// </summary>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        public override WhippetResultContainer<IEnumerable<MultichannelOrderManagerCounty>> GetAll()
        {
            return Task.Run(() => GetAllAsync()).Result;
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerCounty"/> objects.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        public override async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerCounty>>> GetAllAsync(CancellationToken? cancellationToken = null)
        {
            QueryFactory context = null;
            Query query = null;

            WhippetResultContainer<IEnumerable<MultichannelOrderManagerCounty>> result = null;

            WhippetDataRowImportMap map = InternalObject.CreateImportMap();

            IEnumerable<dynamic> results = null;

            try
            {
                context = CreateQueryFactory<SqlServerCompiler>();
                query = context.Query(TableName);

                results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCounty>>(WhippetResult.Success, await ImportFromDynamicResultSetAsync(results));
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCounty>>(new WhippetResult(e), null);
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
        /// Gets all <see cref="MultichannelOrderManagerCounty"/> objects for the specified <see cref="IMultichannelOrderManagerCountry"/>.
        /// </summary>
        /// <param name="country"><see cref="IMultichannelOrderManagerCountry"/> to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<MultichannelOrderManagerCounty>> Get(IMultichannelOrderManagerCountry country)
        {
            if (country == null)
            {
                throw new ArgumentNullException(nameof(country));
            }
            else
            {
                return Task.Run(() => GetAsync(country)).Result;
            }
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerCounty"/> objects for the specified <see cref="IMultichannelOrderManagerCountry"/>.
        /// </summary>
        /// <param name="country"><see cref="IMultichannelOrderManagerCountry"/> to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerCounty>>> GetAsync(IMultichannelOrderManagerCountry country, CancellationToken? cancellationToken = null)
        {
            if (country == null)
            {
                throw new ArgumentNullException(nameof(country));
            }
            else
            {
                QueryFactory context = null;
                Query query = null;

                WhippetResultContainer<IEnumerable<MultichannelOrderManagerCounty>> result = null;

                WhippetDataRowImportMap map = InternalObject.CreateImportMap();

                IEnumerable<dynamic> results = null;

                try
                {
                    context = CreateQueryFactory<SqlServerCompiler>();
                    query = context.Query(TableName).Where(InternalObject.ImportMap[nameof(InternalObject.Country)].Column, "=", country.CountryCode);

                    results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCounty>>(WhippetResult.Success, await ImportFromDynamicResultSetAsync(results));
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCounty>>(new WhippetResult(e), null);
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
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerCounty"/> objects for the specified <see cref="IMultichannelOrderManagerCountry"/>.
        /// </summary>
        /// <param name="stateProvince"><see cref="IMultichannelOrderManagerStateProvince"/> to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<MultichannelOrderManagerCounty>> Get(IMultichannelOrderManagerStateProvince stateProvince)
        {
            if (stateProvince == null)
            {
                throw new ArgumentNullException(nameof(stateProvince));
            }
            else
            {
                return Task.Run(() => GetAsync(stateProvince)).Result;
            }
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerCounty"/> objects for the specified <see cref="IMultichannelOrderManagerCountry"/>.
        /// </summary>
        /// <param name="stateProvince"><see cref="IMultichannelOrderManagerStateProvince"/> to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerCounty>>> GetAsync(IMultichannelOrderManagerStateProvince stateProvince, CancellationToken? cancellationToken = null)
        {
            if (stateProvince == null)
            {
                throw new ArgumentNullException(nameof(stateProvince));
            }
            else
            {
                QueryFactory context = null;
                Query query = null;

                WhippetResultContainer<IEnumerable<MultichannelOrderManagerCounty>> result = null;

                WhippetDataRowImportMap map = InternalObject.CreateImportMap();

                IEnumerable<dynamic> results = null;

                try
                {
                    context = CreateQueryFactory<SqlServerCompiler>();
                    query = context.Query(TableName).Where(InternalObject.ImportMap[nameof(InternalObject.StateProvince)].Column, "=", stateProvince.Abbreviation);

                    results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCounty>>(WhippetResult.Success, await ImportFromDynamicResultSetAsync(results));
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCounty>>(new WhippetResult(e), null);
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
        }

        /// <summary>
        /// Gets the <see cref="MultichannelOrderManagerCounty"/> object with the specified three digit code.
        /// </summary>
        /// <param name="countyCode">Three-digit county code of the county.</param>
        /// <param name="stateAbbreviation">State abbreviation.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<MultichannelOrderManagerCounty> GetCountyByCode(string countyCode, string stateAbbreviation)
        {
            if (String.IsNullOrWhiteSpace(countyCode))
            {
                throw new ArgumentNullException(nameof(countyCode));
            }
            else
            {
                return Task.Run(() => GetCountyByCodeAsync(countyCode, stateAbbreviation)).Result;
            }
        }

        /// <summary>
        /// Gets the <see cref="MultichannelOrderManagerCounty"/> object with the specified three digit code.
        /// </summary>
        /// <param name="countyCode">Three-digit county code of the county.</param>
        /// <param name="stateAbbreviation">State abbreviation.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<MultichannelOrderManagerCounty>> GetCountyByCodeAsync(string countyCode, string stateAbbreviation, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(countyCode))
            {
                throw new ArgumentNullException(nameof(countyCode));
            }
            else if (String.IsNullOrWhiteSpace(stateAbbreviation))
            {
                throw new ArgumentNullException(nameof(stateAbbreviation));
            }
            else
            {
                QueryFactory context = null;
                Query query = null;

                WhippetResultContainer<IEnumerable<MultichannelOrderManagerCounty>> result = null;

                WhippetDataRowImportMap map = InternalObject.CreateImportMap();

                IEnumerable<dynamic> results = null;

                try
                {
                    context = CreateQueryFactory<SqlServerCompiler>();
                    query = context.Query(TableName).Where(map[nameof(InternalObject.CountyCode)].Column, "=", countyCode);
                    query = query.Where(map[nameof(InternalObject.StateProvince)].Column, "=", stateAbbreviation);

                    results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCounty>>(WhippetResult.Success, await ImportFromDynamicResultSetAsync(results));
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerCounty>>(new WhippetResult(e), null);
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                        context = null;
                    }
                }

                return new WhippetResultContainer<MultichannelOrderManagerCounty>(result.Result, result.Item.FirstOrDefault());
            }
        }

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        /// <param name="key">Unique key of the record to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        WhippetResultContainer<MultichannelOrderManagerCounty> IWhippetRepository<MultichannelOrderManagerCounty, Guid>.Get(System.Guid key)
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
        Task<WhippetResultContainer<MultichannelOrderManagerCounty>> IWhippetRepository<MultichannelOrderManagerCounty, Guid>.GetAsync(Guid key, CancellationToken? cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}