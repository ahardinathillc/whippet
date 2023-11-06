using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Data;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using NHibernate;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;
using Athi.Whippet.Data;
using Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Extensions;

namespace Athi.Whippet.FreestyleSolutions.MultichannelOrderManager.Repositories
{
    /// <summary>
    /// Represents a data repository for managing <see cref="MultichannelOrderManagerPostalCode"/> entity objects.
    /// </summary>
    public class MultichannelOrderManagerPostalCodeRepository : MultichannelOrderManagerRepositoryBase<MultichannelOrderManagerPostalCode, long>, IMultichannelOrderManagerPostalCodeRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultichannelOrderManagerPostalCodeRepository"/> class with the specified <see cref="IDbConnection"/> object.
        /// </summary>
        /// <param name="connection"><see cref="IDbConnection"/> to initialize with.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MultichannelOrderManagerPostalCodeRepository(IDbConnection connection)
            : base(connection)
        { }

        /// <summary>
        /// Gets the specified item based on the query provided by the implementation.
        /// </summary>
        /// <param name="key">Unique identifier of the item to retrieve.</param>
        /// <param name="ignoreColumns">Columns to ignore when building the query.</param>
        /// <returns><see cref="WhippetResultContainer{TEntity}"/> containing the result of the domain object operation and the corresponding item if found.</returns>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="DataTablePrimaryKeyNotFoundException"></exception>
        /// <exception cref="CompositeKeyException"></exception>
        protected override WhippetResultContainer<MultichannelOrderManagerPostalCode> GetSingle(object key, params string[] ignoreColumns)
        {
            WhippetDataRowImportMap map = InternalObject.CreateImportMap();

            return base.GetSingle(key, map[nameof(MultichannelOrderManagerPostalCode.TaxUpdate)].Column);
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerPostalCode"/> objects.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        public override async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerPostalCode>>> GetAllAsync(CancellationToken? cancellationToken = null)
        {
            QueryFactory context = null;
            Query query = null;

            WhippetResultContainer<IEnumerable<MultichannelOrderManagerPostalCode>> result = null;

            WhippetDataRowImportMap map = InternalObject.CreateImportMap();

            IEnumerable<dynamic> results = null;

            try
            {
                context = CreateQueryFactory<SqlServerCompiler>();
                query = context.Query(TableName);

                results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerPostalCode>>(WhippetResult.Success, await ImportFromDynamicResultSetAsync(results));
            }
            catch (Exception e)
            {
                result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerPostalCode>>(new WhippetResult(e), null);
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
        /// Gets all <see cref="MultichannelOrderManagerPostalCode"/> objects for the specified <see cref="IMultichannelOrderManagerCountry"/>.
        /// </summary>
        /// <param name="country"><see cref="IMultichannelOrderManagerCountry"/> to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<MultichannelOrderManagerPostalCode>> GetPostalCodes(IMultichannelOrderManagerCountry country)
        {
            if (country == null)
            {
                throw new ArgumentNullException(nameof(country));
            }
            else
            {
                return Task.Run(() => GetPostalCodesAsync(country)).Result;
            }
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerPostalCode"/> objects for the specified <see cref="IMultichannelOrderManagerCountry"/>.
        /// </summary>
        /// <param name="country"><see cref="IMultichannelOrderManagerCountry"/> to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerPostalCode>>> GetPostalCodesAsync(IMultichannelOrderManagerCountry country, CancellationToken? cancellationToken = null)
        {
            if (country == null)
            {
                throw new ArgumentNullException(nameof(country));
            }
            else
            {
                QueryFactory context = null;
                Query query = null;

                WhippetResultContainer<IEnumerable<MultichannelOrderManagerPostalCode>> result = null;

                WhippetDataRowImportMap map = InternalObject.CreateImportMap();

                IEnumerable<dynamic> results = null;

                try
                {
                    context = CreateQueryFactory<SqlServerCompiler>();
                    query = context.Query(TableName).Where(InternalObject.ImportMap[nameof(InternalObject.Country)].Column, "=", country.CountryCode);

                    results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerPostalCode>>(WhippetResult.Success, await ImportFromDynamicResultSetAsync(results));

                    if (result.IsSuccess && result.HasItem)
                    {
                        foreach (MultichannelOrderManagerPostalCode code in result.Item)
                        {
                            code.Country = country.ToMultichannelOrderManagerCountry();
                        }
                    }
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerPostalCode>>(new WhippetResult(e), null);
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
        /// Gets all <see cref="MultichannelOrderManagerPostalCode"/> objects for the specified <see cref="IMultichannelOrderManagerCountry"/>.
        /// </summary>
        /// <param name="stateProvince"><see cref="IMultichannelOrderManagerStateProvince"/> to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<MultichannelOrderManagerPostalCode>> GetPostalCodes(IMultichannelOrderManagerStateProvince stateProvince)
        {
            if (stateProvince == null)
            {
                throw new ArgumentNullException(nameof(stateProvince));
            }
            else
            {
                return Task.Run(() => GetPostalCodesAsync(stateProvince)).Result;
            }
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerPostalCode"/> objects for the specified <see cref="IMultichannelOrderManagerCountry"/>.
        /// </summary>
        /// <param name="stateProvince"><see cref="IMultichannelOrderManagerStateProvince"/> to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerPostalCode>>> GetPostalCodesAsync(IMultichannelOrderManagerStateProvince stateProvince, CancellationToken? cancellationToken = null)
        {
            if (stateProvince == null)
            {
                throw new ArgumentNullException(nameof(stateProvince));
            }
            else
            {
                QueryFactory context = null;
                Query query = null;

                WhippetResultContainer<IEnumerable<MultichannelOrderManagerPostalCode>> result = null;

                WhippetDataRowImportMap map = InternalObject.CreateImportMap();

                IEnumerable<dynamic> results = null;

                try
                {
                    context = CreateQueryFactory<SqlServerCompiler>();
                    query = context.Query(TableName).Where(InternalObject.ImportMap[nameof(InternalObject.StateProvince)].Column, "=", stateProvince.Abbreviation);

                    results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerPostalCode>>(WhippetResult.Success, await ImportFromDynamicResultSetAsync(results));
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerPostalCode>>(new WhippetResult(e), null);
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
        /// Gets the <see cref="MultichannelOrderManagerPostalCode"/> object with the specified three digit code.
        /// </summary>
        /// <param name="countyCode">Three-digit county code of the county.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<MultichannelOrderManagerPostalCode> GetPostalCodeByCode(string countyCode)
        {
            if (String.IsNullOrWhiteSpace(countyCode))
            {
                throw new ArgumentNullException(nameof(countyCode));
            }
            else
            {
                return Task.Run(() => GetPostalCodeByCodeAsync(countyCode)).Result;
            }
        }

        /// <summary>
        /// Gets the <see cref="MultichannelOrderManagerPostalCode"/> object with the specified three digit code.
        /// </summary>
        /// <param name="countyCode">Three-digit county code of the county.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<MultichannelOrderManagerPostalCode>> GetPostalCodeByCodeAsync(string countyCode, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(countyCode))
            {
                throw new ArgumentNullException(nameof(countyCode));
            }
            else
            {
                QueryFactory context = null;
                Query query = null;

                WhippetResultContainer<IEnumerable<MultichannelOrderManagerPostalCode>> result = null;

                WhippetDataRowImportMap map = InternalObject.CreateImportMap();

                IEnumerable<dynamic> results = null;

                try
                {
                    context = CreateQueryFactory<SqlServerCompiler>();
                    query = context.Query(TableName).Where(map[nameof(InternalObject.Country)].Column, "=", countyCode);

                    results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerPostalCode>>(WhippetResult.Success, await ImportFromDynamicResultSetAsync(results));
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerPostalCode>>(new WhippetResult(e), null);
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                        context = null;
                    }
                }

                return new WhippetResultContainer<MultichannelOrderManagerPostalCode>(result.Result, result.Item.FirstOrDefault());
            }
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerPostalCode"/> objects that match the specified postal code.
        /// </summary>
        /// <param name="postalCode">Postal code value to filter by.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual WhippetResultContainer<IEnumerable<MultichannelOrderManagerPostalCode>> GetPostalCodes(string postalCode)
        {
            if (String.IsNullOrWhiteSpace(postalCode))
            {
                throw new ArgumentNullException(nameof(postalCode));
            }
            else
            {
                return Task.Run(() => GetPostalCodesAsync(postalCode)).Result;
            }
        }

        /// <summary>
        /// Gets all <see cref="MultichannelOrderManagerPostalCode"/> objects that match the specified postal code.
        /// </summary>
        /// <param name="postalCode">Postal code value to filter by.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the query (if any).</returns>
        /// <exception cref="ArgumentNullException" />
        public virtual async Task<WhippetResultContainer<IEnumerable<MultichannelOrderManagerPostalCode>>> GetPostalCodesAsync(string postalCode, CancellationToken? cancellationToken = null)
        {
            if (String.IsNullOrWhiteSpace(postalCode))
            {
                throw new ArgumentNullException(nameof(postalCode));
            }
            else
            {
                QueryFactory context = null;
                Query query = null;

                WhippetResultContainer<IEnumerable<MultichannelOrderManagerPostalCode>> result = null;

                WhippetDataRowImportMap map = InternalObject.CreateImportMap();

                IEnumerable<dynamic> results = null;

                try
                {
                    context = CreateQueryFactory<SqlServerCompiler>();
                    query = context.Query(TableName).Where(map[nameof(InternalObject.PostalCode)].Column, "=", postalCode);

                    results = await query.GetAsync(null, null, cancellationToken.GetValueOrDefault());

                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerPostalCode>>(WhippetResult.Success, await ImportFromDynamicResultSetAsync(results));
                }
                catch (Exception e)
                {
                    result = new WhippetResultContainer<IEnumerable<MultichannelOrderManagerPostalCode>>(new WhippetResult(e), null);
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                        context = null;
                    }
                }

                return new WhippetResultContainer<IEnumerable<MultichannelOrderManagerPostalCode>>(result.Result, result.Item);
            }
        }

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        /// <param name="key">Unique key of the record to retrieve.</param>
        /// <returns><see cref="WhippetResultContainer{T}"/> containing the result of the operation.</returns>
        /// <exception cref="NotImplementedException"></exception>
        WhippetResultContainer<MultichannelOrderManagerPostalCode> IWhippetRepository<MultichannelOrderManagerPostalCode, Guid>.Get(System.Guid key)
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
        Task<WhippetResultContainer<MultichannelOrderManagerPostalCode>> IWhippetRepository<MultichannelOrderManagerPostalCode, Guid>.GetAsync(Guid key, CancellationToken? cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
